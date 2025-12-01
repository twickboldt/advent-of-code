using System.Text.RegularExpressions;

namespace Runner.Puzzles._2023;

public partial class Day3 : DailyPuzzle
{
    public override int Year => 2023;
    public override int Day => 3;

    public override long SolvePuzzle1(string[] input)
    {
        var (numbers, _) = ParseLines(input, false);

        return numbers.Where(number => number.IsAdjacentToSymbol(input)).Sum(number => number.Value);
    }

    public override long SolvePuzzle2(string[] input)
    {
        var (numbers, gears) = ParseLines(input, true);

        return gears.Sum(g => g.Ratio(numbers));
    }

    private static (List<Number>, List<Gear>) ParseLines(string[] input, bool withGears)
    {
        var numbers = new List<Number>();
        var gears = new List<Gear>();
        for (var i = 0; i < input.Length; i++)
        {
            var line = input[i];
            var matches = NumberRegex().Matches(line);
            numbers.AddRange(matches.Select(match => new Number(int.Parse(match.Value), match.Index, i, match.Length)));

            if (withGears)
            {
                var gearsInLine = StarRegex().Matches(line).Select(gear => new Gear(gear.Index, i)).ToArray();
                gears.AddRange(gearsInLine);
            }
        }

        return (numbers, gears);
    }

    private record Gear(int X, int Y)
    {
        public int Ratio(List<Number> numbers)
        {
            var adjacentNumbers = numbers
                .Where(n => Y >= n.Y - 1 && Y <= n.Y + 1 && X >= n.X - 1 && X <= n.X + n.Length)
                .ToArray();

            if (adjacentNumbers.Length != 2)
            {
                return 0;
            }

            var ratio = adjacentNumbers[0].Value * adjacentNumbers[1].Value;
            return ratio;
        }
    }

    private record Number(int Value, int X, int Y, int Length)
    {
        public bool IsAdjacentToSymbol(string[] input)
        {
            var numberInFirstRow = Y == 0;
            var numberInLastRow = Y == input.Length - 1;
            var numberInBeginningOfRow = X == 0;
            var numberInEndOfRow = X + Length == input[Y].Length;

            if (!numberInBeginningOfRow)
            {
                var indexBeforeNumber = X - 1;
                if (input[Y][indexBeforeNumber] != '.') return true;
                if (!numberInFirstRow && input[Y - 1][indexBeforeNumber] != '.') return true;
                if (!numberInLastRow && input[Y + 1][indexBeforeNumber] != '.') return true;
            }

            if (!numberInEndOfRow)
            {
                var indexAfterNumber = X + Length;
                if (input[Y][indexAfterNumber] != '.') return true;
                if (!numberInFirstRow && input[Y - 1][indexAfterNumber] != '.') return true;
                if (!numberInLastRow && input[Y + 1][indexAfterNumber] != '.') return true;
            }

            if (!numberInFirstRow)
            {
                for (var i = 0; i < Length; i++)
                {
                    if (input[Y - 1][i + X] != '.') return true;
                }
            }

            if (!numberInLastRow)
            {
                for (var i = 0; i < Length; i++)
                {
                    if (input[Y + 1][i + X] != '.') return true;
                }
            }

            return false;
        }
    }

    [GeneratedRegex(@"\d+")]
    private static partial Regex NumberRegex();

    [GeneratedRegex("\\*")]
    private static partial Regex StarRegex();
}