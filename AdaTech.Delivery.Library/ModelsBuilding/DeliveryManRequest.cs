using AdaTech.Delivery.Library.Utilities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace AdaTech.Delivery.Library.ModelsBuilding
{
    public class DeliveryManRequest
    {
        [Key]
        public int Id { get; set; }

        [Required(ErrorMessage = "O nome é obrigatório.")]
        [StringLength(50, ErrorMessage = "O nome não pode ter mais de 50 caracteres.")]
        public string? Name { get; set; }

        [Required(ErrorMessage = "O sobrenome é obrigatório.")]
        [StringLength(50, ErrorMessage = "O sobrenome não pode ter mais de 50 caracteres.")]
        public string? LastName { get; set; }

        [Required(ErrorMessage = "O e-mail é obrigatório.")]
        [EmailAddress(ErrorMessage = "Formato de e-mail inválido.")]
        public string? Email { get; set; }

        [Phone(ErrorMessage = "Formato de número de telefone inválido.")]
        [StringLength(20, ErrorMessage = "O número de telefone não pode ter mais de 20 dígitos.")]
        public string? PhoneNumber { get; set; }

        [RegularExpression(@"^\d{3}\.\d{3}\.\d{3}-\d{2}$", ErrorMessage = "Formato de CPF inválido.")]
        public string CPF { get; set; }

        [DataType(DataType.Date, ErrorMessage = "Formato de data inválido.")]
        [MaiorDeIdade(ErrorMessage = "Você deve ser maior de 18 anos.")]
        public DateTime DateBirth { get; set; }
    }
}
