using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Data;

namespace ListasSarlaft.Classes
{
    public class clsNombreFiltroBLL
    {
        public List<clsNombreFiltro> mtdConsultarNombreFiltro(ref string strErrMsg)
        {
            #region Vars
            DataTable dtInfo = new DataTable();
            List<clsNombreFiltro> lstCadenaValor = new List<clsNombreFiltro>();
            clsDtCadenaValor cDtCadenaValor = new clsDtCadenaValor();
            clsNombreFiltro objNombreFiltro = new clsNombreFiltro();
            #endregion Vars

            dtInfo = cDtCadenaValor.mtdConsultarNombreFiltro(ref strErrMsg);

            if (dtInfo != null)
            {
                if (dtInfo.Rows.Count > 0)
                {
                    foreach (DataRow dr in dtInfo.Rows)
                    {
                        objNombreFiltro = new clsNombreFiltro(
                            Convert.ToInt32(dr["UsuarioRegistra"].ToString().Trim()),
                            dr["NombreUsuarioRegistra"].ToString().Trim());
                             lstCadenaValor.Add(objNombreFiltro);
                    }
                }
                else
                {
                    lstCadenaValor = null;
                    strErrMsg = "No hay información de cadenas de valor.";
                }
            }
            else
                lstCadenaValor = null;

            return lstCadenaValor;
        }

    }
}