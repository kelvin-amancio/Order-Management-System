using OrderManagement.Domain.Entities;

namespace OrderManagement.Domain.Interfaces
{
    public interface IClienteRepository
    {
        Task<IEnumerable<Cliente>> GetAllAsync();
        Task<Cliente?> GetByIdAsync(int id);
        Task<Cliente> CreateAsync(Cliente cliente);
        Task<Cliente?> UpdateAsync(Cliente cliente);
        Task<Cliente?> RemoveAsync(Cliente cliente);
        Task<Cliente?> RemoveByIdAsync(int id);
    }
}
