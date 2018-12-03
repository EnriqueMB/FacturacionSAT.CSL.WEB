using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacturacionSAT.CSL.WEB.SystemHelper.SAT
{
    public class CFDI3_3_PDF : Comprobante
    {
        public Comprobante Comprobante;

        public CFDI3_3_PDF(Comprobante _Comprobante)
        {
            this.Comprobante = _Comprobante;
        }
    }
}