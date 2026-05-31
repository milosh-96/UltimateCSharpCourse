using StarWarsPlanetsStats.Models;

namespace StarWarsPlanetsStats.Data;

public interface IPlanetsFetcher
{
    Task<List<Planet>?> GetFromJsonAsync(Stream stream, int limit = 10, int offset = 0);
}