namespace TicketsAggregator.UserInteraction;

internal static class UserInput
{
    public static string? GetFolderPath()
    {
        Console.WriteLine("Enter the path to your PDF files:");
        return Console.ReadLine();
    }
}
