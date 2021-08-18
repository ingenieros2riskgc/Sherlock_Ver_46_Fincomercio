using ListasSarlaft.Classes.DTO.Parametrizacion;
using System;
using System.Collections.Generic;
using System.Data;
using System.Data.SqlClient;
using System.Linq;
using System.Web;

namespace ListasSarlaft.Classes.DAL.Parametrizacion
{
    public class clsDALTiposDocumentos
    {
        public bool mtdInsertarTipoDocumento(clsDTOTiposDocumentos objTiposDocs, ref string strErrMsg)
        {
            #region Vars
            bool booResult = false;
            string strConsulta = string.Empty;
            DataTable dtInfo = new DataTable();
            cDataBase cDatabase = new cDataBase();
            clsActividad objLastAct = null;
            #endregion Vars
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>()
                {
                            new SqlParameter() { ParameterName = "@NombreDocumento", SqlDbType = SqlDbType.VarChar, Value = objTiposDocs.strNombreDocumento },
                            new SqlParameter() { ParameterName = "@DescripcionDocumento", SqlDbType = SqlDbType.VarChar, Value = objTiposDocs.strDescripcionDocumento },
                };
                cDatabase.EjecutarSPParametros("Parametrizacion.InsTiposDocumentos", parametros);
                booResult = true;
            }
            catch (Exception ex)
            {
                booResult = false;
                strErrMsg = "Error en el proceso: " + ex.Message;
            }
            return booResult;
        }
        /// <summary>
        /// Realiza la consulta para traer los archivos adjuntos
        /// </summary>
        /// <param name="strErrMsg">Mensaje de error</param>
        /// <returns>Tabla de datos con la informacion.</returns>
        public List<clsDTOTiposDocumentos> mtdConsultarTiposDocs(ref string strErrMsg)
        {
            List<clsDTOTiposDocumentos> lst = new List<clsDTOTiposDocumentos>();
            try
            {
                cDataBase cDatabase = new cDataBase();
                
                using (DataTable dt = cDatabase.ejecutarConsulta("exec Parametrizacion.SelTiposDocumentos"))
                {

                    if (dt != null && dt.Rows.Count > 0)
                    {
                        foreach (DataRow Row in dt.Rows)
                        {
                            lst.Add(new clsDTOTiposDocumentos()
                            {
                                intIdTiposDocumento = Convert.ToInt32(Row["IdTiposDocumento"].ToString()),
                                strNombreDocumento = Row["NombreDocumento"].ToString(),
                                strDescripcionDocumento = Row["DescripcionDocumento"].ToString(),
                                booEstado = Convert.ToBoolean( Row["Estado"].ToString())
                            });
                        }
                    }
                    //return lst;
                }
            }
            catch (Exception ex)
            {
                strErrMsg = "Error en la consulta: " + ex.Message;
            }
            return lst;
        }
        public bool mtdActualizarTipoDocumento(clsDTOTiposDocumentos objTiposDocs, ref string strErrMsg)
        {
            #region Vars
            bool booResult = false;
            string strConsulta = string.Empty;
            DataTable dtInfo = new DataTable();
            cDataBase cDatabase = new cDataBase();
            clsActividad objLastAct = null;
            #endregion Vars
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>()
                {
                            new SqlParameter() { ParameterName = "@NombreDocumento", SqlDbType = SqlDbType.VarChar, Value = objTiposDocs.strNombreDocumento },
                            new SqlParameter() { ParameterName = "@DescripcionDocumento", SqlDbType = SqlDbType.VarChar, Value = objTiposDocs.strDescripcionDocumento },
                            new SqlParameter() { ParameterName = "@Estado", SqlDbType = SqlDbType.Bit, Value = objTiposDocs.booEstado },
                            new SqlParameter() { ParameterName = "@IdTiposDocumento", SqlDbType = SqlDbType.Int, Value = objTiposDocs.intIdTiposDocumento },
                };
                cDatabase.EjecutarSPParametros("Parametrizacion.UpsTiposDocumentos", parametros);
                booResult = true;
            }
            catch (Exception ex)
            {
                booResult = false;
                strErrMsg = "Error en el proceso: " + ex.Message;
            }
            return booResult;
        }
        public bool mtdEliminarTipoDocumento(clsDTOTiposDocumentos objTiposDocs, ref string strErrMsg)
        {
            #region Vars
            bool booResult = false;
            string strConsulta = string.Empty;
            DataTable dtInfo = new DataTable();
            cDataBase cDatabase = new cDataBase();
            clsActividad objLastAct = null;
            #endregion Vars
            try
            {
                List<SqlParameter> parametros = new List<SqlParameter>()
                {
                            new SqlParameter() { ParameterName = "@IdTiposDocumento", SqlDbType = SqlDbType.Int, Value = objTiposDocs.intIdTiposDocumento },
                };
                cDatabase.EjecutarSPParametros("Parametrizacion.DelTiposDocumentos", parametros);
                booResult = true;
            }
            catch (Exception ex)
            {
                booResult = false;
                strErrMsg = "Error en el proceso: " + ex.Message;
            }
            return booResult;
        }
    }
}