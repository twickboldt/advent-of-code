using Runner.Puzzles._2023;

namespace Runner.Tests.Puzzles._2023;

public class Day3Tests
{
    private const string Input = """
                                 467..114..
                                 ...*......
                                 ..35..633.
                                 ......#...
                                 617*......
                                 .....+.58.
                                 ..592.....
                                 ......755.
                                 ...$.*....
                                 .664.598..
                                 """;
    
    private readonly Day3 _instance = new();

    [Fact]
    public void Puzzle1()
    {
        var result = _instance.SolvePuzzle1(Input.Split('\n'));
        Assert.Equal(4361, result);
    }
    
    [Fact]
    public void Puzzle2()
    {
        var result = _instance.SolvePuzzle2(Input.Split('\n'));
        Assert.Equal(467835, result);
    }
}