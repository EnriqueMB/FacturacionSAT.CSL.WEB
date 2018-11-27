using System;
using System.Collections.Generic;
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
            _ListaClaveunidad= new List<CFDIConceptoClaveUnidadModels>();
        }
        public List<CFDIConceptoClaveUnidadModels> _ListaClaveunidad { get; set; }


        private string _Id_cfdiClaveUnidadDetalle;

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

    }
}