using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text.RegularExpressions;
using System.Web;

namespace FacturacionSAT.CSL.WEB.Models.Validaciones
{
    //
    public class IFEAttribute : ValidationAttribute
    {
        public IFEAttribute() : base("El campo {0} es inválido")
        {

        }

        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string pattern = @"^.*(?=.{13})[+-]?\d+(\.\d+)?$";
            if (value != null)
            {
                if (!Regex.IsMatch(value.ToString(), pattern))
                {
                    var errorMessage = FormatErrorMessage(validationContext.DisplayName);
                    return new ValidationResult(errorMessage);
                }
            }

            return ValidationResult.Success;
        }
    }
}