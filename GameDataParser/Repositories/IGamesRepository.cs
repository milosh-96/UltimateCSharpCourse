using GameDataParser.Data;

namespace GameDataParser.Repositories;

public interface IGamesRepository
{
    List<Game> All();
    void Load(string fileName);
}
