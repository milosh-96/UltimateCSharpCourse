using System.Globalization;
using TicketsAggregator.Localization;
using TicketsAggregator.Models;
using UglyToad.PdfPig;
using UglyToad.PdfPig.DocumentLayoutAnalysis.TextExtractor;

namespace TicketsAggregator.Parsers;

internal static class TicketParser
{
    public static List<Ticket> ParseTicketsFromPDF(PdfDocument document)
    {
        List<Ticket> tickets = new List<Ticket>();

        Dictionary<string, List<string>> lineData = ExtractDataFromDocument(document);

        for (int i = 0; i < lineData["titles"].Count; i++)
        {
            tickets.Add(new Ticket()
            {
                Title = lineData["titles"][i],
                Start = DateTime.Parse($"{lineData["dates"][i]} {lineData["times"][i]}", CultureInfo.CurrentCulture)
            });
        }
        return tickets;
    }

    private static Dictionary<string, List<string>> ExtractDataFromDocument(PdfDocument document)
    {
        Dictionary<string, List<string>> lineData = new Dictionary<string, List<string>>()
        {
            { "titles", new List<string>() },
            { "dates", new List<string>() },
            { "times", new List<string>() }
        };
        List<CultureInfo> cultures = new List<CultureInfo>();

        foreach (var page in document.GetPages())
        {
            string text = ContentOrderTextExtractor.GetText(page);

            SetCultureBasedOnDomainOrUseInvariant(text);

            foreach (string line in text.Split('\n'))
            {
                string titleProperty = "Title";

                if (line.StartsWith(titleProperty))
                {
                    lineData["titles"].Add(line.Replace("\r", "").Replace(": ", "").Replace(titleProperty, "").ReplaceLineEndings());
                }


                string dateProperty = "Date";
                if (line.StartsWith(dateProperty))
                {
                    string date = line.Replace("\r", "").Replace(": ", "").Replace(dateProperty, "").ToString().ReplaceLineEndings();
                    lineData["dates"].Add(date);
                }

                string timeProperty = "Time";
                if (line.StartsWith(timeProperty))
                {
                    lineData["times"].Add(line.Replace("\r", "").Replace(": ", "").Replace(timeProperty, "").ToString().ReplaceLineEndings());
                }
            }
        }
        return lineData;
    }

    private static void SetCultureBasedOnDomainOrUseInvariant(string text)
    {
        if (text.Contains(".com"))
        {
            CultureManager.SetCurrentCultureOrUseInvariant(CultureInfo.GetCultureInfo("en-US"));
        }
        else if (text.Contains(".jp"))
        {
            CultureManager.SetCurrentCultureOrUseInvariant(CultureInfo.GetCultureInfo("en-US"));
        }
        else if (text.Contains(".fr"))
        {
            CultureManager.SetCurrentCultureOrUseInvariant(CultureInfo.GetCultureInfo("en-US"));
        }
        else
        {
            CultureManager.SetCurrentCultureOrUseInvariant();
        }
    }
}
