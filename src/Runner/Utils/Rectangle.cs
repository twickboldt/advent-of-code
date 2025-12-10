namespace Runner.Utils;

public record Rectangle(Coordinate2D A, Coordinate2D B)
{
    public long Area()
    {
        int[] x = [A.X, B.X];
        int[] y = [A.Y, B.Y];
        return (long)(x.Max() - x.Min() + 1) * (y.Max() - y.Min() + 1);
    }

    public bool IntersectsWith(Line line)
    {
        var rectangleMinX = Math.Min(A.X, B.X);
        var rectangleMaxX = Math.Max(A.X, B.X);
        var rectangleMinY = Math.Min(A.Y, B.Y);
        var rectangleMaxY = Math.Max(A.Y, B.Y);

        var lineMinX = Math.Min(line.Start.X, line.End.X);
        var lineMaxX = Math.Max(line.Start.X, line.End.X);
        var lineMinY = Math.Min(line.Start.Y, line.End.Y);
        var lineMaxY = Math.Max(line.Start.Y, line.End.Y);

        return lineMaxX > rectangleMinX && lineMinX < rectangleMaxX && lineMaxY > rectangleMinY &&
               lineMinY < rectangleMaxY;
    }
}