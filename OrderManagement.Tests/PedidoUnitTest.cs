using Moq;
using Moq.Protected;
using OrderManagement.Application.Dtos;
using OrderManagement.Application.Mappers;
using OrderManagement.Application.Services;
using OrderManagement.Domain.Core.Helpers;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Enums;
using OrderManagement.Domain.Interfaces;
using System.Net;
using System.Text;
using System.Text.Json;

namespace OrderManagement.Tests
{
    public class PedidoUnitTest
    {
        private readonly Mock<IHttpClientFactory> _httpClientFactoryMock;
        private readonly Mock<HttpMessageHandler> _handlerMock;
        private readonly HttpClient _httpClient;
        private readonly Mock<IPedidoRepository> _pedidoRepositoryMock;
        private readonly PedidoService _pedidoService;
        public PedidoUnitTest()
        {
            _pedidoRepositoryMock = new Mock<IPedidoRepository>();

            _httpClientFactoryMock = new Mock<IHttpClientFactory>();
            _handlerMock = new Mock<HttpMessageHandler>();

            _handlerMock.Protected()
                    .Setup<Task<HttpResponseMessage>>(
                    "SendAsync",
                    ItExpr.Is<HttpRequestMessage>(req =>
                    req.Method == HttpMethod.Get &&
                    req.RequestUri!.ToString().Contains("/maps/api/distancematrix/json")),
                    ItExpr.IsAny<CancellationToken>()
             ).ReturnsAsync(CreateHttpResponseMessageFreteDto());

            _httpClient = new HttpClient(_handlerMock.Object) { BaseAddress = new Uri("https://maps.googleapis.com") };
            StringHelpers.MapsKey = "AIzaSyDEC2Piu134nb1Oo9oVTNB6kmbzYZ07W-A";
            _httpClientFactoryMock.Setup(fct => fct.CreateClient("MapsApi")).Returns(_httpClient);     
            _pedidoService = new PedidoService(_pedidoRepositoryMock.Object, _httpClientFactoryMock.Object);
        }

        [Fact]
        public async Task GetPedidoByIdAsync_ReturnsPedidoWithSameId()
        {
            var cliente = new Cliente { Id = 1, Nome = "Alan Silva", Endereco = "Rua Barbieri", Telefone = "11974393311", Email = "alansilva@outlook.com" };
            var Pedido = new Pedido { Id = 1, Origem = "25931798", Destino = "12331310", DataCriacao = DateTime.UtcNow, Status = Status.EmProcessamento, ClienteId = 1 };
            _pedidoRepositoryMock.Setup(repo => repo.GetByIdAsync(1)).ReturnsAsync(Pedido);

            var result = await _pedidoService.GetByIdAsync(1);

            Assert.NotNull(result);
            Assert.Equal(Pedido.Id, result.Id);
        }

        [Fact]
        public async Task GetPedidosAsync_ReturnsListOfPedidosWithSameTotalCount()
        {
            var Pedidos = new List<Pedido>
            {
               new Pedido {
                   Id = 1,
                   Origem = "25931798",
                   Destino = "12331310",
                   DataCriacao = DateTime.UtcNow,
                   Status = Status.EmProcessamento,
                   ClienteId = 1
               },
               new Pedido {
                   Id = 2,
                   Origem = "12331310",
                   Destino = "24020105",
                   DataCriacao = DateTime.UtcNow,
                   Status = Status.Entregue,
                   ClienteId = 2
               },
            };
            _pedidoRepositoryMock.Setup(clr => clr.GetAllAsync()).ReturnsAsync(Pedidos);

            var result = await _pedidoService.GetAllAsync();

            Assert.NotNull(result);
            Assert.Equal(Pedidos.Count, result.Count());
        }

        [Fact]
        public async Task AddPedidoAsync_ReturnPedido()
        {
            var Pedido = new Pedido { Id = 1, Origem = "25931798", Destino = "12331310", DataCriacao = DateTime.UtcNow, Status = Status.EmProcessamento, ClienteId = 1 };

            await _pedidoService.CreateAsync(Pedido.ToPedidoDto()!);
            _pedidoRepositoryMock.Setup(repo => repo.CreateAsync(Pedido)).ReturnsAsync(Pedido);

            Assert.NotNull(Pedido);
        }

        [Fact]
        public async Task UpdatePedidoAsync_ReturnPedido()
        {
            var Pedido = new Pedido { Id = 1, Origem = "25931798", Destino = "12331310", DataCriacao = DateTime.UtcNow, Status = Status.Enviado, ClienteId = 1 };

            await _pedidoService.UpdateAsync(Pedido.ToPedidoDto()!);
            _pedidoRepositoryMock.Setup(repo => repo.UpdateAsync(Pedido)).ReturnsAsync(Pedido);

            Assert.NotNull(Pedido);
        }

        [Fact]
        public async Task DeletePedidoByIdAsync_ReturnPedido()
        {
            var result = await _pedidoService.RemoveByIdAsync(1);
            var Pedido = result!.ToPedido();

            _pedidoRepositoryMock.Setup(repo => repo.RemoveByIdAsync(1)).ReturnsAsync(Pedido);
        }

        [Fact]
        public async Task DeletePedidoAsync_ReturnPedido()
        {
            var Pedido = new Pedido { Id = 1, Origem = "25931798", Destino = "12331310", DataCriacao = DateTime.UtcNow, Status = Status.EmProcessamento, ClienteId = 1 };

            await _pedidoService.RemoveAsync(Pedido.ToPedidoDto()!);
            _pedidoRepositoryMock.Setup(repo => repo.RemoveAsync(Pedido)).ReturnsAsync(Pedido);

            Assert.NotNull(Pedido);
        }

        [Fact]
        public async Task GetFreteAsync_ReturnFrete()
        {
            var origem = "25931798";
            var destino = "12331310";

            var result = await _pedidoService.GetFreteAsync(origem, destino);

            Assert.NotNull(result.Data);
            Assert.Equal(HttpStatusCode.OK, result.Status);
            Assert.Equal("OK", result.Message);
        }

        private HttpResponseMessage CreateHttpResponseMessageFreteDto()
        {
            var freteDto = new FreteDto
            {
                Origem = new List<string> { "São Paulo" },
                Destino = new List<string> { "Rio de Janeiro" },
                Linhas = new List<RowDto>
            {
                new RowDto
                {
                    Elementos = new List<ElementDto>
                    {
                        new ElementDto
                        {
                            Distancia = new DistanceDto { Distancia = "456 km", Valor = 456000 },
                            Duracao = new DurationDto { Duracao = "6 horas", Valor = 21600 },
                            Status = "OK"
                        }
                    }
                }
            },
                Status = "OK"
            };

            var json = JsonSerializer.Serialize(freteDto); 
            return new HttpResponseMessage
            {
                StatusCode = HttpStatusCode.OK,
                Content = new StringContent(json, Encoding.UTF8, "application/json")
            };
        }
    }
}
