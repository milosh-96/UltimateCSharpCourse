using System.Globalization;
using TicketsAggregator.Models;

namespace TicketsAggregator.Writers;
internal class TicketsTextWriter : TicketsWriter
{
    public TicketsTextWriter(string fileName) : base(fileName)
    {
    }

    public override void Write(string folderPath, List<Ticket> tickets, CultureInfo? cultureInfo = null)
    {
        using StreamWriter writer = new StreamWriter(File.OpenWrite(folderPath + $"/{_fileName}"));
        tickets.ForEach(ticket =>
        {
            string line = string.Format("{0,-45} | {1} | {2} ", ticket.Title, ticket.Start?.ToShortDateString(), ticket.Start?.ToShortTimeString());
            Console.WriteLine(line);
            writer.WriteLine(line);
        });
    }
}
