using GameDataParser.Inputs;
using GameDataParser.Operations;
using GameDataParser.Outputs;

namespace GameDataParser;

public class GameDataParserApp : IGameDataParserApp
{
    private readonly IGamesOperation gamesOperation;
    private readonly IGamesDisplay gamesDisplay;
    private readonly IUserInput userInput;

    public GameDataParserApp(IGamesOperation gamesOperation, IGamesDisplay gamesDisplay, IUserInput userInput)
    {
        this.gamesOperation = gamesOperation;
        this.gamesDisplay = gamesDisplay;
        this.userInput = userInput;
    }

    public void Run()
    {
        string fileName = null;
        bool fileExists = false;
        do
        {
            var input = userInput.Enter("Enter file name: ");

            if (userInput.IsNotNullAndEmpty())
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
