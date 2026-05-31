using StarWarsPlanetsStats.Converters;
using StarWarsPlanetsStats.Models;
using System.Text.Json;

namespace StarWarsPlanetsStats.Data;
public class PlanetsFetcher : IPlanetsFetcher
{
    private readonly JsonSerializerOptions serializerOptions = new();
    public PlanetsFetcher()
    {
        serializerOptions.Converters.Add(new NullableIntJsonConverter());
    }
    public async Task<List<Planet>?> GetFromJsonAsync(Stream stream, int limit = 10, int offset = 0)
    {
        List<Planet> planets = [];
        // convert the data to planets

        List<Planet>? result = await JsonSerializer.DeserializeAsync<List<Planet>>(stream, serializerOptions);

        if (result is not null && result.Count != 0)
        {
            planets.AddRange(result);
        }
        return planets.Skip(offset).Take(limit).ToList();
    }
}
