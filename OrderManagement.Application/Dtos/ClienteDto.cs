using OrderManagement.Domain.Core.Helpers;
using System.ComponentModel.DataAnnotations;

namespace OrderManagement.Application.Dtos
{
    public class ClienteDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = MessageHelper.ErrorLengthMessage)]
        public string Nome { get; set; } = string.Empty;
        [Required]
        [StringLength(70, ErrorMessage = MessageHelper.ErrorLengthMessage)]
        public string Endereco { get; set; } = string.Empty;
        [Required]
        [RegularExpression("^[1-9]+$", ErrorMessage = "O número de telefone deve conter apenas números.")]
        [StringLength(11, ErrorMessage = MessageHelper.ErrorLengthMessage)]
        public string Telefone { get; set; } = string.Empty;
        [Required]
        [EmailAddress]
        [StringLength(60, ErrorMessage = MessageHelper.ErrorLengthMessage)]
        public string Email { get; set; } = string.Empty;
    }
}
