using GameDataParser.Data;
using GameDataParser.Helpers;
using GameDataParser.Inputs;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text.Json;

namespace GameDataParser.Operations;

public class GamesFromJsonOperation : IGamesOperation
{
    private readonly IFileReader fileReader;

    public GamesFromJsonOperation(IFileReader fileReader)
    {
        this.fileReader = fileReader;
    }

    public List<Game> LoadGames(string fileName)
    {
        string contents = fileReader.Read(fileName);
        try
        {
            return JsonSerializer.Deserialize<List<Game>>(contents);
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
