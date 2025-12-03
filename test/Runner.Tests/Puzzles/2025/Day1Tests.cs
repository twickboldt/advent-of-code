using Runner.Puzzles._2025;

namespace Runner.Tests.Puzzles._2025;

public class Day1Tests
{
    private const string Input = """
                                 L68
                                 L30
                                 R48
                                 L5
                                 R60
                                 L55
                                 L1
                                 L99
                                 R14
                                 L82
                                 """;

    private readonly Day1 _instance = new Day1();

    [Fact]
    public void Puzzle1()
    {
        var result = _instance.SolvePuzzle1(Input.Split('\n'));
        Assert.Equal(3, result);
    }

    [Fact]
    public void Puzzle2()
    {
        var result = _instance.SolvePuzzle2(Input.Split('\n'));
        Assert.Equal(6, result);
    }
}