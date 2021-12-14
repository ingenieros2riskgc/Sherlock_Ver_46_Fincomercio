using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Web.UI;
using System.Web.UI.WebControls;
using System.Text;
using System.Text.RegularExpressions;
using ListasSarlaft.Classes;
using Microsoft.Security.Application;

namespace ListasSarlaft.UserControls.Eventos
{
    public partial class ClasificacionN3 : System.Web.UI.UserControl
    {
        string IdFormulario = "5010";
        cCuenta cCuenta = new cCuenta();
        protected void Page_Load(object sender, EventArgs e)
        {
            if (cCuenta.permisosConsulta(IdFormulario) == "False")
                Response.Redirect("~/Formularios/Sarlaft/Admin/HomeAdmin.aspx?Denegar=1");
        }
        #region GridView
        protected void gvClasificaciones_SelectedIndexChanged(object sender, EventArgs e)
        {
            if (gvClasificaciones.SelectedRow.RowType == DataControlRowType.DataRow)
            {
                txtId.Enabled = false;
                txtNombre.Focus();
                btnImgInsertar.Visible = false;
                btnImgActualizar.Visible = true;
                filaGrid.Visible = false;
                filaDetalle.Visible = true;

                // Carga los datos en la respectiva caja de texto
                txtId.Text = gvClasificaciones.SelectedRow.Cells[0].Text.Trim();
                txtNombre.Text = gvClasificaciones.SelectedRow.Cells[1].Text.Trim();
                txtDescripcion.Text = gvClasificaciones.SelectedRow.Cells[2].Text.Trim();
                txtUsuario.Text = gvClasificaciones.SelectedDataKey[1].ToString().Trim();
                txtFecha.Text = gvClasificaciones.SelectedRow.Cells[4].Text.Trim();
            }
        }

        protected void gvClasificaciones_RowCommand(object sender, GridViewCommandEventArgs e)
        {
            int nroPag, tamPag;

            try
            {
                if (e.CommandName == "Eliminar")
                {
                    // Convierte el indice de la fila del GridView almacenado en la propiedad CommandArgument a un tipo entero
                    int index = Convert.ToInt32((e.CommandArgument).ToString());

                    nroPag = gvClasificaciones.PageIndex;  // Obtiene el Numero de Pagina en la que se encuentra el GridView
                    tamPag = gvClasificaciones.PageSize; // Obtiene el Tamano de cada Pagina del GridView

                    index = (index - tamPag * nroPag); // Calcula el Numero de Fila del GridView dentro de la pagina actual

                    // Recupera la fila que contiene el boton al que se le hizo click por el usuario de la coleccion Rows
                    GridViewRow row = gvClasificaciones.Rows[index];

                    // Obtiene el Id del registro a Eliminar
                    txtId.Text = row.Cells[0].Text.Trim();
                }
            }
            catch (Exception except)
            {
                // Handle the Exception.
                omb.ShowMessage("Error" + "<br/>" + "Descripción: " + except.Message.ToString().Trim(), 1, "Atención");
            }
        }
        #endregion GridView
        #region Buttons
        protected void btnImgCancelar_Click(object sender, ImageClickEventArgs e)
        {
            filaGrid.Visible = true;
            filaDetalle.Visible = false;
        }

        protected void btnImgEliminar_Click(object sender, ImageClickEventArgs e)
        {
            if (cCuenta.permisosBorrar(IdFormulario) == "False")
            {
                omb.ShowMessage("No tiene los permisos suficientes para llevar a cabo esta acción.", 2, "Atención");
            }
            else
            {
                lblMsgBox.Text = "Desea eliminar la información de la Base de Datos?";
                mpeMsgBox.Show();
            }
        }

