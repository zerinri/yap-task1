using System.Text.Json.Serialization;

namespace Server.Common.Entities
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
