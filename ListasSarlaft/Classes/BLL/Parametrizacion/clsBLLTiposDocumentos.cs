using ListasSarlaft.Classes.DAL.Parametrizacion;
using ListasSarlaft.Classes.DTO.Parametrizacion;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListasSarlaft.Classes.BLL.Parametrizacion
{
    public class clsBLLTiposDocumentos
    {
        /// <summary>
        /// Realiza la insercion de los campos de los adjuntos para el cierre del ACM
        /// </summary>
        /// <param name="objActividad">Informacion de los Adjuntos</param>
        /// <param name="strErrMsg">Mensaje de error</param>
        /// <returns>Retorna si el proceso fue exitoso o no</returns>
        public bool mtdInsertarTipoDocumento(clsDTOTiposDocumentos objTiposDocs, ref string strErrMsg)
        {
            bool booResult = false;
            clsDALTiposDocumentos dbDocumentos = new clsDALTiposDocumentos();

            booResult = dbDocumentos.mtdInsertarTipoDocumento(objTiposDocs, ref strErrMsg);

            return booResult;
        }
        /// <summary>
        /// Realiza la consulta de  los adjuntos para el cierre del ACM
        /// </summary>
        /// <param name="strErrMsg">Mensaje de error</param>
        /// <returns>Retorna si el proceso fue exitoso o no</returns>
        public List<clsDTOTiposDocumentos> mtdConsultarTiposDocs(ref string strErrMsg)
        {
            try
            {
                clsDALTiposDocumentos objData = new clsDALTiposDocumentos();

                return objData.mtdConsultarTiposDocs(ref strErrMsg);

            }
            catch (Exception ex)
            {
                throw ex;
            }
        }
        /// <summary>
        /// Realiza la insercion de los campos de los adjuntos para el cierre del ACM
        /// </summary>
        /// <param name="objActividad">Informacion de los Adjuntos</param>
        /// <param name="strErrMsg">Mensaje de error</param>
        /// <returns>Retorna si el proceso fue exitoso o no</returns>
        public bool mtdActualizarTipoDocumento(clsDTOTiposDocumentos objTiposDocs, ref string strErrMsg)
        {
            bool booResult = false;
            clsDALTiposDocumentos dbDocumentos = new clsDALTiposDocumentos();

            booResult = dbDocumentos.mtdActualizarTipoDocumento(objTiposDocs, ref strErrMsg);

            return booResult;
        }
        /// <summary>
        /// Realiza la insercion de los campos de los adjuntos para el cierre del ACM
        /// </summary>
        /// <param name="objActividad">Informacion de los Adjuntos</param>
        /// <param name="strErrMsg">Mensaje de error</param>
        /// <returns>Retorna si el proceso fue exitoso o no</returns>
        public bool mtdEliminarTipoDocumento(clsDTOTiposDocumentos objTiposDocs, ref string strErrMsg)
        {
            bool booResult = false;
            clsDALTiposDocumentos dbDocumentos = new clsDALTiposDocumentos();

            booResult = dbDocumentos.mtdEliminarTipoDocumento(objTiposDocs, ref strErrMsg);

            return booResult;
        }
    }
}