using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FacturacionSAT.CSL.WEB.Models
{
    public class CFDIConceptoDivicionModels
    {
        public CFDIConceptoDivicionModels()
        {
            Id_cfdiDivision = string.Empty;
            CveTipoProducto = string.Empty;
            CveDivisionShort = string.Empty;
            Division = string.Empty;
            _ListaDivicion = new List<CFDIConceptoDivicionModels>();
        }
        public List<CFDIConceptoDivicionModels> _ListaDivicion { get; set; }
        private string _Id_cfdiDivision;
        [Required]
        [Display(Name = "division")]
        public string Id_cfdiDivision
        {
            get { return _Id_cfdiDivision; }
            set { _Id_cfdiDivision = value; }
        }
        private string _CveTipoProducto;

        public string CveTipoProducto
        {
            get { return _CveTipoProducto; }
            set { _CveTipoProducto = value; }
        }

        private string _CveDivisionShort;

        public string CveDivisionShort
        {
            get { return _CveDivisionShort; }
            set { _CveDivisionShort = value; }
        }
        private string _Division;

        public string Division
        {
            get { return _Division; }
            set { _Division = value; }
        }




    }
}