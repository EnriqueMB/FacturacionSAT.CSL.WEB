using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FacturacionSAT.CSL.WEB.Models
{
    public class CFDIFormaPagoDetalleModels
    {
        public CFDIFormaPagoDetalleModels()
        {
            Id_cfdiFormaPagoDetalle = string.Empty;
            Descripcion = string.Empty;           
        }

        private string _Id_cfdiFormaPagoDetalle;

        [Required(AllowEmptyStrings = false)]
        [Display(Name = "Metodo de Pago")]
        public string Id_cfdiFormaPagoDetalle
        {
            get { return _Id_cfdiFormaPagoDetalle; }
            set { _Id_cfdiFormaPagoDetalle = value; }
        }

        private string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }     

    }
}