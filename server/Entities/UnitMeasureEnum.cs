using System.Text.Json.Serialization;

namespace server.Entities
{
    [JsonConverter(typeof(JsonStringEnumConverter))]
    public enum UnitMeasureEnum
    {

        kg = 0,
        g = 1,
        l = 2,
        ml = 3,

    }
}
