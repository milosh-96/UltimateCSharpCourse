namespace StarWarsPlanetsStats.UI;

public interface IUserInteractor
{
    void Write(string? input);
    void WriteLine(string? input);

    string? ReadLine();
    ConsoleKeyInfo ReadKey();
}