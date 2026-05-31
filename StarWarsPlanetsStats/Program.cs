using StarWarsPlanetsStats.App;
using StarWarsPlanetsStats.Data;
using StarWarsPlanetsStats.UI;

namespace StarWarsPlanetsStats;

internal class Program
{
    static async Task Main()
    {
        IUserInteractor userInteractor = new UserInteractor();
        IApp app = new StarWarsApp(
            userInteractor,
            new HttpApiCaller("https://swapi.info/api/"),
            new PlanetsFetcher(),
            new Output(userInteractor)
        );
        await app.RunAsync();
        //try
        //{

        //}
        //catch(Exception e)
        //{
        //    Console.WriteLine($"An error has occured, reason: {e.Message} Please contact the developer. ");
        //}
        Console.ReadKey();
    }
}
