using OrderManagement.Application.Dtos;

namespace OrderManagement.Application.ViewModels
{
    public class PedidoViewModel
    {
        public int Id { get; set; }
        public string Origem { get; set; } = string.Empty;
        public string Destino { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public string Status { get; set; } = string.Empty;
        public ClienteViewModel Cliente { get; set; } = null!;
    }
}
