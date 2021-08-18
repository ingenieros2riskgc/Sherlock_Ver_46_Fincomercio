using ClosedXML.Excel;
using iTextSharp.text;
using iTextSharp.text.pdf;
using ListasSarlaft.Classes;
using ListasSarlaft.Classes.BLL;
using Microsoft.Security.Application;
using System;
using System.Collections.Generic;
using System.Configuration;
using System.Data;
using System.Data.SqlClient;
using System.IO;
using System.Linq;
using System.Net.Mail;
using System.Text;
using System.Threading;
using System.Web;
using System.Web.Configuration;
using System.Web.UI;
using System.Web.UI.WebControls;
using Image = iTextSharp.text.Image;

namespace ListasSarlaft.UserControls.Proceso.Acm
{
    public partial class ReporteAcm : System.Web.UI.UserControl
    {
        cParametrizacion Parametrizacion = new cParametrizacion();
        private cCuenta cCuenta = new cCuenta();
        private static int LastInsertIdCE;
        string IdFormulario = "4050";
        protected void Page_Load(object sender, EventArgs e)
        {
            if (cCuenta.permisosConsulta(IdFormulario) == "False")
                Response.Redirect("~/Formularios/Sarlaft/Admin/HomeAdmin.aspx?Denegar=1");

            Page.Form.Attributes.Add("enctype", "multipart/form-data");
            if (!Page.IsPostBack)
            {
                Session["AcmCerrado"] = false;
                Session["IdAcm"] = 0;
                Session["IdActividad"] = 0;
                Session["AnalisisCausa"] = null;
                Session["NombreArchivo"] = string.Empty;
                Session["Extension"] = string.Empty;
                CargarGrillaAcm();
                
            }
        }
        private void CargarGrillaAcm()
        {
            try
            {
                using (GestionAcmBLL objData = new GestionAcmBLL())
                {
                    gvAcm.DataSource = objData.ReporteAcms();
                    gvAcm.DataBind();
                    if (gvAcm.Rows.Count == 0)
                        omb.ShowMessage("No se han registrado Acm", 3, "Información");
                }
            }
            catch (Exception ex)
            {
                omb.ShowMessage($"Error al cargar los Acm. {ex.Message}", 1, "Atención");
            }
        }

        protected void btnDescargarAcm_Click(object sender, ImageClickEventArgs e)
        {
            CrearPdf();
        }

