using OrderManagement.Domain.Enums;

namespace OrderManagement.Domain.Entities
{
    public class Pedido : Entity
    {
        public string Origem { get; set; } = string.Empty;
        public string Destino { get; set; } = string.Empty;
        public DateTime DataCriacao { get; set; } = DateTime.UtcNow;
        public Status Status { get; set; }
        public int ClienteId { get; set; }
        public virtual Cliente? Cliente { get; set; } 
    }
}
