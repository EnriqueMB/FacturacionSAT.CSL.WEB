using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacturacionSAT.CSL.WEB.Models
{
    public class CFDIDatosPacModels
    {
        public CFDIDatosPacModels()
        {
            Id_cfdiDatosPac = 0;
            Descripcion = string.Empty;
            UserPac = string.Empty;
            PasswordPac = string.Empty;
            UserPacTest = string.Empty;
            PasswordPacTest = string.Empty;
            Predeterminado = false;
        }

        private int _Id_cfdiDatosPac;
        public int Id_cfdiDatosPac
        {
            get { return _Id_cfdiDatosPac; }
            set { _Id_cfdiDatosPac = value; }
        }

        private string _Descripcion;
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private string _UserPac;
        public string UserPac
        {
            get { return _UserPac; }
            set { _UserPac = value; }
        }

        private string _PasswordPac;
        public string PasswordPac
        {
            get { return _PasswordPac; }
            set { _PasswordPac = value; }
        }

        private string _UserPacTest;
        public string UserPacTest
        {
            get { return _UserPacTest; }
            set { _UserPacTest = value; }
        }

        private string _PasswordPacTest;
        public string PasswordPacTest
        {
            get { return _PasswordPacTest; }
            set { _PasswordPacTest = value; }
        }

        private bool _Predeterminado;
        public bool Predeterminado
        {
            get { return _Predeterminado; }
            set { _Predeterminado = value; }
        }
    }
}