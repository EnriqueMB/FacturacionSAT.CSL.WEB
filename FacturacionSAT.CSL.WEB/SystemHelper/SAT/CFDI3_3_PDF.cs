using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacturacionSAT.CSL.WEB.SystemHelper.SAT
{
    public class CFDI3_3_PDF
    {
        public Comprobante Comprobante;

        private string _CadenaOriginal;

        public string CadenaOriginal
        {
            get { return _CadenaOriginal; }
            private set
            {

                _CadenaOriginal = value;
            }
        }


        public CFDI3_3_PDF(Comprobante _comprobante)
        {
            this.Comprobante = _comprobante;
            //agregar los campos que son solo para el pdf

        }
    }
}