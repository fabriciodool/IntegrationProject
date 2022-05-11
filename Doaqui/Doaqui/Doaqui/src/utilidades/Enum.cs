using System.Text.Json.Serialization;

namespace Doaqui.src.utilidades
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum TipoUsuario
    {
        ONG,
        ADMINISTRADOR
    }
}