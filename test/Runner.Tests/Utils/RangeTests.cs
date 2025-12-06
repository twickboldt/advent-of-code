namespace Runner.Tests.Utils;

public class RangeTests
{
    [Theory]
    [InlineData(1, 5, 4, 8, true)]
    [InlineData(1, 10, 4, 8, true)]
    [InlineData(5, 6, 4, 8, true)]
    [InlineData(1, 3, 4, 8, false)]
    [InlineData(9, 10, 4, 8, false)]
    public void OverlapsTests(long from1, long to1, long from2, long to2, bool overlaps)
    {
        var range1 = new Runner.Utils.Range(from1, to1);
        var range2 = new Runner.Utils.Range(from2, to2);
        Assert.Equal(overlaps, range1.OverlapsWith(range2));
    }

    [Theory]
    [InlineData(1, 5, 4, 8, false)]
    [InlineData(1, 10, 4, 8, true)]
    [InlineData(1, 10, 1, 10, true)]
    [InlineData(5, 6, 4, 8, false)]
    [InlineData(1, 3, 4, 8, false)]
    [InlineData(9, 10, 4, 8, false)]
    public void IncludesTests(long from1, long to1, long from2, long to2, bool overlaps)
    {
        var range1 = new Runner.Utils.Range(from1, to1);
        var range2 = new Runner.Utils.Range(from2, to2);
        Assert.Equal(overlaps, range1.Includes(range2));
    }
    
    [Theory]
    [InlineData(1, 5, 4, 8, 1, 3)]
    [InlineData(7, 10, 4, 8, 9, 10)]
    public void MoveOutOfRangeTests(long from1, long to1, long from2, long to2, long newFrom, long newTo)
    {
        var range1 = new Runner.Utils.Range(from1, to1);
        var range2 = new Runner.Utils.Range(from2, to2);

        var newRange = range1.MoveOutOfRange(range2);
        Assert.Equal(newFrom, newRange.From);
        Assert.Equal(newTo, newRange.To);
    }
}