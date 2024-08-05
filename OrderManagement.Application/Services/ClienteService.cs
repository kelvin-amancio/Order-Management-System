using OrderManagement.Application.Dtos;
using OrderManagement.Application.Interfaces;
using OrderManagement.Domain.Interfaces;
using OrderManagement.Application.Mappers;
using OrderManagement.Application.ViewModels;

namespace OrderManagement.Application.Services
{
    public class ClienteService(IClienteRepository clienteRepository) : IClienteService
    {
        private readonly IClienteRepository _clienteRepository = clienteRepository;

        public async Task<IEnumerable<ClienteViewModel>> GetAllAsync()
        {
          var clientesDto = await _clienteRepository.GetAllAsync();
          return clientesDto.ToClientesViewModel();
        }
        public async Task<ClienteViewModel?> GetByIdAsync(int id)
        {
            var cliente = await _clienteRepository.GetByIdAsync(id);
            return cliente!.ToClienteViewModel();
        }
        public async Task<ClienteDto> CreateAsync(ClienteDto clienteDto)
        {
           var cliente = await _clienteRepository.CreateAsync(clienteDto.ToCliente()!);
           return cliente.ToClienteDto()!;
        }
        public async Task<ClienteDto?> UpdateAsync(ClienteDto clienteDto)
        {
            var cliente = await _clienteRepository.UpdateAsync(clienteDto.ToCliente()!);
            return cliente!.ToClienteDto()!;
        }
        public async Task<ClienteDto?> RemoveAsync(ClienteDto clienteDto)
        {
            var cliente = await _clienteRepository.RemoveAsync(clienteDto.ToCliente()!);
            return cliente!.ToClienteDto()!;
        }
        public async Task<ClienteDto?> RemoveByIdAsync(int id)
        {
            var cliente = await _clienteRepository.RemoveByIdAsync(id);
            return cliente!.ToClienteDto();
        }

    }
}
