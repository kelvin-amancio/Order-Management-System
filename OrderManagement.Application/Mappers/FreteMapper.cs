using OrderManagement.Application.Dtos;
using OrderManagement.Application.ViewModels;
using System.Globalization;

namespace OrderManagement.Application.Mappers
{
    public static class FreteMapper
    {
        public static FreteViewModel? ToFreteViewModel(this FreteDto freteDto)
        {
            if(freteDto is null)
                return null;

            return new FreteViewModel()
            {
                Origem = freteDto.Origem.First(),
                Destino = freteDto.Destino.First(),
                Distancia = freteDto.Linhas.First().Elementos.First().Distancia.Distancia,
                Duracao = freteDto.Linhas.First().Elementos.First().Duracao.Duracao,
                Frete = CalcularFrete(freteDto.Linhas.First().Elementos.First().Distancia.Valor),
                Status = freteDto.Status
            };
        }

        private static string CalcularFrete(double distancia)
        {
            double distanciaKm = distancia / 1000;
            double taxaBase = 50.00;
            double taxaKm = 12.00;
            var calculo = taxaBase + (taxaKm * distanciaKm);
            return calculo.ToString("C", CultureInfo.CurrentCulture);
        }
    }
}
