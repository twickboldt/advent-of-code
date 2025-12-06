using Runner.Puzzles._2025;

namespace Runner.Tests.Puzzles._2025;

public class Day6Tests
{
    private const string Input = """
                                 123 328  51 64 
                                  45 64  387 23 
                                   6 98  215 314
                                 *   +   *   +  
                                 """;

    private readonly Day6 _instance = new Day6();

    [Fact]
    public void Puzzle1()
    {
        var result = _instance.SolvePuzzle1(Input.Split('\n'));
        Assert.Equal(4277556, result);
    }

    [Fact]
    public void Puzzle2()
    {
        var result = _instance.SolvePuzzle2(Input.Split('\n'));
        Assert.Equal(3263827, result);
    }
}