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
                //puede ser así, o puede que el proveedor del pac, lo proporcione ;D xD
                if(Comprobante != null && Comprobante.TimbreFiscalDigital != null)
                {
                    string cadena = "||" + Comprobante.TimbreFiscalDigital.Version.Trim() +
                        "|" + Comprobante.TimbreFiscalDigital.UUID.Trim() +
                        "|" + Comprobante.TimbreFiscalDigital.FechaTimbrado +
                        "|" + Comprobante.TimbreFiscalDigital.RfcProvCertif.Trim() +
                        "|" + Comprobante.Sello.Trim() +
                        "|" + Comprobante.TimbreFiscalDigital.NoCertificadoSAT.Trim() +
                        "||";

                    return cadena;
                }
                else
                {
                    return "Sin datos, contacte con soporte técnico.";
                }
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