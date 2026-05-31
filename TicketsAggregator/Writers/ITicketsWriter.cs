using System.Globalization;
using TicketsAggregator.Models;

namespace TicketsAggregator.Writers;
internal interface ITicketsWriter
{
    void Write(string filePath, List<Ticket> tickets, CultureInfo? cultureInfo = null);
}