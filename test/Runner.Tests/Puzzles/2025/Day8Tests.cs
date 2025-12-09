using Runner.Puzzles._2025;

namespace Runner.Tests.Puzzles._2025;

public class Day8Tests
{
    private const string Input = """
                                 162,817,812
                                 57,618,57
                                 906,360,560
                                 592,479,940
                                 352,342,300
                                 466,668,158
                                 542,29,236
                                 431,825,988
                                 739,650,466
                                 52,470,668
                                 216,146,977
                                 819,987,18
                                 117,168,530
                                 805,96,715
                                 346,949,466
                                 970,615,88
                                 941,993,340
                                 862,61,35
                                 984,92,344
                                 425,690,689
                                 """;

    private readonly Day8 _instance = new Day8();

    [Fact]
    public void Puzzle1()
    {
        var result = _instance.SolvePuzzle1(Input.Split('\n'));
        Assert.Equal(40, result);
    }

    [Fact]
    public void Puzzle2()
    {
        var result = _instance.SolvePuzzle2(Input.Split('\n'));
        Assert.Equal(25272, result);
    }
}