using System.Text.Json.Serialization;

namespace OrderManagement.Application.Dtos
{
    public class FreteDto
    {
        [JsonPropertyName("origin_addresses")]
        public List<string> Origem { get; set; } = null!;
        [JsonPropertyName("destination_addresses")]
        public List<string> Destino { get; set; } = null!;
        [JsonPropertyName("rows")]
        public List<RowDto> Linhas { get; set; } = null!;
        [JsonPropertyName("status")]
        public string Status { get; set; } = null!;
    }

    public class ElementDto
    {
        [JsonPropertyName("distance")]
        public DistanceDto Distancia { get; set; } = null!;

        [JsonPropertyName("duration")]
        public DurationDto Duracao { get; set; } = null!;

        [JsonPropertyName("status")]
        public string Status { get; set; } = null!;
    }

    public class RowDto
    {
        [JsonPropertyName("elements")]
        public List<ElementDto> Elementos { get; set; } = null!;
    }

    public class DistanceDto
    {
        [JsonPropertyName("text")]
        public string Distancia { get; set; } = null!;

        [JsonPropertyName("value")]
        public int Valor { get; set; }
    }

    public class DurationDto
    {
        [JsonPropertyName("text")]
        public string Duracao { get; set; } = null!;

        [JsonPropertyName("value")]
        public int Valor { get; set; }
    }
}
