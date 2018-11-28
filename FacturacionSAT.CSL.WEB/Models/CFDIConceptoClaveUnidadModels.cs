using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FacturacionSAT.CSL.WEB.Models
{
    public class CFDIConceptoClaveUnidadModels
    {
        public CFDIConceptoClaveUnidadModels()
        {
            Id_cfdiClaveUnidadDetalle = string.Empty;
            Nombre = string.Empty;
            C_ClaveUnidad = string.Empty;
            _ListaClaveunidad = new List<CFDIConceptoClaveUnidadModels>();
        }
        public List<CFDIConceptoClaveUnidadModels> _ListaClaveunidad { get; set; }

        
        private string _Id_cfdiClaveUnidadDetalle;

        [Required]
        [Display(Name = "Clave unidad")]
        public string Id_cfdiClaveUnidadDetalle
        {
            get { return _Id_cfdiClaveUnidadDetalle; }
            set { _Id_cfdiClaveUnidadDetalle = value; }
        }

        private string _Nombre;

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

        private string _c_ClaveUnidad;

        public string C_ClaveUnidad
        {
            get { return _c_ClaveUnidad; }
            set { _c_ClaveUnidad = value; }
        }


    }
}