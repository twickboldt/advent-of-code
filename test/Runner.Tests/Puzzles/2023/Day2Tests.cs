using Runner.Puzzles._2023;

namespace Runner.Tests.Puzzles._2023;

public class Day2Tests
{
    private const string Input = """
                                 Game 1: 3 blue, 4 red; 1 red, 2 green, 6 blue; 2 green
                                 Game 2: 1 blue, 2 green; 3 green, 4 blue, 1 red; 1 green, 1 blue
                                 Game 3: 8 green, 6 blue, 20 red; 5 blue, 4 red, 13 green; 5 green, 1 red
                                 Game 4: 1 green, 3 red, 6 blue; 3 green, 6 red; 3 green, 15 blue, 14 red
                                 Game 5: 6 red, 1 blue, 3 green; 2 blue, 1 red, 2 green
                                 """;
    
    private readonly Day2 _instance = new();

    [Fact]
    public void Puzzle1()
    {
        var result = _instance.SolvePuzzle1(Input.Split('\n'));
        Assert.Equal(8, result);
    }
    
    [Fact]
    public void Puzzle2()
    {
        var result = _instance.SolvePuzzle2(Input.Split('\n'));
        Assert.Equal(2286, result);
    }
}