using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.Delivery.WebAPI.Utilities.Attributes
{
    internal class SenhaAtributte: ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is string)
            {
                string senha = (string)value;
                if (senha.Length < 8)
                {
                    return new ValidationResult("A senha deve ter no mínimo 8 caracteres.");
                }
                if (!senha.Any(char.IsUpper))
                {
                    return new ValidationResult("A senha deve ter no mínimo uma letra maiúscula.");
                }
                if (!senha.Any(char.IsLower))
                {
                    return new ValidationResult("A senha deve ter no mínimo uma letra minúscula.");
                }
                if (!senha.Any(char.IsDigit))
                {
                    return new ValidationResult("A senha deve ter no mínimo um número.");
                }
            }
            else
            {
                return new ValidationResult("Senha inválida.");
            }

            return ValidationResult.Success;
        }
    }
}
