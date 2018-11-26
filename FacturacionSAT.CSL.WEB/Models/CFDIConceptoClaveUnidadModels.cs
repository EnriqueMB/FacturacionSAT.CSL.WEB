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
            Id_cfdiClaveUnidad = string.Empty;
            Nombre = string.Empty;
            _ListaClaveunidad= new List<CFDIConceptoClaveUnidadModels>();
        }
        public List<CFDIConceptoClaveUnidadModels> _ListaClaveunidad { get; set; }
        private string _Id_cfdiClaveUnidad;

        public string Id_cfdiClaveUnidad
        {
            get { return _Id_cfdiClaveUnidad; }
            set { _Id_cfdiClaveUnidad = value; }
        }
        private string _Nombre;

        public string Nombre
        {
            get { return _Nombre; }
            set { _Nombre = value; }
        }

    }
}