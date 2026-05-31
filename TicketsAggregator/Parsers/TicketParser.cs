using System;
using System.Collections.Generic;
using System.Globalization;
using System.Linq;
using System.Reflection.Metadata;
using System.Text;
using System.Threading.Tasks;
using TicketsAggregator.Models;
using UglyToad.PdfPig;
using UglyToad.PdfPig.DocumentLayoutAnalysis.TextExtractor;
using static System.Net.Mime.MediaTypeNames;

namespace TicketsAggregator.Parsers;
internal static class TicketParser
{
    public static List<Ticket> ParseTicketsFromPDF(PdfDocument document)
    {
        List<Ticket> tickets = new List<Ticket>();

        List<string> titles = new List<string>();
        List<string> dates = new List<string>();
        List<string> times = new List<string>();
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
                    titles.Add(line.Replace("\r", "").Replace(": ", "").Replace(titleProperty, "").ReplaceLineEndings());
                }


                string dateProperty = "Date";
                if (line.StartsWith(dateProperty))
                {
                    string date = line.Replace("\r", "").Replace(": ", "").Replace(dateProperty, "").ToString().ReplaceLineEndings();
                    dates.Add(date);
                }

                string timeProperty = "Time";
                if (line.StartsWith(timeProperty))
                {
                    times.Add(line.Replace("\r", "").Replace(": ", "").Replace(timeProperty, "").ToString().ReplaceLineEndings());
                }
            }
        }

        for (int i = 0; i < titles.Count; i++)
        {
            tickets.Add(new Ticket()
            {
                Title = titles[i],
                Start = DateTime.Parse($"{dates[i]} {times[i]}", CultureInfo.CurrentCulture)
            });
        }
        return tickets;
    }

    private static void SetCultureBasedOnDomainOrUseInvariant(string text)
    {
        if (text.Contains(".com"))
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("en-US");
        }
        else if (text.Contains(".jp"))
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("ja-JP");
        }
        else if (text.Contains(".fr"))
        {
            CultureInfo.CurrentCulture = CultureInfo.GetCultureInfo("fr-FR");
        }
        else
        {
            CultureInfo.CurrentCulture = CultureInfo.InvariantCulture;
        }
    }
}
