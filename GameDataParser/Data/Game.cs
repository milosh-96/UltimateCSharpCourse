namespace GameDataParser.Data;
public class Game
{
    public string Title { get; init; }
    public int ReleaseYear { get; init; }
    public float Rating { get; init; }

    public override string ToString()
    {
        return $"{Title}, released in {ReleaseYear}, rating: {Rating}";
    }
}
