namespace StringsProcessing.Processors;

public class StringsTrimmingProcessor : StringsProcessor
{
    protected override string TransformWord(string word) => word.Substring(0, word.Length / 2);
}
