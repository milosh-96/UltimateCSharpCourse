using TicketsAggregator.App;
using TicketsAggregator.Writers;

namespace TicketsAggregator;

internal class Program
{
    static void Main(string[] args)
    {
        var app = new TicketsAggregatorApp(new List<ITicketsWriter>()
        {
            new TicketsTextWriter("aggregatedTickets.txt"),
        });

        app.Run();
        Console.ReadKey();
    }
}
