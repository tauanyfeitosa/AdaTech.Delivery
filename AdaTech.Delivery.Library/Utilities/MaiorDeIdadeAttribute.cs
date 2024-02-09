using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.Delivery.Library.Utilities
{
    public class MaiorDeIdadeAttribute : ValidationAttribute
    {
        protected override ValidationResult IsValid(object value, ValidationContext validationContext)
        {
            if (value is DateTime)
            {
                DateTime dataNascimento = (DateTime)value;
                var idade = DateTime.Today.Year - dataNascimento.Year;
                if (dataNascimento > DateTime.Today.AddYears(-idade)) idade--;

                if (idade < 18)
                {
                    return new ValidationResult("Você deve ser maior de 18 anos.");
                }
            }
            else
            {
                return new ValidationResult("Data de nascimento inválida.");
            }

            return ValidationResult.Success;
        }
    }
}
