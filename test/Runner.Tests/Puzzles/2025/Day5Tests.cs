using Runner.Puzzles._2025;

namespace Runner.Tests.Puzzles._2025;

public class Day5Tests
{
    private const string Input = """
                                 3-5
                                 10-14
                                 16-20
                                 12-18
                                 
                                 1
                                 5
                                 8
                                 11
                                 17
                                 32
                                 """;

    private readonly Day5 _instance = new Day5();

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
        Assert.Equal(14, result);
    }
}