namespace StringsProcessing.Processors;

public class StringsTrimmingProcessor : StringsProcessor
{
    protected override string TransformWord(string word)
    {
        if(string.IsNullOrEmpty(word))
        {
            throw new ArgumentException();
        }
        return word.Substring(0, word.Length / 2);
    }
}
