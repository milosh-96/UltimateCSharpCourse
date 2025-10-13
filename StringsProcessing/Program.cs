using StringsProcessing.Processors;

namespace StringsProcessing;

internal class Program
{
    static List<string> words = new() { "bobcat", "wolverine", "grizzly" };
    static void Main(string[] args)
    {
        var stringsProcessors = new List<StringsProcessor>
                {
                    new StringsTrimmingProcessor(),
                    new StringsUppercaseProcessor()
                };

        List<string> result = words;
        foreach (var stringsProcessor in stringsProcessors)
        {
            result = stringsProcessor.Process(result);
        }
        Console.WriteLine(string.Join(',', result));
    }
}
