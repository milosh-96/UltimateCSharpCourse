using FibonacciGenerator;
using NUnit.Framework;

namespace FibonacciGeneratorTests;

public class FibonacciTests
{
    [TestCase(-1)]
    [TestCase(-36)]
    public void Generate_ShouldThrowException_IfInputIsLessThan0(int input)
    {
        Assert.Throws<ArgumentException>(() => Fibonacci.Generate(input));
    }

    [TestCase(47)]
    public void Generate_ShouldThrowException_IfInputIsLargerThan46(int input)
    {
        Assert.Throws<ArgumentException>(() => Fibonacci.Generate(input));
    }

    [TestCaseSource(nameof(FibonacciSequences))]
    public void Generate_ShouldReturnCorrectSequence_ForGivenInput(FibonacciSequence testSequence)
    {
        var actual = Fibonacci.Generate(testSequence.Input).ToList();
        Assert.AreEqual(testSequence.Expected, actual);
    }

    public static FibonacciSequence[] FibonacciSequences = [
            new() { Input = 0, Expected = []},
            new() { Input = 1, Expected = [0]},
            new() { Input = 2, Expected = [0,1] },
            new() { Input = 3, Expected = [0,1,1] },
            new() { Input = 5, Expected = [0,1,1,2,3] },
            new() { Input = 8, Expected = [0,1,1,2,3,5,8,13] },
            new() { Input = 17, Expected = [0,1,1,2,3,5,8,13,21,34,55,89,144,233, 377, 610,987] },
        ];

    public record struct FibonacciSequence
    {
        public int Input { get; init; }
        public int[] Expected { get; init; }
    }
}
