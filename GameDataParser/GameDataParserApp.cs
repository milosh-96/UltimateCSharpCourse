using GameDataParser.Inputs;
using GameDataParser.Repositories;
using GameDataParser.Outputs;

namespace GameDataParser;

public class GameDataParserApp : IGameDataParserApp
{
    private readonly IGamesRepository _gamesRepository;
    private readonly IGamesDisplay _gamesDisplay;
    private readonly IUserInput _userInput;

    public GameDataParserApp(IGamesRepository gamesRepository, IGamesDisplay gamesDisplay, IUserInput userInput)
    {
        _gamesRepository = gamesRepository;
        _gamesDisplay = gamesDisplay;
        _userInput = userInput;
    }

    public void Run()
    {
        string fileName = null;
        bool fileExists = false;
        do
        {
            var input = _userInput.Get("Enter file name: ");

            if (_userInput.IsNotNullAndEmpty())
            {
                fileName = input;
            }

            if (File.Exists(fileName))
            {
                fileExists = true;
                _gamesRepository.Load(fileName);
                _gamesDisplay.Show(_gamesRepository.All());
            }
            else
            {
                Console.WriteLine("File not found.");
            }

        }
        while (fileName == null || fileExists == false);
    }
}
