using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FacturacionSAT.CSL.WEB.Models
{
    public class CFDIConceptosClaveProductoModels
    {
        public CFDIConceptosClaveProductoModels()
        {
            Id_cfdiClaveProdServDetalle = string.Empty;
            Descripcion = string.Empty;
            __ListaClaveProducto = new List<CFDIConceptosClaveProductoModels>();
        }

        public List<CFDIConceptosClaveProductoModels> __ListaClaveProducto { get; set; }

        private string _Id_cfdiClaveProdServDetalle;
        [Required]
        [Display (Name ="Clave producto")]
        public string Id_cfdiClaveProdServDetalle
        {
            get { return _Id_cfdiClaveProdServDetalle; }
            set { _Id_cfdiClaveProdServDetalle = value; }
        }
        private string _Descripcion;

        public string Descripcion
        {
            get { return _Descripcion; }
            set { _Descripcion = value; }
        }


    }
}