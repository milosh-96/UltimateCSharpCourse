using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Text.Json;
using System.Text.Json.Serialization;
using System.Threading.Tasks;

namespace StarWarsPlanetsStats.Converters;
internal class NullableIntJsonConverter : JsonConverter<int?>
{
    public override int? Read(ref Utf8JsonReader reader, Type typeToConvert, JsonSerializerOptions options)
    {
        int? @int = null;
        int result = 0;
        if (int.TryParse(reader.GetString(), out result))
        {
            @int = result;
        }
        return @int;
    }

    public override void Write(Utf8JsonWriter writer, int? value, JsonSerializerOptions options)
    {
        throw new NotImplementedException();
    }
}
