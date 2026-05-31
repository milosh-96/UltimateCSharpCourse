using TicketsAggregator.Models;
using TicketsAggregator.Writers;
using TicketsAggregator.Parsers;
using UglyToad.PdfPig;
using TicketsAggregator.Localization;
using TicketsAggregator.UserInteraction;

namespace TicketsAggregator.App;

internal class TicketsAggregatorApp
{
    private readonly List<ITicketsWriter> writers;

    public TicketsAggregatorApp(List<ITicketsWriter> writers)
    {
        this.writers = writers;
    }

    public void Run()
    {
        string? folderPath = null;
        do
        {
            folderPath = UserInput.GetFolderPath();
            if (!Directory.Exists(folderPath))
            {
                Console.WriteLine($"The directory doesn't exist ({folderPath}).");
            }
        }
        while (folderPath is null || !Directory.Exists(folderPath));


        var tickets = new List<Ticket>();

        foreach (var file in Directory.GetFiles(folderPath, "*.pdf"))
        {
            using (PdfDocument document = PdfDocument.Open(file))
            {
                tickets.AddRange(TicketParser.ParseTicketsFromPDF(document));
            }
        }

        CultureManager.SetCurrentCultureOrUseInvariant();

        foreach(var writer in writers)
        {
            writer.Write(folderPath, tickets);
        }
    }
}
