using Runner.Utils;

namespace Runner.Puzzles._2025;

public class Day9 : DailyPuzzle
{
    public override int Year => 2025;
    public override int Day => 9;

    public override long SolvePuzzle1(string[] input)
    {
        var coordinates = new List<Coordinate2D>();
        var largestArea = 0L;
        foreach (var line in input)
        {
            var parts = line.Split(',');

            var firstPoint = new Coordinate2D(int.Parse(parts[0]), int.Parse(parts[1]));

            foreach (var secondPoint in coordinates)
            {
                var rectangle = new Rectangle(firstPoint, secondPoint);
                largestArea = Math.Max(largestArea, rectangle.Area());
            }

            coordinates.Add(firstPoint);
        }

        return largestArea;
    }

    public override long SolvePuzzle2(string[] input)
    {
        var coordinates = new List<Coordinate2D>();
        var largestArea = 0L;
        foreach (var line in input)
        {
            var parts = line.Split(',');

            var coordinate = new Coordinate2D(int.Parse(parts[0]), int.Parse(parts[1]));

            coordinates.Add(coordinate);
        }

        var tileLines = new List<Line>(coordinates.Count);
        for (var i = 0; i < coordinates.Count - 1; i++)
        {
            tileLines.Add(new Line(coordinates[i], coordinates[i + 1]));
        }

        // add a line from last to first
        tileLines.Add(new Line(coordinates[^1], coordinates[0]));

        for (var firstIndex = 0; firstIndex < coordinates.Count; firstIndex++)
        {
            var first = coordinates[firstIndex];
            for (var secondIndex = firstIndex + 1; secondIndex < coordinates.Count; secondIndex++)
            {
                var second = coordinates[secondIndex];
                var rectangle = new Rectangle(first, second);
                var area = rectangle.Area();
                if (area <= largestArea)
                {
                    continue;
                }

                if (tileLines.Any(line => rectangle.IntersectsWith(line)))
                {
                    continue;
                }

                largestArea = area;
            }
        }

        return largestArea;
    }
}