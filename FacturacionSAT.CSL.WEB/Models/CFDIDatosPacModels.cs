using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FacturacionSAT.CSL.WEB.Models
{
    public class CFDIDatosPacModels
    {
        public CFDIDatosPacModels()
        {
            Opcion = 0;
            Id_cfdiDatosPac = string.Empty;
            Descripcion = string.Empty;
            UserPac = string.Empty;
            PasswordPac = string.Empty;
            UserPacTest = string.Empty;
            PasswordPacTest = string.Empty;
            Predeterminado = false;
            Completado = false;
            this.Conexion = string.Empty;
            this.ListaCFDIPac = new List<CFDIDatosPacModels>();
            Id_usuario = string.Empty;
        }

        public string Id_usuario { get; set; }

        private int _Opcion;
        public int Opcion
        {
            get { return _Opcion; }
            set { _Opcion = value; }
        }

        private string _Id_cfdiDatosPac;
        public string Id_cfdiDatosPac
        {
            get { return _Id_cfdiDatosPac; }
            set { _Id_cfdiDatosPac = value; }
        }

        private string _Descripcion;
        [Required(ErrorMessage = "La Descripcion es requerida")]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y Números")]
        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }

        private string _UserPac;
        [Required(ErrorMessage = "El campo UserPac es requerido")]
        [RegularExpression(@"^[A-Za-záéíóúñÁÉÍÓÚÑ0-9\(\)\-\,\.\;\:\s]*$", ErrorMessage = "Solo Letras y Números")]
        public string UserPac
        {
            get { return _UserPac; }
            set { _UserPac = value; }
        }

        private string _PasswordPac;
        [Required(ErrorMessage = "La Campo PasswordPac es requerida")]
        [DataType(DataType.Password)]
        [StringLength(25, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y un maximo de {1}.", MinimumLength = 1)]        
        public string PasswordPac
        {
            get { return _PasswordPac; }
            set { _PasswordPac = value; }
        }

        private string _UserPacTest;
        [Required(ErrorMessage = "El campo UserPacTest es requerido")]
        public string UserPacTest
        {
            get { return _UserPacTest; }
            set { _UserPacTest = value; }
        }

        private string _PasswordPacTest;
        [Required(ErrorMessage = "La Campo PasswordPacTest es requerida")]
        [DataType(DataType.Password)]
        [StringLength(25, ErrorMessage = "El número de caracteres de {0} debe ser al menos {2} y un maximo de {1}.", MinimumLength = 1)]
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

        private List<CFDIDatosPacModels> _ListaCFDIPac;
        public List<CFDIDatosPacModels> ListaCFDIPac
        {
            get { return _ListaCFDIPac; }
            set { _ListaCFDIPac = value; }
        }

        public string Conexion { get; set; }
        public bool Completado { get; set; }
    }
}