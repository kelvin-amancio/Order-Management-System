using OrderManagement.Application.Dtos;
using OrderManagement.Application.ViewModels;
using OrderManagement.Domain.Entities;
using OrderManagement.Domain.Enums;

namespace OrderManagement.Application.Mappers
{
    public static class PedidoMapper
    {
        public static PedidoDto? ToPedidoDto(this Pedido pedido)
        {
            if (pedido is null)
                return null;

            return new PedidoDto()
            {
                Id = pedido.Id,
                Origem = pedido.Origem,
                Destino = pedido.Destino,
                DataCriacao = pedido.DataCriacao,
                Status = pedido.Status,
                ClienteId = pedido.ClienteId
            };
        }

        public static PedidoViewModel? ToPedidoViewModel(this Pedido pedido)
        {
            if (pedido is null)
                return null;

            return new PedidoViewModel()
            {
                Id = pedido.Id,
                Origem = pedido.Origem,
                Destino = pedido.Destino,
                DataCriacao = pedido.DataCriacao,
                Status = StatusBuilder(pedido.Status),
                Cliente = pedido.Cliente!.ToClienteViewModel()!
            };
        }

        private static string StatusBuilder(Status status)
        {
            return status switch
            {
                Status.EmProcessamento => "Em Processamento",
                Status.Enviado => "Em Processamento",
                Status.Entregue => "Entregue",
                Status.Cancelado => "Cancelado",
                _ => "",
            };
        }

        public static Pedido? ToPedido(this PedidoDto pedidoDto)
        {
            if (pedidoDto is null)
                return null;

            return new Pedido()
            {
                Id = pedidoDto.Id,
                Origem = pedidoDto.Origem,
                Destino = pedidoDto.Destino,
                DataCriacao = pedidoDto.DataCriacao,
                Status = pedidoDto.Status,
                ClienteId = pedidoDto.ClienteId
            };
        }

        public static IEnumerable<PedidoDto> ToPedidosDto(this IEnumerable<Pedido> pedidos)
        {
            var pedidosDto = new List<PedidoDto>();

            foreach (var pedido in pedidos)
                pedidosDto.Add(ToPedidoDto(pedido)!);

            return pedidosDto;
        }


        public static IEnumerable<PedidoViewModel> ToPedidosViewModel(this IEnumerable<Pedido> pedidos)
        {
            var pedidosViewModel = new List<PedidoViewModel>();

            foreach (var pedido in pedidos)
                pedidosViewModel.Add(ToPedidoViewModel(pedido)!);

            return pedidosViewModel;
        }
    }
}
