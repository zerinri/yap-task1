using System.Text.Json.Serialization;

namespace server.Models
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UnitMeasure
    {

        kg,
        g,
        l,
        ml,

    }
}
