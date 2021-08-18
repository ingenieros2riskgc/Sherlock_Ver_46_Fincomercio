using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;

namespace ListasSarlaft.Classes
{
    public class clsNombreFiltro
    {
        private int _UsuarioRegistra;
        private string _NombreUsuarioRegistra;


        public int UsuarioRegistra
        {
            get { return _UsuarioRegistra; }
            set { _UsuarioRegistra = value; }
        }

        public string NombreUsuarioRegistra
        {
            get { return _NombreUsuarioRegistra; }
            set { _NombreUsuarioRegistra = value; }
        }

        #region Constructors
        public clsNombreFiltro()
        {
        }

        public clsNombreFiltro(int UsuarioRegistra, string NombreUsuarioRegistra)
        {
            this.UsuarioRegistra = UsuarioRegistra;
            this.NombreUsuarioRegistra = NombreUsuarioRegistra;
        }
        #endregion
    }
}