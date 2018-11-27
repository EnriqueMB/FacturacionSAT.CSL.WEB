using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FacturacionSAT.CSL.WEB.Models.ViewModel
{
    public class FacturacionViewModel
    {
        public int Id_factura { get; set; }

        //public byte[] QR
        //{
        //    get
        //    {
        //        byte[] qr = null;
        //        string sQR = "";
        //        string baseQR = "";

        //        qr = XMLToClassSAT.QR.createBarCode("https://verificacfdi.facturaelectronica.sat.gob.mx/default.aspx?id=" + TimbreFiscalDigital.UUID +
        //            "&re=" + Emisor.Rfc + "&fe=" + Receptor.Rfc + "&tt=" + Total + "&fe=" + Sello.Substring(Sello.Length - 9, 8));
        //        baseQR = System.Convert.ToBase64String(qr);
        //        sQR = System.String.Format("data:image/gif;base64,{0}", baseQR);

        //        return sQR;

        //    }
        //}

        public string Logotipo { get; set; }
        public string NoCertificadoSAT { get; set; }
        public string SelloSAT { get; set; }

        public string NoCertificado { get; set; }
        public string Sello { get; set; }
        public string CadenaOriginal { get; set; }
        public string RFCEmisor { get; set; }

        public string NombreEmisor { get; set; }
        public string RegimenFiscal { get; set; }
        public string sRegimenFiscal { get; set; }

        public string UUID { get; set; }

        [Display(Name = "Condiciones de pago")]
        [StringLength(1000, ErrorMessage = "Las condiciones de pago no pueden superar los 1000 caracteres", MinimumLength = 1)]
        public string CondicionesDePago { get; set; }

        [Display(Name = "Clave privada")]
        public string ClavePrivada { get; set; }

        [Display(Name = "Sucursal")]
        public string Sucursal { get; set; }

        [Display(Name = "Forma de pago")]
        [Required(AllowEmptyStrings = false)]
        public string FormaDePago { get; set; }
        public string sFormaDePago { get; set; }

        [Display(Name = "Método de pago")]
        [Required(AllowEmptyStrings = false)]
        public string MetodoDePago { get; set; }
        public string sMetodoDePago { get; set; }

        [Display(Name = "Moneda")]
        public string Moneda { get; set; }

        [Display(Name = "Tipo de cambio")]
        public string TipoDeCambio { get; set; }

        public string LugarExpedicion { get; set; }

        [Display(Name = "Fecha")]
        public DateTime Fecha { get; set; }

        public DateTime FechaTimbre { get; set; }

        [Display(Name = "Hora")]
        public string Hora { get; set; }

        [Display(Name = "Minuto")]
        public string Minuto { get; set; }

        [StringLength(25, ErrorMessage = "La serie ni puede superar 25 caracteres", MinimumLength = 1)]
        [Display(Name = "Serie")]
        public string Serie { get; set; }

        public string sSerie { get; set; }
        public string NombreSerie { get; set; }

        [StringLength(40, ErrorMessage = "El folio no puede superar 40 caracteres", MinimumLength = 1)]
        public string Folio { get; set; }

        [Display(Name = "Uso del CFDI")]
        public string UsoCFDI { get; set; }
        public string sUsoCFDI { get; set; }

        public string TipoComprobante { get; set; } //dato calculado

        public string sTipoComprobante
        {
            get
            {
                string sTipoComprobante = "";

                switch (TipoComprobante)
                {
                    case "I":
                        sTipoComprobante = "Ingreso";
                        break;
                    case "E":
                        sTipoComprobante = "Egreso";
                        break;
                    case "T":
                        sTipoComprobante = "Traslado";
                        break;
                    case "N":
                        sTipoComprobante = "Nómina";
                        break;
                    case "P":
                        sTipoComprobante = "Pago";
                        break;
                    default:
                        break;
                }
                return sTipoComprobante;
            }
        }

        [Display(Name = "Observación")]
        public string Observacion { get; set; }

        [Display(Name = "Tipo de relación de CFDIs")]
        public string TipoRelacion { get; set; }

        [Display(Name = "UUID relacionados")]
        public string UUIDRelacionados { get; set; }

        public int VistaPrevia { get; set; }

        public bool EsVistaPrevia
        {
            get
            {
                if (VistaPrevia == 1)
                    return true;
                else
                    return false;
            }
        }

        public string CalleFiscal { get; set; }
        public string NoExteriorFiscal { get; set; }
        public string NoInteriorFiscal { get; set; }
        public string ColoniaFiscal { get; set; }
        public string CPFiscal { get; set; }
        public string PaisFiscal { get; set; }

        public string EstadoFiscal { get; set; }

        public string MunicipioFiscal { get; set; }

        [Display(Name = "RFC")]
        [RegularExpression(@"^[A-Za-zÑñ&]{3,4}[0-9]{2}[0-1][0-9][0-3][0-9][A-Za-z0-9]{2}[0-9Aa]$", ErrorMessage = "El RFC no es válido")]
        [Required]
        public string RFCReceptor { get; set; }

        [Display(Name = "Razón social")]
        public string RazonSocial { get; set; }

        [Display(Name = "Calle")]
        public string Calle { get; set; }

        [Display(Name = "No. Exterior")]
        public string NoExterior { get; set; }

        [Display(Name = "No. Interior")]
        public string NoInterior { get; set; }

        [Display(Name = "Colonia")]
        public string Colonia { get; set; }

        [Display(Name = "Localidad")]
        public string Localidad { get; set; }

        [Display(Name = "Código postal")]
        public string CP { get; set; }

        [Display(Name = "País")]
        public string Pais { get; set; }

        [Display(Name = "Estado")]
        public string Estado { get; set; }

        [Display(Name = "Municipio")]
        public string Municipio { get; set; }

        [Display(Name = "Teléfono")]
        public string Telefono { get; set; }

        [Display(Name = "Correo electrónico")]
        [EmailAddress]
        public string Email { get; set; }

        [Display(Name = "Referencia")]
        public string Referencia { get; set; }

        public decimal Subtotal { get; set; }
        public decimal Total { get; set; }

        public decimal TotalDescuento { get; set; }

        public decimal TotalFederalTraslado { get; set; }
        public decimal TotalFederalRetenido { get; set; }
        public decimal TotalLocalTraslado { get; set; }
        public decimal TotalLocalRetenido { get; set; }

        public string sTotalLocalTraslado
        {
            get
            {
                if (TotalLocalTraslado > 0)
                    return TotalLocalTraslado.ToString("0.00");
                return "0.00";
            }
        }
        public string sTotalLocalRetenido
        {
            get
            {
                if (TotalLocalRetenido > 0)
                    return TotalLocalRetenido.ToString("0.00");
                return "0.00";
            }
        }

        public decimal TotalIVATrasladado { get; set; }
        public decimal TotalIEPSTrasladado { get; set; }
        public decimal TotalIEPSRetenido { get; set; }
        public decimal TotalIVARetenido { get; set; }
        public decimal TotalISRRetenido { get; set; }

        public decimal TasaIEPSTrasladado { get; set; }
        public decimal TasaIEPSRetenido { get; set; }
        public decimal TasaIVRetenido { get; set; }
        public decimal TasaISRRetenido { get; set; }

        public string sTotalIVATrasladado
        {
            get
            {
                if (TotalIVATrasladado > 0)
                    return TotalIVATrasladado.ToString("0,0.00");
                return "0.00";
            }
        }

        public string sTotalIEPSTrasladado
        {
            get
            {
                if (TotalIEPSTrasladado > 0)
                    return TotalIEPSTrasladado.ToString("0,0.00");
                return "0.00";
            }
        }

        public string sTotalIEPSRetenido
        {
            get
            {
                if (TotalIEPSRetenido > 0)
                    return TotalIEPSRetenido.ToString("0,0.00");
                return "0.00";
            }
        }

        public string sTotalIVARetenido
        {
            get
            {
                if (TotalIVARetenido > 0)
                    return TotalIVARetenido.ToString("0,0.00");
                return "0.00";
            }
        }

        public string sTotalISRetenido
        {
            get
            {
                if (TotalISRRetenido > 0)
                    return TotalISRRetenido.ToString("0,0.00");
                return "0.00";
            }
        }


        //public DonatariaViewModel Donataria {get; set; }

        public List<Concepto> Conceptos { get; set; }

        public FacturacionViewModel()
        {
            Conceptos = new List<Concepto>();
            TotalFederalRetenido = 0;
            TotalFederalTraslado = 0;
            TotalLocalRetenido = 0;
            TotalLocalTraslado = 0;
        }

        public class Concepto
        {
            public string ClaveProducto { get; set; }
            //public string Codigo { get; set; }

            public decimal Cantidad { get; set; }
            public string ClaveUnidad { get; set; }
            public string Unidad { get; set; }

            public string Descripcion { get; set; }
            public decimal? Descuento { get; set; }

            public decimal PrecioUnitario { get; set; }

            public string CuentaPredial { get; set; }

            public List<Impuesto> Impuestos { get; set; }

            public Concepto()
            {
                Impuestos = new List<Impuesto>();
            }
        }

        public class Impuesto
        {
            public string Nombre { get; set; }

            public decimal Tasa { get; set; }
            public string Ambito { get; set; }
            public string Tipo { get; set; }

            public string Factor { get; set; }
            //valor que se utiliza en el pdf, se llena al hacer la factura,
            //es decir no viene en el formulario
            public decimal Importe { get; set; }
        }
    }
}