using OrderManagement.Domain.Core.Helpers;
using OrderManagement.Domain.Enums;
using System.ComponentModel.DataAnnotations;

namespace OrderManagement.Application.Dtos
{
    public class PedidoDto
    {
        public int Id { get; set; }
        [Required]
        [StringLength(50, ErrorMessage = MessageHelper.ErrorLengthMessage)]
        public string Origem { get; set; } = string.Empty;
        [Required]
        [StringLength(50, ErrorMessage = MessageHelper.ErrorLengthMessage)]
        public string Destino { get; set; } = string.Empty;
        [Required]
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        [Required]
        [Range(0,3, ErrorMessage = MessageHelper.ErrorRangeMessage)]
        public Status Status { get; set; }
        [Required]
        public int ClienteId { get; set; }
    }
}