        private void CrearPdf()
        {
            try
            {

                // Creamos el tipo de Font que vamos utilizar
                Font titleFont = new Font(Font.HELVETICA, 10, Font.BOLD, Color.BLACK);
                Font textFont = new Font(Font.HELVETICA, 8, Font.NORMAL, Color.BLACK);
                Font subtitleFont = new Font(Font.HELVETICA, 9, Font.BOLD, Color.BLACK);
                Font headertableFont = new Font(Font.HELVETICA, 10, Font.NORMAL, Color.WHITE);
                List<PdfPRow> pRows = new List<PdfPRow>();


                PdfPTable separador = new PdfPTable(1);
                var cell = new PdfPCell(new Phrase("")) { Border = 1 };
                separador.AddCell(cell);

                #region InfoReporte
                // Crea la informacion de las actividades en el pdf
                PdfPTable tableActividades = new PdfPTable(8);
                float[] anchoDeColumnas = new float[] { 20f, 20f, 30f, 30f, 10f, 20f, 30f, 10f };
                tableActividades.SetWidths(anchoDeColumnas);
                if (gvAcm.Rows.Count > 0)
                {
                    int contador = 0;
                    // Crea el encabezado de la tabla
                    foreach (TableCell headerCell in gvAcm.HeaderRow.Cells)
                    {
                        PdfPCell pdfCell = new PdfPCell(new Phrase(headerCell.Text.Replace("&#243;", "ó"), headertableFont))
                        {
                            BackgroundColor = new Color(gvAcm.HeaderStyle.BackColor),
                            HorizontalAlignment = Element.ALIGN_CENTER
                        };
                        if(contador > 0)
                            tableActividades.AddCell(pdfCell);
                        contador++;
                        
                        /*if (new[] { 2, 3, 4, 5, 6 }.Any(x => x == contador))
                        {
                            tableActividades.AddCell(pdfCell);
                        }*/
                    }
                    foreach (GridViewRow Row in gvAcm.Rows)
                    {
                        //string txtNo = Convert.ToString(Row.RowIndex+1);
                        string codigo = Row.Cells[1].Text;
                        string NombreCadenaValor = Row.Cells[2].Text;
                        string NombreMacroproceso = Row.Cells[3].Text;
                        string NombreProceso = Row.Cells[4].Text;
                        string NombreSubproceso = Row.Cells[5].Text;
                        string NombreOrigenNoConformidad = Row.Cells[6].Text;
                        string NombreResponsable = Row.Cells[7].Text;
                        string NombreEstado = Row.Cells[8].Text;

                        List<PdfPCell> rowTable = new List<PdfPCell>
                    {
                        //new PdfPCell(new Phrase(Context.Server.HtmlDecode(txtNo), textFont)){HorizontalAlignment = Element.ALIGN_CENTER },
                        new PdfPCell(new Phrase(Context.Server.HtmlDecode(codigo), textFont)){HorizontalAlignment = Element.ALIGN_LEFT },
                        new PdfPCell(new Phrase(Context.Server.HtmlDecode(NombreCadenaValor), textFont)){HorizontalAlignment = Element.ALIGN_CENTER },
                        new PdfPCell(new Phrase(Context.Server.HtmlDecode(NombreMacroproceso), textFont)){HorizontalAlignment = Element.ALIGN_CENTER },
                        new PdfPCell(new Phrase(Context.Server.HtmlDecode(NombreProceso), textFont)){HorizontalAlignment = Element.ALIGN_CENTER },
                        new PdfPCell(new Phrase(Context.Server.HtmlDecode(NombreSubproceso), textFont)){HorizontalAlignment = Element.ALIGN_CENTER },
                        new PdfPCell(new Phrase(Context.Server.HtmlDecode(NombreOrigenNoConformidad), textFont)){HorizontalAlignment = Element.ALIGN_CENTER },
                        new PdfPCell(new Phrase(Context.Server.HtmlDecode(NombreResponsable), textFont)){HorizontalAlignment = Element.ALIGN_CENTER },
                        new PdfPCell(new Phrase(Context.Server.HtmlDecode(NombreEstado), textFont)){HorizontalAlignment = Element.ALIGN_CENTER }
                    };

                        pRows.Add(new PdfPRow(rowTable.ToArray()));
                    }
                    tableActividades.Rows.AddRange(pRows);

                    pRows.Clear();
                }
                #endregion InfoReporte

                Document pdfDocument = new Document(PageSize.LETTER, 0, 0, 10, 30);
                PdfWriter.GetInstance(pdfDocument, Response.OutputStream);
                pdfDocument.AddAuthor("Sherlock");
                pdfDocument.AddCreator("Sherlock");
                pdfDocument.AddCreationDate();
                pdfDocument.AddTitle("Reporte Gestión Acm");

                string pathImg = Server.MapPath("~") + "Imagenes/Logos/logo-sherlock.png";
                Image imagen = Image.GetInstance(pathImg);
                pathImg = Server.MapPath("~") + ConfigurationManager.AppSettings.Get("EmpresaLogo").ToString();
                Image imagenEmpresa = Image.GetInstance(pathImg);
                imagen.BorderWidth = 0;
                imagen.Alignment = Element.ALIGN_RIGHT;
                PdfPTable pdftblImage = new PdfPTable(2);
                PdfPCell pdfcellImage = new PdfPCell(imagen, true)
                {
                    FixedHeight = 40f,
                    Border = Rectangle.NO_BORDER
                };
                pdfcellImage.Border = Rectangle.NO_BORDER;
                pdftblImage.AddCell(pdfcellImage);
                PdfPCell pdfcellImageEmpresa = new PdfPCell(imagenEmpresa, true)
                {
                    FixedHeight = 40f,
                    HorizontalAlignment = Element.ALIGN_RIGHT,
                    VerticalAlignment = Element.ALIGN_RIGHT,
                    Border = Rectangle.NO_BORDER
                };
                pdfcellImageEmpresa.Border = Rectangle.NO_BORDER;
                pdftblImage.AddCell(pdfcellImageEmpresa);
                Phrase phHeader = new Phrase
                {
                    pdftblImage
                };
                pdftblImage.SpacingAfter = 20;
                HeaderFooter header = new HeaderFooter(phHeader, false)
                {
                    Border = Rectangle.NO_BORDER,
                    Alignment = Element.ALIGN_CENTER,
                };
                pdfDocument.Header = header;
                pdfDocument.Open();
                Paragraph Titulo = new Paragraph(new Phrase("Reporte Gestión Acm", titleFont));
                Titulo.SetAlignment("Center");
                pdfDocument.Add(Titulo);
                pdfDocument.Add(Chunk.NEWLINE);
                pdfDocument.Add(Chunk.NEWLINE);

               
                pdfDocument.Add(new Phrase(""));
                pdfDocument.Add(tableActividades);
                pdfDocument.Add(Chunk.NEWLINE);
                pdfDocument.Add(new Phrase(""));


                pdfDocument.Close();
                Response.ContentType = "application/pdf";
                Response.AddHeader("content-disposition", "attachment;filename=Reporte Consolidado Acm.pdf");
                Response.Write(pdfDocument);
                Response.Flush();
                Response.End();
            }
            catch (ThreadAbortException)
            {

            }
            catch (Exception ex)
            {

                omb.ShowMessage($"Error al generar el documento. {ex.Message}", 1, "Atención");
            }
        }

