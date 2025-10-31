using GameDataParser.Helpers;
using GameDataParser.Operations;
using GameDataParser.Outputs;

namespace GameDataParser;

internal class Program
{
    static void Main(string[] args)
    {
        try
        {
            IGameDataParserApp app = new GameDataParserApp(new GamesFromJsonOperation(new FileReader()), new GamesDisplay());
            app.Run();
        }
        catch(Exception ex)
        {
            Console.WriteLine($"Sorry! The application has experienced an unexpected error and will have to be closed.");
            File.AppendAllText("log.txt", $"[{DateTime.Now.ToString("dd/MM/yyyy HH:mm:ss")}], Exception message:{ex.Message}, Stack trace: {ex.StackTrace}\n");
        }
    }
}
