using Moq;
using OrderManagement.Application.Mappers;
using OrderManagement.Application.Services;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Interfaces;

namespace OrderManagement.Tests
{
    public class ClienteUnitTest
    {
        private readonly Mock<IClienteRepository> _clienteRepositoryMock;
        private readonly ClienteService _clienteService;

        public ClienteUnitTest()
        {
            _clienteRepositoryMock = new Mock<IClienteRepository>();
            _clienteService = new ClienteService(_clienteRepositoryMock.Object);
        }

        [Fact]
        public async Task GetClientesAsync_ReturnsListOfClientesWithSameTotalCount()
        {
            var clientes = new List<Cliente>
            {
               new Cliente {
                   Id = 1,
                   Nome = "Alan Silva",
                   Endereco = "Rua Barbieri",
                   Telefone = "11974393311",
                   Email = "alansilva@outlook.com"
               },
               new Cliente {
                   Id = 2,
                   Nome = "Jorge Silva",
                   Endereco = "Rua Tancantina",
                   Telefone = "21908323311",
                   Email = "jorgesilva@outlook.com"
               },
            };
            _clienteRepositoryMock.Setup(clr => clr.GetAllAsync()).ReturnsAsync(clientes);

            var result = await _clienteService.GetAllAsync();

            Assert.NotNull(result);
            Assert.Equal(clientes.Count, result.Count());
        }

        [Fact]
        public async Task GetClienteByIdAsync_ReturnsClienteWithSameId()
        {
            var cliente = new Cliente { Id = 1, Nome = "Alan Silva", Endereco = "Rua Barbieri", Telefone = "11974393311", Email = "alansilva@outlook.com" };
            _clienteRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(cliente);

            var result = await _clienteService.GetByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal(cliente.Id, result.Id);
        }

        [Fact]
        public async Task AddClienteAsync_ReturnCliente()
        {
            var cliente = new Cliente { Id = 1, Nome = "Alan Silva JS", Endereco = "Rua Barbieri", Telefone = "11974393311", Email = "alansilva@outlook.com" };

            await _clienteService.CreateAsync(cliente.ToClienteDto()!);
            _clienteRepositoryMock.Setup(repo => repo.CreateAsync(cliente)).ReturnsAsync(cliente);

            Assert.NotNull(cliente);
        }

        [Fact]
        public async Task UpdateClienteAsync_ReturnCliente()
        {
            var cliente = new Cliente { Id = 1, Nome = "Alan Silva JS", Endereco = "Rua Barbieri", Telefone = "11974393311", Email = "alansilva@outlook.com" };

            await _clienteService.UpdateAsync(cliente.ToClienteDto()!);
            _clienteRepositoryMock.Setup(repo => repo.UpdateAsync(cliente)).ReturnsAsync(cliente);

            Assert.NotNull(cliente);
        }

        [Fact]
        public async Task DeleteClienteByIdAsync_ReturnCliente()
        {
            var result = await _clienteService.RemoveByIdAsync(1);
            var cliente = result!.ToCliente();

            _clienteRepositoryMock.Setup(repo => repo.RemoveByIdAsync(1)).ReturnsAsync(cliente);
        }

        [Fact]
        public async Task DeleteClienteAsync_ReturnCliente()
        {
            var cliente = new Cliente { Id = 1, Nome = "Alan Silva JS", Endereco = "Rua Barbieri", Telefone = "11974393311", Email = "alansilva@outlook.com" };
            
            await _clienteService.RemoveAsync(cliente.ToClienteDto()!);
            _clienteRepositoryMock.Setup(repo => repo.RemoveAsync(cliente)).ReturnsAsync(cliente);

            Assert.NotNull(cliente);
        }

    }
}
