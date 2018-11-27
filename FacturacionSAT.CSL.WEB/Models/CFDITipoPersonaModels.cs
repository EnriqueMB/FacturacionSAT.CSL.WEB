using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacturacionSAT.CSL.WEB.Models
{
    public class CFDITipoPersonaModels
    {
        private string _IDCFDITipoPersona;

        public string IDCFDITIpoPersona
        {
            get { return _IDCFDITipoPersona; }
            set { _IDCFDITipoPersona = value; }
        }

        private string _TipoPersona;

        public string TipoPersona
        {
            get { return _TipoPersona; }
            set { _TipoPersona = value; }
        }
    }
}