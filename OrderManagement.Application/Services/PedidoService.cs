using OrderManagement.Application.Dtos;
using OrderManagement.Application.Interfaces;
using OrderManagement.Application.Mappers;
using OrderManagement.Application.ViewModels;
using OrderManagement.Domain.Core.Helpers;
using OrderManagement.Domain.Interfaces;
using System.Net;
using System.Text.Json;

namespace OrderManagement.Application.Services
{
    public class PedidoService(IPedidoRepository pedidoRepository, IHttpClientFactory httpClientFactory) : IPedidoService
    {
        private readonly IPedidoRepository _pedidoRepository = pedidoRepository;
        private readonly IHttpClientFactory _httpClientFactory = httpClientFactory;

        public async Task<IEnumerable<PedidoViewModel>> GetAllAsync()
        {
            var pedidos = await _pedidoRepository.GetAllAsync();
            return pedidos.ToPedidosViewModel();
        }

        public async Task<PedidoViewModel?> GetByIdAsync(int id)
        {
            var pedido = await _pedidoRepository.GetByIdAsync(id);
            return pedido!.ToPedidoViewModel();
        }

        public async Task<PedidoDto> CreateAsync(PedidoDto pedidoDto)
        {
            var pedido = await _pedidoRepository.CreateAsync(pedidoDto.ToPedido()!);
            return pedido.ToPedidoDto()!;
        }
        public async Task<PedidoDto> UpdateAsync(PedidoDto pedidoDto)
        {
            var pedido = await _pedidoRepository.UpdateAsync(pedidoDto.ToPedido()!);
            return pedido!.ToPedidoDto()!;
        }

        public async Task<PedidoDto> RemoveAsync(PedidoDto pedidoDto)
        {
            var pedido = await _pedidoRepository.RemoveAsync(pedidoDto.ToPedido()!);
            return pedido!.ToPedidoDto()!;
        }

        public async Task<PedidoDto?> RemoveByIdAsync(int id)
        {
            var pedido = await _pedidoRepository.RemoveByIdAsync(id);
            return pedido!.ToPedidoDto()!;
        }

        public async Task<FreteResultViewModel<FreteViewModel?>> GetFreteAsync(string origem, string destino)
        {
            var client = _httpClientFactory.CreateClient("MapsApi");

            var origemReplace = origem.Trim().Replace(" ", "");
            var destinationReplace = destino.Trim().Replace(" ", "");

            using var response = await client.GetAsync($"/maps/api/distancematrix/json?origins={origemReplace}&destinations={destinationReplace}&key={StringHelpers.MapsKey}");

            if (response.IsSuccessStatusCode)
            {
                var responseStream = await response.Content.ReadAsStreamAsync();
                var teste = await response.Content.ReadAsStringAsync();
                var freteDto = JsonSerializer.Deserialize<FreteDto>(responseStream);
                var status = freteDto!.Linhas.First().Elementos.First().Status;

                if (status != "OK")
                    return new FreteResultViewModel<FreteViewModel>(null!, HttpStatusCode.NotFound, status)!;

                var freteViewModel = freteDto!.ToFreteViewModel();

                return new FreteResultViewModel<FreteViewModel>(freteViewModel!, HttpStatusCode.OK, status)!;
            }

            return new FreteResultViewModel<FreteViewModel>(null!, HttpStatusCode.BadRequest, "BAD_REQUEST")!;
        }


    }
}
