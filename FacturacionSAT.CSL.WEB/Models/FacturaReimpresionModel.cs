using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacturacionSAT.CSL.WEB.Models
{
    public class FacturaReimpresionModel
    {
        public int Id { get; set; }
        public string RFCReceptor { get; set; }
        public string CodigoBarra { get; set; }
        public decimal TotalFactura { get; set; }
        public string XMLFactura { get; set; }
        public DateTime FechaCreacion { get; set; }

    }
}