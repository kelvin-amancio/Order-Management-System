using OrderManagement.Application.Dtos;
using OrderManagement.Application.ViewModels;

namespace OrderManagement.Application.Interfaces
{
    public interface IPedidoService
    {
        Task<IEnumerable<PedidoViewModel>> GetAllAsync();
        Task<PedidoViewModel?> GetByIdAsync(int id);
        Task<PedidoDto> CreateAsync(PedidoDto pedidoDto);
        Task<PedidoDto> UpdateAsync(PedidoDto pedidoDto);
        Task<PedidoDto> RemoveAsync(PedidoDto pedidoDto);
        Task<PedidoDto?> RemoveByIdAsync(int id);
        Task<FreteResultViewModel<FreteViewModel?>> GetFreteAsync(string origem, string destino);
    }
}
