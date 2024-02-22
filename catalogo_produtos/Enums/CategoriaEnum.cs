using System.Text.Json.Serialization;

namespace catalogo_produtos.Enums
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum CategoriaEnum
    {
        Cozinha,
        Tecnologia,
        Banheiro,
        Carro,
        Beleza
    }
}
