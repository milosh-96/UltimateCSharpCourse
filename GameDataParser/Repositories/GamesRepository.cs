using GameDataParser.Data;
using GameDataParser.Helpers;
using System.Text.Json;

namespace GameDataParser.Repositories;

public class GamesRepository : IGamesRepository
{
    private readonly IFileReader fileReader;

    private List<Game> games = new List<Game>();
    public GamesRepository(IFileReader fileReader)
    {
        this.fileReader = fileReader;
    }

    public List<Game> All()
    {
        return games;
    }

    public void Load(string fileName)
    {
        string contents = fileReader.Read(fileName);
        try
        {
            var parsedGames = JsonSerializer.Deserialize<List<Game>>(contents);
            games.AddRange(parsedGames);
        }
        catch (JsonException ex)
        {
            Console.ForegroundColor = ConsoleColor.Red;
            Console.WriteLine($"JSON in the {fileName} was not in a valid format. JSON body: {contents}.");
            Console.ResetColor();
            throw;
        }
    }
}