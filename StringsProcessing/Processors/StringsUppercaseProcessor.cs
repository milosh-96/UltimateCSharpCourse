namespace StringsProcessing.Processors;

public class StringsUppercaseProcessor : StringsProcessor
{
    protected override string TransformWord(string word)
    {
        if (string.IsNullOrEmpty(word))
        {
            throw new ArgumentException();
        }
        return word.ToUpper();
    }
}
