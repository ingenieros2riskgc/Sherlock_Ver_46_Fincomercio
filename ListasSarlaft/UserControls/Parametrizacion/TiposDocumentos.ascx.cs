using ListasSarlaft.Classes;
using ListasSarlaft.Classes.BLL.Parametrizacion;
using ListasSarlaft.Classes.DTO.Parametrizacion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Linq;
using System.Reflection;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;

namespace ListasSarlaft.UserControls.Parametrizacion
{
    public partial class TiposDocumentos : System.Web.UI.UserControl
    {
        string IdFormulario = "11009";
        cCuenta cCuenta = new cCuenta();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (string.IsNullOrEmpty(Session["IdUsuario"].ToString().Trim()))
            {
                Response.Redirect("~/Formularios/Sitio/Login.aspx", false);
            }
            else
            {
                if (cCuenta.permisosConsulta(IdFormulario) == "False")
                {
                    Response.Redirect("~/Formularios/Sarlaft/Admin/HomeAdmin.aspx?Denegar=1");
                }
                else
                {
                    if(!Page.IsPostBack)
                    {
                        string strErrMsg = string.Empty;
                        bool flag = mtdLoadTipoDocumentos(ref strErrMsg);
                        txtUsuario.Text = Session["Usuario"].ToString();
                        mtdInicializarValores();
                    }
                }
                
            }
        }
        #region Properties
        private DataTable infoGrid;
        private int rowGrid;
        private int pagIndex;

        private DataTable InfoGrid
        {
            get
            {
                infoGrid = (DataTable)ViewState["infoGrid"];
                return infoGrid;
            }
            set
            {
                infoGrid = value;
                ViewState["infoGrid"] = infoGrid;
            }
        }

        private int RowGrid
        {
            get
            {
                rowGrid = (int)ViewState["rowGrid"];
                return rowGrid;
            }
            set
            {
                rowGrid = value;
                ViewState["rowGrid"] = rowGrid;
            }
        }

        private int PagIndex
        {
            get
            {
                pagIndex = (int)ViewState["pagIndex"];
                return pagIndex;
            }
            set
            {
                pagIndex = value;
                ViewState["pagIndex"] = pagIndex;
            }
        }

        #endregion
        private void mtdInicializarValores()
        {
            PagIndex = 0;
        }
        private void Mensaje(String Mensaje)
        {
            lblMsgBox.Text = Mensaje;
            mpeMsgBox.Show();
        }
        private bool mtdLoadTipoDocumentos(ref string strErrMsg)
        {
            bool booResult = false;
             #region Vars

             clsBLLTiposDocumentos process = new clsBLLTiposDocumentos();
             List<clsDTOTiposDocumentos> lstTiposDocs = new List<clsDTOTiposDocumentos>();

             #endregion Vars
             lstTiposDocs = process.mtdConsultarTiposDocs(ref strErrMsg);

             if (lstTiposDocs != null)
             {

                mtdLoadTipoDocumentos();
                 mtdLoadTipoDocumentos(lstTiposDocs);
                gvTiposDocumentos.DataSource = InfoGrid;
                gvTiposDocumentos.PageIndex = pagIndex;
                gvTiposDocumentos.DataBind();
                 
                 booResult = true;
                 //BodyGridRCI.Visible = true;
                 //Dbutton.Visible = true;
             }

            return booResult;
        }
        /// <summary>
        /// Carga la informacion de las columnas del grid
        /// </summary>
        private void mtdLoadTipoDocumentos()
        {
            DataTable grid = new DataTable();

            grid.Columns.Add("intIdTiposDocumento", typeof(int));
            grid.Columns.Add("strNombreDocumento", typeof(string));
            grid.Columns.Add("strDescripcionDocumento", typeof(string));
            grid.Columns.Add("booEstado", typeof(string));



            gvTiposDocumentos.DataSource = grid;
            gvTiposDocumentos.DataBind();
            
            InfoGrid = grid;
        }
        /// <summary>
        /// Realiza la carga de informacion en un datagrid.
        /// </summary>
        /// <param name="lstMacroproceso">Lista con los Indicadores</param>
        private void mtdLoadTipoDocumentos(List<clsDTOTiposDocumentos> lstTiposDocs)
        {
            string strErrMsg = String.Empty;

            foreach (clsDTOTiposDocumentos objTiposDocs in lstTiposDocs)
            {
                string estado = objTiposDocs.booEstado == true ? "Activo" : "Inactivo";
                InfoGrid.Rows.Add(new Object[] {
                   objTiposDocs.intIdTiposDocumento,
                   objTiposDocs.strNombreDocumento.ToString(),
                   objTiposDocs.strDescripcionDocumento.ToString(),
                   estado
                    });
            }
        }

        protected void imgBtnInsertar_Click(object sender, ImageClickEventArgs e)
        {
            filaGrid.Visible = false;
            filaDetalle.Visible = true;
            btnImgInsertar.Visible = true;
            btnImgActualizar.Visible = false;
        }

