using OrderManagement.Application.Dtos;
using OrderManagement.Application.ViewModels;

namespace OrderManagement.Application.Interfaces
{
    public interface IClienteService
    {
        Task<IEnumerable<ClienteViewModel>> GetAllAsync();
        Task<ClienteViewModel?> GetByIdAsync(int id);
        Task<ClienteDto> CreateAsync(ClienteDto clienteDto);
        Task<ClienteDto?> UpdateAsync(ClienteDto clienteDto);
        Task<ClienteDto?> RemoveAsync(ClienteDto clienteDto);
        Task<ClienteDto?> RemoveByIdAsync(int id);
    }
}
