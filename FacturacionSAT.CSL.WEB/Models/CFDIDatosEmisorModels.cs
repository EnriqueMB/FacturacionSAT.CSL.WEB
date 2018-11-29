using FacturacionSAT.CSL.WEB.Models.Validaciones;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FacturacionSAT.CSL.WEB.Models
{
    public class CFDIDatosEmisorModels
    {
        public CFDIDatosEmisorModels()
        {
            _IDCFDIDatosEmisor = string.Empty;
            _IDCFDIRegimenFiscalDetalle = string.Empty;
            _IDCFDITipoPersona = string.Empty;
            _RazonSocial = string.Empty;
            _RFC = string.Empty;
            _Direccion = string.Empty;
            _CodigoPostal = string.Empty;
            _Correo = string.Empty;
            _Password = string.Empty;
            _URLArchivoCER = string.Empty;
            _URLArchivoKEY = string.Empty;
            _Imagen = string.Empty;
            _PasswordArchivoKEY = string.Empty;
            _CFDITipoPersona = new CFDITipoPersonaModels();
            _ListaDatosEmisor = new List<CFDIDatosEmisorModels>();
            _CFDIRegimenFiscalDetalle = new CFDIRegimenFiscalDetalleModels();
            ListaTipoPersona = new List<CFDITipoPersonaModels>();
            ListaRegimenFiscalDetalle = new List<CFDIRegimenFiscalDetalleModels>();
        }

        private string _IDCFDIDatosEmisor;
        
        public string IDCFDIDatosEmisor
        {
            get { return _IDCFDIDatosEmisor; }
            set { _IDCFDIDatosEmisor = value; }
        }

        private string _IDCFDITipoPersona;
        [Required(AllowEmptyStrings = false, ErrorMessage = "Seleccione un tipo de persona.")]
        public string IDCFDITipoPersona
        {
            get { return _IDCFDITipoPersona; }
            set { _IDCFDITipoPersona = value; }
        }

        private string _RazonSocial;
        [Required(ErrorMessage = "Ingrese la razón social")]
        [Display(Name = "Razón Social")]
        [StringLength(350, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y un maximo de {1}.", MinimumLength = 1)]
        [Texto(ErrorMessage = "Solo Letras y número")]
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
        [Required(AllowEmptyStrings = false, ErrorMessage = "Seleccione un regimen fiscal.")]
        public string IDCFDIRegimenFiscalDetalle
        {
            get { return _IDCFDIRegimenFiscalDetalle; }
            set { _IDCFDIRegimenFiscalDetalle = value; }
        }

        private string _Direccion;
        [Required(ErrorMessage = "Ingrese la dirección")]
        [Display(Name = "Dirección")]
        [StringLength(350, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y un maximo de {1}.", MinimumLength = 1)]
        [Direccion(ErrorMessage = "Solo Letras y número")]
        public string Direccion
        {
            get { return _Direccion; }
            set { _Direccion = value; }
        }

        private string _CodigoPostal;
        [Required(ErrorMessage = "Ingrese el código postal")]
        [Display(Name = "Código Postal")]
        [StringLength(5, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y un maximo de {1}.", MinimumLength = 1)]
        [Texto(ErrorMessage = "Solo Letras y número")]
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
        [Required(ErrorMessage = "Ingrese el correo electrónico")]
        [Display(Name = "Correo Electrónico")]
        [StringLength(100, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y un maximo de {1}.", MinimumLength = 1)]
        //[Correo(ErrorMessage = "Solo Letras y número")]
        public string Correo
        {
            get { return _Correo; }
            set { _Correo = value; }
        }

        private string _Password;
        [Required(ErrorMessage = "Ingrese el password del correo electrónico")]
        [Display(Name = "Password Correo Electrónico")]
        [StringLength(35, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y un maximo de {1}.", MinimumLength = 1)]
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
        [Required(ErrorMessage = "Ingrese el password del archivo KEY")]
        [Display(Name = "Password archivo KEY")]
        [StringLength(35, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y un maximo de {1}.", MinimumLength = 1)]
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

        private CFDIRegimenFiscalDetalleModels _CFDIRegimenFiscalDetalle;

        public CFDIRegimenFiscalDetalleModels CFDIRegimenFiscalDetalle
        {
            get { return _CFDIRegimenFiscalDetalle; }
            set { _CFDIRegimenFiscalDetalle = value; }
        }

        private List<CFDIDatosEmisorModels> _ListaDatosEmisor;

        public List<CFDIDatosEmisorModels> ListaDatosEmisor
        {
            get { return _ListaDatosEmisor; }
            set { _ListaDatosEmisor = value; }
        }

        private List<CFDITipoPersonaModels> _ListaTipoPersona;

        public List<CFDITipoPersonaModels> ListaTipoPersona
        {
            get { return _ListaTipoPersona; }
            set { _ListaTipoPersona = value; }
        }

        private List<CFDIRegimenFiscalDetalleModels> _ListaRegimenFiscalDetalle;

        public List<CFDIRegimenFiscalDetalleModels> ListaRegimenFiscalDetalle
        {
            get { return _ListaRegimenFiscalDetalle; }
            set { _ListaRegimenFiscalDetalle = value; }
        }



        public string Conexion { get; set; }
        public int Resultado { get; set; }
        public int Opcion { get; set; }
        public string IDUsuario { get; set; }
    }
}