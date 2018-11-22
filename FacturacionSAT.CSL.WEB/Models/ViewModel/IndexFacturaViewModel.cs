using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FacturacionSAT.CSL.WEB.Models.ViewModel
{
    public class IndexFacturaViewModel
    {
        [Display(Name = "* RFC")]
        [RegularExpression(@"^[A-Za-zÑñ&]{3,4}[0-9]{2}[0-1][0-9][0-3][0-9][A-Za-z0-9]{2}[0-9Aa]$", ErrorMessage = "El RFC no es válido")]
        [Required]
        public string RFCReceptor { get; set; }

        [Display(Name = "* Código de barra")]
        [StringLength(14, ErrorMessage = "El código de barra es de {1} caracteres", MinimumLength = 14)]
        [Required]
        public string CodigoBarra { get; set; }

        public List<ComboModel> ListaEmisores { get; set; }

        [Display(Name = "* Emisor")]
        [Required(AllowEmptyStrings = false)]
        public string Id_emisor { get; set; }
    }
}