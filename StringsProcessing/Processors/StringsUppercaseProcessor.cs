namespace StringsProcessing.Processors;

public class StringsUppercaseProcessor : StringsProcessor
{
    protected override string TransformWord(string word) => word.ToUpper();
}
