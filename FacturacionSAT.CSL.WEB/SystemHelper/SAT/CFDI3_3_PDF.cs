using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using FacturacionSAT.CSL.WEB.Models.ViewModel;

namespace FacturacionSAT.CSL.WEB.SystemHelper.SAT
{
    public class CFDI3_3_PDF
    {
        public Comprobante Comprobante;
        public FacturacionViewModel FacturaModel;

        public string CadenaOriginal
        {
            get
            {
                return "Cadena";
            }
        }

        public string FechaElaboracion
        {
            get
            {
                return DateTime.Now.ToString("yyyy-MM-dd HH:mm:ss");
            }
        }

        public CFDI3_3_PDF(Comprobante _comprobante, FacturacionViewModel _facturaModel)
        {
            this.Comprobante = _comprobante;
            this.FacturaModel = _facturaModel;
        }
    }
}