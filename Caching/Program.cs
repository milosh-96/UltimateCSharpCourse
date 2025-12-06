using CustomCache.App;

namespace CustomCache;

internal class Program
{
    static void Main(string[] args)
    {
        try
        {
            IApp app = new DataDownloadApp();
            app.Run();
        }
        catch(Exception ex)
        {
            Console.WriteLine("Something went wrong.");
            Console.WriteLine($"{ex.Message}, stack trace: {ex.StackTrace}");
        }

        Console.ReadKey();
    }
}
