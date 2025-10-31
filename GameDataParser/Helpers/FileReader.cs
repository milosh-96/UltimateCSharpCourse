namespace GameDataParser.Helpers;
public class FileReader : IFileReader
{
    public string Read(string fileName)
    {
        return File.ReadAllText(fileName);
    }
}
