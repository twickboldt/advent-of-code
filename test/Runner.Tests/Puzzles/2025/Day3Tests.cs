using Runner.Puzzles._2025;

namespace Runner.Tests.Puzzles._2025;

public class Day3Tests
{
    private const string Input = """
                                 987654321111111
                                 811111111111119
                                 234234234234278
                                 818181911112111
                                 """;

    private readonly Day3 _instance = new Day3();

    [Fact]
    public void Puzzle1()
    {
        var result = _instance.SolvePuzzle1(Input.Split('\n'));
        Assert.Equal(357, result);
    }

    [Fact]
    public void Puzzle2()
    {
        var result = _instance.SolvePuzzle2(Input.Split('\n'));
        Assert.Equal(3121910778619, result);
    }
}