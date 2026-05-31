using StarWarsPlanetsStats.Extensions;
using StarWarsPlanetsStats.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsPlanetsStats.UI;
public class Output : IOutput
{
    private readonly IUserInteractor _userInteractor;

    public Output(IUserInteractor userInteractor)
    {
        _userInteractor = userInteractor;
    }

    public void DisplayTable<T>(IEnumerable<T> items, char columnSeparator = '|', char headerSymbol = '-')
    {
        int minColumnWidth = typeof(T).GetProperties().Max(property => property.GetDisplayNameValue().Length) + 5;

        _userInteractor.Write(
            string.Join(columnSeparator,
            typeof(T).GetProperties().Select(property => property.GetDisplayNameValue().PadRight(minColumnWidth, ' '))
            ) + columnSeparator
            );

        _userInteractor.Write(Environment.NewLine);

        _userInteractor.Write(
            string.Join(headerSymbol,
            typeof(T).GetProperties().Select(property => string.Empty.PadRight(minColumnWidth, headerSymbol).PadRight(minColumnWidth, ' ')))
            + headerSymbol
            );

        _userInteractor.Write(Environment.NewLine);

        foreach (var item in items)
        {
            _userInteractor.WriteLine(
                string.Join(columnSeparator,
                typeof(Planet).GetProperties().Select(property => ((property?.GetValue(item)?.ToString() ?? string.Empty)).PadRight(minColumnWidth, ' ')
            )) + columnSeparator
                );
        }
        _userInteractor.WriteLine(Environment.NewLine);
    }
}
