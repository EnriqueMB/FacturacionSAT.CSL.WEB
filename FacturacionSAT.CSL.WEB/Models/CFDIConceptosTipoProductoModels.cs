using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FacturacionSAT.CSL.WEB.Models
{
    public class CFDIConceptosTipoProductoModels
    {
        public CFDIConceptosTipoProductoModels()
        {
            Id_cfdiTipoProducto = string.Empty;
            CveTipoProducto = string.Empty;
            TipoProducto = string.Empty;
            _ListaTipoProducto = new List<CFDIConceptosTipoProductoModels>();
        }
        public List<CFDIConceptosTipoProductoModels> _ListaTipoProducto { get; set; }

        private string _Id_cfdiTipoProducto;
        [Required]
        [Display(Name = "Tipo Producto")]
        public string Id_cfdiTipoProducto
        {
            get { return _Id_cfdiTipoProducto; }
            set { _Id_cfdiTipoProducto = value; }
        }
        private string _CveTipoProducto;

        public string CveTipoProducto
        {
            get { return _CveTipoProducto; }
            set { _CveTipoProducto = value; }
        }
        private string _TipoProducto;

        public string TipoProducto
        {
            get { return _TipoProducto; }
            set { _TipoProducto = value; }
        }




    }
}