        protected void btnImgInsertar_Click(object sender, ImageClickEventArgs e)
        {
            string strErrMsg = string.Empty;
            clsDTOTiposDocumentos objTiposDocs = new clsDTOTiposDocumentos();
            clsBLLTiposDocumentos process = new clsBLLTiposDocumentos();
            objTiposDocs.strNombreDocumento = txtNombreDocumento.Text;
            objTiposDocs.strDescripcionDocumento = txtDescripcion.Text;
            objTiposDocs.booEstado = ddlEstado.SelectedValue == "1" ? true : false;
            //objTiposDocs.booEstado = Convert.ToBoolean(ddlEstado.SelectedValue);

            bool flag = process.mtdInsertarTipoDocumento(objTiposDocs, ref strErrMsg);
            if (strErrMsg == string.Empty)
                Mensaje("Exito! Tipo de documento registrado satisfactoriamente");
            else
                Mensaje("Error! no se ha podido registrar: " + strErrMsg);
            mtdCleanFields();
            mtdLoadTipoDocumentos(ref strErrMsg);
            filaDetalle.Visible = false;
            filaGrid.Visible = true;
        }

        protected void gvTiposDocumentos_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            RowGrid = Convert.ToInt16(e.CommandArgument);
            switch (e.CommandName)
            {
                case "Select":
                    mtdShowUpdate(RowGrid);
                    btnImgInsertar.Visible = false;
                    btnImgActualizar.Visible = true;
                    filaDetalle.Visible = true;
                    filaGrid.Visible = false;
                    //fin
                    break;
                case "Eliminar":
                    GridViewRow row = gvTiposDocumentos.Rows[RowGrid];
                    var colsNoVisible = gvTiposDocumentos.DataKeys[RowGrid].Values;
                    foreach (DataRow drRow in InfoGrid.Rows)
                    {
                        if (colsNoVisible[0].ToString() == drRow["intIdTiposDocumento"].ToString())
                            txtId.Text = drRow["intIdTiposDocumento"].ToString();
                    }
                    
                    btnImgokEliminar.Visible = true;
                    Mensaje("¿Desa eliminar el registro?");
                    break;
            }
        }
        private void mtdShowUpdate(int RowGrid)
        {
            string strErrMsg = string.Empty;
            GridViewRow row = gvTiposDocumentos.Rows[RowGrid];
            var colsNoVisible = gvTiposDocumentos.DataKeys[RowGrid].Values;
            clsDTOTiposDocumentos  objTipoDocs = new clsDTOTiposDocumentos();
            foreach(DataRow drRow in InfoGrid.Rows)
            {
                if(colsNoVisible[0].ToString() == drRow["intIdTiposDocumento"].ToString())
                {
                    txtId.Text = drRow["intIdTiposDocumento"].ToString();
                    txtNombreDocumento.Text = drRow["strNombreDocumento"].ToString();
                    txtDescripcion.Text = drRow["strDescripcionDocumento"].ToString();
                    ddlEstado.SelectedIndex = drRow["booEstado"].ToString() == "Activo" ? 2 : 1;
                }
            }
             
        }

        protected void btnImgActualizar_Click(object sender, ImageClickEventArgs e)
        {
            string strErrMsg = string.Empty;
            clsDTOTiposDocumentos objTiposDocs = new clsDTOTiposDocumentos();
            clsBLLTiposDocumentos process = new clsBLLTiposDocumentos();
            objTiposDocs.intIdTiposDocumento = Convert.ToInt32(txtId.Text);
            objTiposDocs.strNombreDocumento = txtNombreDocumento.Text;
            objTiposDocs.strDescripcionDocumento = txtDescripcion.Text;
            objTiposDocs.booEstado = ddlEstado.SelectedValue == "1" ? true : false;
            //objTiposDocs.booEstado = Convert.ToBoolean(ddlEstado.SelectedValue);

            bool flag = process.mtdActualizarTipoDocumento(objTiposDocs, ref strErrMsg);
            if (strErrMsg == string.Empty)
                Mensaje("Exito! Tipo de documento actualizado satisfactoriamente");
            else
                Mensaje("Error! no se ha podido actualizar: " + strErrMsg);
            mtdCleanFields();
            mtdLoadTipoDocumentos(ref strErrMsg);
            filaDetalle.Visible = false;
            filaGrid.Visible = true;
        }

        protected void btnImgokEliminar_Click(object sender, EventArgs e)
        {
            string strErrMsg = string.Empty;
            clsDTOTiposDocumentos objTiposDocs = new clsDTOTiposDocumentos();
            clsBLLTiposDocumentos process = new clsBLLTiposDocumentos();
            objTiposDocs.intIdTiposDocumento = Convert.ToInt32(txtId.Text);

            bool flag = process.mtdEliminarTipoDocumento(objTiposDocs, ref strErrMsg);
            btnImgokEliminar.Visible = false;
            if (strErrMsg == string.Empty)
                Mensaje("Exito! Tipo de documento eliminado satisfactoriamente");
            else
                Mensaje("Error! no se ha podido eliminar: " + strErrMsg);
            mtdCleanFields();
            mtdLoadTipoDocumentos(ref strErrMsg);
            filaDetalle.Visible = false;
            filaGrid.Visible = true;
        }
        protected void mtdCleanFields()
        {
            txtId.Text = string.Empty;
            txtNombreDocumento.Text = string.Empty;
            txtDescripcion.Text = string.Empty;
            ddlEstado.ClearSelection();
        }

        protected void gvTiposDocumentos_PageIndexChanging(object sender, GridViewPageEventArgs e)
        {
            PagIndex = e.NewPageIndex;
            gvTiposDocumentos.PageIndex = PagIndex;
            gvTiposDocumentos.DataBind();
        }
    }
}