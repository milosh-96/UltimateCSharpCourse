using GameDataParser.Data;

namespace GameDataParser.Operations;
public interface IGamesOperation
{
    List<Game> LoadGames(string fileName);
}
