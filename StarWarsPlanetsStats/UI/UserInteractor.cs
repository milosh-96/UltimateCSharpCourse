using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace StarWarsPlanetsStats.UI;
public class UserInteractor : IUserInteractor
{
    public ConsoleKeyInfo ReadKey()
    {
        return Console.ReadKey();
    }

    public string? ReadLine()
    {
        return Console.ReadLine();
    }

    public void Write(string? input)
    {
        Console.Write(input);
    }
    public void WriteLine(string? input)
    {
        Write(input);
        Console.Write(Environment.NewLine);
    }
}
