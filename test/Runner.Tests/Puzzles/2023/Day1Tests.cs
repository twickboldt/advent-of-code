using Runner.Puzzles._2023;

namespace Runner.Tests.Puzzles._2023;

public class Day1Tests
{
    private const string Input = """
                                 1abc2
                                 pqr3stu8vwx
                                 a1b2c3d4e5f
                                 treb7uchet
                                 """;

    private const string Input2 = """
                                  two1nine
                                  eightwothree
                                  abcone2threexyz
                                  xtwone3four
                                  4nineeightseven2
                                  zoneight234
                                  7pqrstsixteen
                                  """;
    
    private readonly Day1 _instance = new Day1();

    [Fact]
    public void Puzzle1()
    {
        var result = _instance.SolvePuzzle1(Input.Split('\n'));
        Assert.Equal(142, result);
    }
    
    [Fact]
    public void Puzzle2()
    {
        var result = _instance.SolvePuzzle2(Input2.Split('\n'));
        Assert.Equal(281, result);
    }
    
    [Fact]
    public void Puzzle2_1()
    {
        var result = _instance.SolvePuzzle2(["pxvmbjprllmbfpzjxsvhc5"]);
        Assert.Equal(55, result);
    }
}