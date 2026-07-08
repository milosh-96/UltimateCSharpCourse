using StringsProcessing.Processors;

namespace StringsProcessingTests;

public class StringsTrimmingProcessorTests
{
   
    [TestCase("n", "no")]
    [TestCase("c", "cat")]
    [TestCase("d", "dog")]
    [TestCase("sn", "snake")]
    [TestCase("wolve", "wolverline")]
    [TestCase("griz", "grizzlie")]
    [TestCase("be", "bear")]
    [TestCase("elep", "elephant")]
    public void TransformWord_ShouldReturnHalfOfString_WhenWordsAreLargerThanOneCharacter(string expected, string actual)
    {
        var processor = new StringsTrimmingProcessor();
        Assert.AreEqual(new List<string>() { expected },processor.Process(new List<string>() { actual }));
    }
    [Test]
    public void TransformWord_ShouldThrowArgumentException_IfEmptyString()
    {
        var processor = new StringsTrimmingProcessor();
        Assert.Throws<ArgumentException>(() => processor.Process(new List<string>() { "" }));
    }
}