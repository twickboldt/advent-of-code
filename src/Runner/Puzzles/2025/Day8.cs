using Runner.Utils;

namespace Runner.Puzzles._2025;

public class Day8 : DailyPuzzle
{
    public override int Year => 2025;
    public override int Day => 8;

    public override long SolvePuzzle1(string[] input)
    {
        const int connectionsToMake = 1000;

        var coordinates = new List<Coordinate3D>();
        var distances = new List<Distance>();
        for (var lineIndex = 0; lineIndex < input.Length; lineIndex++)
        {
            var line = input[lineIndex];
            var parts = line.Split(',');

            var coordinate = new Coordinate3D(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]));

            for (var coordinateIndex = 0; coordinateIndex < coordinates.Count; coordinateIndex++)
            {
                distances.Add(new Distance(coordinateIndex, lineIndex,
                    coordinate.Distance(coordinates[coordinateIndex])));
            }

            coordinates.Add(coordinate);
        }

        var connectionsMade = 0;
        var circuits = new List<HashSet<int>>();
        foreach (var distance in distances.OrderBy(d => d.CoordinateDistance))
        {
            if (connectionsMade == connectionsToMake)
            {
                break;
            }

            var circuitWhereIndex1Found = circuits.FirstOrDefault(c => c.Contains(distance.IndexCoordinate1));
            var circuitWhereIndex2Found = circuits.FirstOrDefault(c => c.Contains(distance.IndexCoordinate2));

            connectionsMade++;

            if (circuitWhereIndex1Found == circuitWhereIndex2Found && circuitWhereIndex1Found != null)
            {
                // both positions are already in the same circuit
                continue;
            }

            if (circuitWhereIndex1Found != null && circuitWhereIndex2Found != null)
            {
                // both positions are already in a circuit so we just merge them
                circuits.Remove(circuitWhereIndex2Found);
                circuitWhereIndex1Found.UnionWith(circuitWhereIndex2Found);
            }

            if (circuitWhereIndex1Found != null)
            {
                circuitWhereIndex1Found.Add(distance.IndexCoordinate2);
                continue;
            }

            if (circuitWhereIndex2Found != null)
            {
                circuitWhereIndex2Found.Add(distance.IndexCoordinate1);
                continue;
            }

            // neither position is in a circuit yet, so we create a new one
            var newCircuit = new HashSet<int> { distance.IndexCoordinate1, distance.IndexCoordinate2 };
            circuits.Add(newCircuit);
        }

        var sortedCircuits = circuits.OrderByDescending(c => c.Count).ToArray();
        return sortedCircuits[0].Count * sortedCircuits[1].Count * sortedCircuits[2].Count;
    }

    public override long SolvePuzzle2(string[] input)
    {
        var coordinates = new List<Coordinate3D>();
        var distances = new List<Distance>();
        for (var lineIndex = 0; lineIndex < input.Length; lineIndex++)
        {
            var line = input[lineIndex];
            var parts = line.Split(',');

            var coordinate = new Coordinate3D(int.Parse(parts[0]), int.Parse(parts[1]), int.Parse(parts[2]));

            for (var coordinateIndex = 0; coordinateIndex < coordinates.Count; coordinateIndex++)
            {
                distances.Add(new Distance(coordinateIndex, lineIndex,
                    coordinate.Distance(coordinates[coordinateIndex])));
            }

            coordinates.Add(coordinate);
        }

        Distance lastConnection = null!;
        var circuits = new List<HashSet<int>>();
        foreach (var distance in distances.OrderBy(d => d.CoordinateDistance))
        {
            var circuitWhereIndex1Found = circuits.FirstOrDefault(c => c.Contains(distance.IndexCoordinate1));
            var circuitWhereIndex2Found = circuits.FirstOrDefault(c => c.Contains(distance.IndexCoordinate2));

            if (circuitWhereIndex1Found == circuitWhereIndex2Found && circuitWhereIndex1Found != null)
            {
                // both positions are already in the same circuit
                continue;
            }

            lastConnection = distance;
            if (circuitWhereIndex1Found != null && circuitWhereIndex2Found != null)
            {
                // both positions are already in a circuit so we just merge them
                circuits.Remove(circuitWhereIndex2Found);
                circuitWhereIndex1Found.UnionWith(circuitWhereIndex2Found);
            }

            if (circuitWhereIndex1Found != null)
            {
                circuitWhereIndex1Found.Add(distance.IndexCoordinate2);
                continue;
            }

            if (circuitWhereIndex2Found != null)
            {
                circuitWhereIndex2Found.Add(distance.IndexCoordinate1);
                continue;
            }

            // neither position is in a circuit yet, so we create a new one
            var newCircuit = new HashSet<int> { distance.IndexCoordinate1, distance.IndexCoordinate2 };
            circuits.Add(newCircuit);
        }

        return ((long)coordinates[lastConnection.IndexCoordinate1].X) * coordinates[lastConnection.IndexCoordinate2].X;
    }

    private record Distance(int IndexCoordinate1, int IndexCoordinate2, double CoordinateDistance);
}