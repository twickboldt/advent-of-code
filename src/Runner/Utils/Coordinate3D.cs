namespace Runner.Utils;

public record Coordinate3D(int X, int Y, int Z)
{
    public double Distance(Coordinate3D other)
    {
        return Math.Sqrt(Math.Pow(X - other.X, 2) + Math.Pow(Y - other.Y, 2) + Math.Pow(Z - other.Z, 2));
    }
}