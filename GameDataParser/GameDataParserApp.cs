using GameDataParser.Helpers;
using GameDataParser.Inputs;
using GameDataParser.Operations;
using GameDataParser.Outputs;
using System.Text.Json;

namespace GameDataParser;

public class GameDataParserApp : IGameDataParserApp
{
    private readonly IGamesOperation gamesOperation;
    private readonly IGamesDisplay gamesDisplay;

    public GameDataParserApp(IGamesOperation gamesOperation, IGamesDisplay gamesDisplay)
    {
        this.gamesOperation = gamesOperation;
        this.gamesDisplay = gamesDisplay;
    }

    public void Run()
    {
        string fileName = null;
        bool fileExists = false;
        do
        {
            var input = UserInput.Enter("Enter file name: ");

            if (UserInput.IsNotNullAndEmpty(input))
            {
                fileName = input;
            }

            if (File.Exists(fileName))
            {
                fileExists = true;
                var games = gamesOperation.LoadGames(fileName);
                gamesDisplay.Show(games);
            }
            else
            {
                Console.WriteLine("File not found.");
            }

        }
        while (fileName == null || fileExists == false);

    }
}
