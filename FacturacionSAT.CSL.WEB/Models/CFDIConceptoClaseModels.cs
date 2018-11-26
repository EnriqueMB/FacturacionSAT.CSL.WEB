using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacturacionSAT.CSL.WEB.Models
{
    public class CFDIConceptoClaseModels
    {
        public CFDIConceptoClaseModels()
        {
            Id_CfdiClase = string.Empty;
            clase = string.Empty;
            _ListaClase = new List<CFDIConceptoClaseModels>();
        }

        public  List<CFDIConceptoClaseModels> _ListaClase { get; set; }

        private string _Id_CfdiClase;

        public string Id_CfdiClase
        {
            get { return _Id_CfdiClase; }
            set { _Id_CfdiClase = value; }
        }

        private string _clase;

        public string clase
        {
            get { return _clase; }
            set { _clase = value; }
        }


    }
}