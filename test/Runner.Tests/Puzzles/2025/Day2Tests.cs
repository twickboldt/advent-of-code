using Runner.Puzzles._2025;

namespace Runner.Tests.Puzzles._2025;

public class Day2Tests
{
    private const string Input = "11-22,95-115,998-1012,1188511880-1188511890,222220-222224,1698522-1698528,446443-446449,38593856-38593862,565653-565659,824824821-824824827,2121212118-2121212124";

    private readonly Day2 _instance = new Day2();
    
    [Fact]
    public void Puzzle1()
    {
        var result = _instance.SolvePuzzle1(Input.Split('\n'));
        Assert.Equal(1227775554, result);
    }   

    [Fact]
    public void Puzzle2()
    {
        var result = _instance.SolvePuzzle2(Input.Split('\n'));
        Assert.Equal(4174379265, result);
    }
}