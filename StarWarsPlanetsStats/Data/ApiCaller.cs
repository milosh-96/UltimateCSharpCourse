using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsPlanetsStats.Data;
public class HttpApiCaller : IApiCaller
{
    public Uri BaseAddress { get; init; }

    public HttpApiCaller()
    {
        throw new ArgumentException($"Please provide the {nameof(BaseAddress)}.");
    }
    public HttpApiCaller(string baseAddress)
    {
        BaseAddress = new Uri(baseAddress);
    }
    public async Task<Stream> GetAsync(string? endpoint)
    {
        ArgumentException.ThrowIfNullOrEmpty(endpoint);

        using HttpClient httpClient = new() { BaseAddress = BaseAddress };
        return await (await httpClient.GetAsync(endpoint)).Content.ReadAsStreamAsync();
    }
}
