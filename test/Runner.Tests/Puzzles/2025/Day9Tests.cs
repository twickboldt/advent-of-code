using Runner.Puzzles._2025;

namespace Runner.Tests.Puzzles._2025;

public class Day9Tests
{
    private const string Input = """
                                 7,1
                                 11,1
                                 11,7
                                 9,7
                                 9,5
                                 2,5
                                 2,3
                                 7,3
                                 """;

    private readonly Day9 _instance = new Day9();

    [Fact]
    public void Puzzle1()
    {
        var result = _instance.SolvePuzzle1(Input.Split('\n'));
        Assert.Equal(50, result);
    }

    [Fact]
    public void Puzzle2()
    {
        var result = _instance.SolvePuzzle2(Input.Split('\n'));
        Assert.Equal(24, result);
    }
}