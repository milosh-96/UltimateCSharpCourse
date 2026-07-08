using StringsProcessing.Processors;

namespace StringsProcessingTests;

public class StringsUppercaseProcessorTests
{
   
    [TestCase("N", "n")]
    [TestCase("CAT", "cat")]
    [TestCase("DOG", "dog")]
    [TestCase("SNAKE", "snake")]
    [TestCase("WOLVERLINE", "wolverline")]
    [TestCase("GRIZZLIE", "grizzlie")]
    [TestCase("BEAR", "bear")]
    [TestCase("ELEPHANT", "elephant")]
    public void TransformWord_ShouldReturnUppercaseString_WhenWordsAreLargerThanOneCharacter(string expected, string actual)
    {
        var processor = new StringsUppercaseProcessor();
        Assert.AreEqual(new List<string>() { expected },processor.Process(new List<string>() { actual }));
    }
    [Test]
    public void TransformWord_ShouldThrowArgumentException_IfEmptyString()
    {
        var processor = new StringsUppercaseProcessor();
        Assert.Throws<ArgumentException>(() => processor.Process(new List<string>() { "" }));
    }
}