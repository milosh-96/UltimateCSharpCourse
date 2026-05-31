using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TicketsAggregator.UserInteraction;
internal static class UserInput
{
    public static string? GetFolderPath()
    {
        Console.WriteLine("Enter the path to your PDF files:");
        return Console.ReadLine();
    }
}
