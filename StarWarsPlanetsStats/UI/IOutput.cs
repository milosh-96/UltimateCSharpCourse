
namespace StarWarsPlanetsStats.UI;

public interface IOutput
{
    void DisplayTable<T>(IEnumerable<T> items, char columnSeparator = '|', char headerSymbol = '-');
}