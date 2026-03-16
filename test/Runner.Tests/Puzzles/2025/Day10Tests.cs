using Runner.Puzzles._2025;

namespace Runner.Tests.Puzzles._2025;

public class Day10Tests
{
    private const string Input = """
                                 [.##.] (3) (1,3) (2) (2,3) (0,2) (0,1) {3,5,4,7}
                                 [...#.] (0,2,3,4) (2,3) (0,4) (0,1,2) (1,2,3,4) {7,5,12,7,2}
                                 [.###.#] (0,1,2,3,4) (0,3,4) (0,1,2,4,5) (1,2) {10,11,11,5,10,5}
                                 """;
    // private const string Input = """
    //                              [.##.] (3) (1,3) (2) (2,3) (0,2) (0,1) {3,5,4,7}
    //                              """;

    private readonly Day10 _instance = new Day10();

    [Fact]
    public void Puzzle1()
    {
        var result = _instance.SolvePuzzle1(Input.Split('\n'));
        Assert.Equal(7, result);
    }

    [Fact]
    public void Puzzle2()
    {
        var result = _instance.SolvePuzzle2(Input.Split('\n'));
        Assert.Equal(33, result);
    }

    [Fact]
    public void Puzzle2_1()
    {
        var result = _instance.SolvePuzzle2(["[.#...#...#] (3,5,7,8) (0,3,4) (0,1,2,3,4,7,9) (0,1,3,4,6,7,9) (1,4,5,6,8) (0,1,6,9) (0,2,3,4,5,7,8,9) (1,2,5,6,7,9) (0,2,3,5,6,7,8,9) (0,2,3,4,5,7,8) {46,36,54,60,41,78,47,75,59,57}"]);
        Assert.Equal(33, result);
    }
}