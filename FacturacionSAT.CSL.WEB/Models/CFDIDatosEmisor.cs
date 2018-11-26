using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacturacionSAT.CSL.WEB.Models
{
    public class CFDIDatosEmisor
    {
        public CFDIDatosEmisor()
        {

        }

        private string _IDCFDIDatosEmisor;

        public string IDCFDIDatosEmisor
        {
            get { return _IDCFDIDatosEmisor; }
            set { _IDCFDIDatosEmisor = value; }
        }

        private string _IDCFDITipoPersona;

        public string IDCFDITipoPersona
        {
            get { return _IDCFDITipoPersona; }
            set { _IDCFDITipoPersona = value; }
        }

        private string _RazonSocial;

        public string RazonSocial
        {
            get { return _RazonSocial; }
            set { _RazonSocial = value; }
        }

        private string _RFC;

        public string RFC
        {
            get { return _RFC; }
            set { _RFC = value; }
        }

        private string _IDCFDIRegimenFiscalDetalle;

        public string IDCFDIReqgimenFiscalDetalle
        {
            get { return _IDCFDIRegimenFiscalDetalle; }
            set { _IDCFDIRegimenFiscalDetalle = value; }
        }

        private string _Direccion;

        public string Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }

        private string _CodigoPostal;

        public string CodigoPostal
        {
            get { return _CodigoPostal; }
            set { _CodigoPostal = value; }
        }

        private bool _Predeterminado;

        public bool Predeterminado
        {
            get { return _Predeterminado; }
            set { _Predeterminado = value; }
        }

        private string _Correo;

        public string Correo
        {
            get { return _Correo; }
            set { _Correo = value; }
        }

        private string _Password;

        public string Password
        {
            get { return _Password; }
            set { _Password = value; }
        }

        private string _URLArchivoCER;

        public string URLArchivoCER
        {
            get { return _URLArchivoCER; }
            set { _URLArchivoCER = value; }
        }

        private string _URLArchivoKEY;

        public string URLArchivoKEY
        {
            get { return _URLArchivoKEY; }
            set { _URLArchivoKEY = value; }
        }

        private string _PasswordArchivoKEY;

        public string PasswordArchivoKEY
        {
            get { return _PasswordArchivoKEY; }
            set { _PasswordArchivoKEY = value; }
        }

        private string _Imagen;

        public string Imagen
        {
            get { return _Imagen; }
            set { _Imagen = value; }
        }

        private CFDITipoPersonaModels _CFDITipoPersona;

        public CFDITipoPersonaModels CFDITipoPersona
        {
            get { return _CFDITipoPersona; }
            set { _CFDITipoPersona = value; }
        }


        public string Conexion { get; set; }
        public int Resultado { get; set; }
        public int Opcion { get; set; }
        public string IDUsuario { get; set; }
    }
}