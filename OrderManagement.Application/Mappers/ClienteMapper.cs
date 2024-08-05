using OrderManagement.Application.Dtos;
using OrderManagement.Application.ViewModels;
using OrderManagement.Domain.Entities;

namespace OrderManagement.Application.Mappers
{
    public static class ClienteMapper
    {
        public static ClienteDto? ToClienteDto(this Cliente cliente)
        {
            if (cliente is null)
                return null;

            return new ClienteDto()
            {
               Id = cliente.Id,
               Nome = cliente.Nome,
               Endereco = cliente.Endereco,
               Telefone = cliente.Telefone,
               Email = cliente.Email
            };
        }

        public static ClienteViewModel? ToClienteViewModel(this Cliente cliente)
        {
            if (cliente is null)
                return null;

            return new ClienteViewModel()
            {
                Id = cliente.Id,
                Nome = cliente.Nome,
                Endereco = cliente.Endereco,
                Telefone = cliente.Telefone,
                Email = cliente.Email
            };
        }

        public static Cliente? ToCliente(this ClienteDto clienteDto)
        {
            if (clienteDto is null)
                return null;

            return new Cliente()
            {
                Id = clienteDto.Id,
                Nome = clienteDto.Nome,
                Endereco = clienteDto.Endereco,
                Telefone = clienteDto.Telefone,
                Email = clienteDto.Email
            };
        }

        public static Cliente? FromClienteViewModelToCliente(this ClienteViewModel clienteViewModel)
        {
            if (clienteViewModel is null)
                return null;

            return new Cliente()
            {
                Id = clienteViewModel.Id,
                Nome = clienteViewModel.Nome,
                Endereco = clienteViewModel.Endereco,
                Telefone = clienteViewModel.Telefone,
                Email = clienteViewModel.Email
            };
        }

        public static IEnumerable<ClienteDto> ToClientesDto(this IEnumerable<Cliente> clientes)
        {
            var clientesDto = new List<ClienteDto>();

            foreach (var cliente in clientes)          
                clientesDto.Add(ToClienteDto(cliente)!);
            
            return clientesDto;
        }

        public static IEnumerable<ClienteViewModel> ToClientesViewModel(this IEnumerable<Cliente> clientes)
        {
            var clienteViewModel = new List<ClienteViewModel>();

            foreach (var cliente in clientes)
                clienteViewModel.Add(ToClienteViewModel(cliente)!);

            return clienteViewModel;
        }
    }
}
