using GameDataParser.Data;

namespace GameDataParser.Outputs;

public class GamesDisplay : IGamesDisplay
{
    public void Show(IEnumerable<Game> games)
    {
        if (games.Count() > 0)
        {
            Console.WriteLine("Loaded games are: ");
            foreach (var game in games)
            {
                Console.WriteLine(game);
            }
        }
        else
        {
            Console.WriteLine("No games are present in the input file.");
        }
    }
}
