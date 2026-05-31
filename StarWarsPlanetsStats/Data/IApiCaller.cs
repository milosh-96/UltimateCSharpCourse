namespace StarWarsPlanetsStats.Data;

public interface IApiCaller
{
    Task<Stream> GetAsync(string? endpoint);
}