        protected void btnImgokEliminar_Click(object sender, EventArgs e)
        {
            mpeMsgBox.Hide();

            try
            {
                sdsClasificacionN3.DeleteParameters["Id"].DefaultValue = Sanitizer.GetSafeHtmlFragment(txtId.Text.Trim());
                sdsClasificacionN3.Delete();
                omb.ShowMessage("La información se eliminó con éxito en la Base de Datos.", 3, "Atención");
            }
            catch (Exception except)
            {
                omb.ShowMessage("Error en la eliminación de la información." + "<br/>" + "Descripción: " + except.Message.ToString().Trim(), 1, "Atención");
            }
        }

        protected void imgBtnInsertar_Click(object sender, ImageClickEventArgs e)
        {
            if (cCuenta.permisosAgregar(IdFormulario) == "False")
            {
                omb.ShowMessage("No tiene los permisos suficientes para llevar a cabo esta acción.", 2, "Atención");
            }
            else
            {
                txtId.Text = "";
                txtId.Enabled = false;
                txtNombre.Focus();
                txtFecha.Text = System.DateTime.Now.ToString("dd/MM/yyyy");
                txtNombre.Text = "";
                txtDescripcion.Text = "";
                txtUsuario.Text = Session["loginUsuario"].ToString().Trim(); // Aca va el Codigo de Usuario logueado en la aplicacion
                btnImgInsertar.Visible = true;
                btnImgActualizar.Visible = false;
                filaDetalle.Visible = true;
                filaGrid.Visible = false;
            }
        }

        protected void btnImgActualizar_Click(object sender, ImageClickEventArgs e)
        {
            if (cCuenta.permisosActualizar(IdFormulario) == "False")
            {
                omb.ShowMessage("No tiene los permisos suficientes para llevar a cabo esta acción.", 2, "Atención");
            }
            else
            {
                try
                {
                    sdsClasificacionN3.UpdateParameters["Id"].DefaultValue = Sanitizer.GetSafeHtmlFragment(txtId.Text.Trim());
                    sdsClasificacionN3.UpdateParameters["Nombre"].DefaultValue = Sanitizer.GetSafeHtmlFragment(txtNombre.Text.Trim());
                    sdsClasificacionN3.UpdateParameters["Descripcion"].DefaultValue = Sanitizer.GetSafeHtmlFragment(txtDescripcion.Text.Trim());

                    sdsClasificacionN3.Update();

                    omb.ShowMessage("La información se actualizó con éxito en la Base de Datos.", 3, "Atención");

                    filaDetalle.Visible = false;
                    filaGrid.Visible = true;
                }
                catch (Exception except)
                {
                    omb.ShowMessage("Error en la actualización de la información." + "<br/>" + "Descripción: " + except.Message.ToString().Trim(), 1, "Atención");
                }
            }
        }

        protected void btnImgInsertar_Click(object sender, ImageClickEventArgs e)
        {
            //Inserta el maestro del nodo hijo
            try
            {
                sdsClasificacionN3.InsertParameters["Nombre"].DefaultValue = Sanitizer.GetSafeHtmlFragment(txtNombre.Text.Trim());
                sdsClasificacionN3.InsertParameters["Descripcion"].DefaultValue = Sanitizer.GetSafeHtmlFragment(txtDescripcion.Text.Trim());
                sdsClasificacionN3.InsertParameters["IdUsuario"].DefaultValue = Session["idUsuario"].ToString().Trim(); //Aca va el id del Usuario de la BD
                ///sdsClasificacionN3.InsertParameters["FechaRegistro"].DefaultValue = System.DateTime.Now.ToString().Trim();
                sdsClasificacionN3.Insert();

                omb.ShowMessage("La información se insertó con éxito en la Base de Datos.", 3, "Atención");

                filaDetalle.Visible = false;
                filaGrid.Visible = true;
            }
            catch (Exception except)
            {
                // Handle the Exception.
                omb.ShowMessage("Error en la inserción de la información." + "<br/>" + "Descripción: " + except.Message.ToString().Trim(), 1, "Atención");
            }
        }
        #endregion
    }
}