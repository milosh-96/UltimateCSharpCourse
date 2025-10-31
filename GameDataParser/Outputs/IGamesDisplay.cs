using GameDataParser.Data;

namespace GameDataParser.Outputs;
public interface IGamesDisplay
{
    void Show(IEnumerable<Game> games);
}