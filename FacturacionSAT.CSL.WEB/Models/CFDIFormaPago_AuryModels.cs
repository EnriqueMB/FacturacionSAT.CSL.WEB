using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FacturacionSAT.CSL.WEB.Models
{
    public class CFDIFormaPago_AuryModels
    {
        public CFDIFormaPago_AuryModels()
        {
            ID_FormaPago = string.Empty;
            TipoPago = string.Empty;
            this.Conexion = string.Empty;
            TipoDePago = new CFDIFormaPagoDetalleModels();
            this.ListaCFDIFP = new List<CFDIFormaPago_AuryModels>();
            this.ListaCFDIDetalleCMB = new List<CFDIFormaPagoDetalleModels>();
            Id_usuario = string.Empty;
            Completado = false;
        }

        private string _ID_FormaPago;
     
        public string ID_FormaPago
        {
            get { return _ID_FormaPago; }
            set { _ID_FormaPago = value; }
        }

        private string _TipoPago;

        public string TipoPago
        {
            get { return _TipoPago; }
            set { _TipoPago = value; }
        }

        private CFDIFormaPagoDetalleModels _TipoDePago;

        public CFDIFormaPagoDetalleModels TipoDePago
        {
            get { return _TipoDePago; }
            set { _TipoDePago = value; }
        }

        private List<CFDIFormaPago_AuryModels> _ListaCFDIFP;

        public List<CFDIFormaPago_AuryModels> ListaCFDIFP
        {
            get { return _ListaCFDIFP; }
            set { _ListaCFDIFP = value; }
        }

        private List<CFDIFormaPagoDetalleModels> _ListaCFDIDetalleCMB;

        public List<CFDIFormaPagoDetalleModels> ListaCFDIDetalleCMB
        {
            get { return _ListaCFDIDetalleCMB; }
            set { _ListaCFDIDetalleCMB = value; }
        }


        public string Conexion { get; set; }
        public string Id_usuario { get; set; }
        public bool Completado { get; set; }
    }
}