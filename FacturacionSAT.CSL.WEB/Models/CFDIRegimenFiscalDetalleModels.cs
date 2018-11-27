using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;

namespace FacturacionSAT.CSL.WEB.Models
{
    public class CFDIRegimenFiscalDetalleModels
    {
        public CFDIRegimenFiscalDetalleModels()
        {
            _IDCFDIRegimenFiscal = string.Empty;
            _IDCFDIRegimenFiscalDetalle = string.Empty;
            _C_RegimenFiscal = string.Empty;
            _Descipcion = string.Empty;
            _Fiscal = string.Empty;
            _Moral = string.Empty;
            _FechaInicioVigencia = DateTime.Today;
            _FechaFinVigencia = DateTime.Today;
        }
        private string _IDCFDIRegimenFiscalDetalle;

        public string IDCFDIRegimenFiscalDetalle
        {
            get { return _IDCFDIRegimenFiscalDetalle; }
            set { _IDCFDIRegimenFiscalDetalle = value; }
        }

        private string _IDCFDIRegimenFiscal;

        public string IDCFDIRegimenFiscal
        {
            get { return _IDCFDIRegimenFiscal; }
            set { _IDCFDIRegimenFiscal = value; }
        }

        private string _C_RegimenFiscal;

        public string C_RegimenFiscal
        {
            get { return _C_RegimenFiscal; }
            set { _C_RegimenFiscal = value; }
        }

        private string _Descipcion;

        public string Descripcion
        {
            get { return _Descipcion; }
            set { _Descipcion = value; }
        }

        private string _Fiscal;

        public string Fiscal
        {
            get { return _Fiscal; }
            set { _Fiscal = value; }
        }

        private string _Moral;

        public string Moral
        {
            get { return _Moral; }
            set { _Moral = value; }
        }

        private DateTime _FechaInicioVigencia;

        public DateTime FechaInicioVigencia
        {
            get { return _FechaInicioVigencia; }
            set { _FechaInicioVigencia = value; }
        }

        private DateTime _FechaFinVigencia;

        public DateTime FechaFinVigencia
        {
            get { return _FechaFinVigencia; }
            set { _FechaFinVigencia = value; }
        }

    }
}