using OrderManagement.Domain.Entities;

namespace OrderManagement.Domain.Interfaces
{
    public interface IPedidoRepository
    {
        Task<IEnumerable<Pedido>> GetAllAsync();
        Task<Pedido?> GetByIdAsync(int id);
        Task<Pedido> CreateAsync(Pedido pedido);
        Task<Pedido?> UpdateAsync(Pedido pedido);
        Task<Pedido?> RemoveAsync(Pedido pedido);
        Task<Pedido?> RemoveByIdAsync(int id);
    }
}
