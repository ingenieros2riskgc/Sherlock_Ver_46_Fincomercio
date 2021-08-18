using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace ListasSarlaft.Classes.DTO.Parametrizacion
{
    public class clsDTOTiposDocumentos
    {
        private int _IdTiposDocumento;
        private string _NombreDocumento;
        private string _DescripcionDocumento;
        private bool _Estado;
        

        public int intIdTiposDocumento
        {
            get { return _IdTiposDocumento; }
            set { _IdTiposDocumento = value; }
        }
        public string strNombreDocumento
        {
            get { return _NombreDocumento; }
            set { _NombreDocumento = value; }
        }
        public string strDescripcionDocumento
        {
            get { return _DescripcionDocumento; }
            set { _DescripcionDocumento = value; }
        }
        public Boolean booEstado
        {
            get { return _Estado; }
            set { _Estado = value; }
        }
        
        #region Construtors
        public clsDTOTiposDocumentos()
        {
        }

        public clsDTOTiposDocumentos(int intIdTiposDocumento, string strNombreDocumento, string strDescripcionDocumento, Boolean booEstado)
        {
            this.intIdTiposDocumento = intIdTiposDocumento;
            this.strNombreDocumento = strNombreDocumento;
            this.strDescripcionDocumento = strDescripcionDocumento;
            this.booEstado = booEstado;
            
        }
        #endregion
    }
}