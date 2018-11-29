using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Web;

namespace FacturacionSAT.CSL.WEB.Models.Validaciones
{
    public class DecimalMayor0Attribute : ValidationAttribute
    {
        public DecimalMayor0Attribute() : base("El campo {0} es inválido")
        {

        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            decimal valor = 0;
            decimal.TryParse(value.ToString(), out valor);
            if (value != null)
            {
                if (valor <= 0)
                {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}