        protected void ImButtonExcelExport_Click(object sender, ImageClickEventArgs e)
        {
            exportExcel(Response, "ReporteAcm_" + System.DateTime.Now.ToString("yyyy-MM-dd"));
        }
        protected void exportExcel(HttpResponse Response, string filename)
        {

            #region TablaEncabezado
            DataTable grid = new DataTable();
            grid.Columns.Add("IdAcm");
            grid.Columns.Add("Codigo");
            grid.Columns.Add("NombreCadenaValor");
            grid.Columns.Add("NombreMacroproceso");
            grid.Columns.Add("NombreProceso");
            grid.Columns.Add("NombreUsuarioRegistra");
            grid.Columns.Add("NombreOrigenNoConformidad");
            grid.Columns.Add("DescripcionNoConformidad");
            
            
           // grid.Columns.Add("NombreResponsable");
            grid.Columns.Add("NombreEstado");
            
            
            DataTable gridDocumentos = new DataTable();
            foreach (TableCell headerCell in gvAcm.HeaderRow.Cells)
            {
                gridDocumentos.Columns.Add(Context.Server.HtmlDecode(headerCell.Text));
            }
            DataRow rowDetalle;
            foreach (TableRow rowGrid in gvAcm.Rows)
            {
                rowDetalle = gridDocumentos.NewRow();
                rowDetalle[0] = Context.Server.HtmlDecode(rowGrid.Cells[0].Text);
                rowDetalle[1] = Context.Server.HtmlDecode(rowGrid.Cells[1].Text);
                rowDetalle[2] = Context.Server.HtmlDecode(rowGrid.Cells[2].Text);
                rowDetalle[3] = Context.Server.HtmlDecode(rowGrid.Cells[3].Text);
                rowDetalle[4] = Context.Server.HtmlDecode(rowGrid.Cells[4].Text);
                rowDetalle[5] = Context.Server.HtmlDecode(rowGrid.Cells[5].Text);
                rowDetalle[6] = Context.Server.HtmlDecode(rowGrid.Cells[6].Text);
                rowDetalle[7] = Context.Server.HtmlDecode(rowGrid.Cells[7].Text);
                
                
                //rowDetalle[8] = Context.Server.HtmlDecode(rowGrid.Cells[8].Text);
                rowDetalle[8] = Context.Server.HtmlDecode(rowGrid.Cells[8].Text);
                gridDocumentos.Rows.Add(rowDetalle);
            }
            #endregion TablaEncabezado


            // Create the workbook
            XLWorkbook workbook = new XLWorkbook();
            //workbook.Worksheets.Add("Sample").Cell(1, 1).SetValue("Hello World");
            //workbook.Worksheets.Add(gridEncabezado, "Indicador");
            workbook.Worksheets.Add(gridDocumentos, "Reporte ACM");
            // Prepare the response
            HttpResponse httpResponse = Response;
            httpResponse.Clear();
            httpResponse.ContentType = "application/vnd.openxmlformats-officedocument.spreadsheetml.sheet";
            httpResponse.AddHeader("content-disposition", "attachment;filename=\"" + filename + ".xlsx\"");
            // Flush the workbook to the Response.OutputStream
            using (MemoryStream memoryStream = new MemoryStream())
            {
                workbook.SaveAs(memoryStream);
                memoryStream.WriteTo(httpResponse.OutputStream);
                memoryStream.Close();
            }

            httpResponse.End();
        }
    }
}