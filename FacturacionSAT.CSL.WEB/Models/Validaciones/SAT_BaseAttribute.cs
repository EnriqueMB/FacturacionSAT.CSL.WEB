using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using System.Text.RegularExpressions;
using System.ComponentModel.DataAnnotations;

namespace FacturacionSAT.CSL.WEB.Models.Validaciones
{
    public class SAT_BaseAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            string pattern = @"^[1-9]([0-9]+)?([.][0-9]{1,6})?$";
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
