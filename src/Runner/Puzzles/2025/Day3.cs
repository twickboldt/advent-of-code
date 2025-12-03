using System.Text.RegularExpressions;

namespace Runner.Puzzles._2025;

public class Day3 : DailyPuzzle
{
    public override int Year => 2025;
    public override int Day => 3;

    public override long SolvePuzzle1(string[] input)
    {
        return input.Sum(line => GetJolts(line, 2));
    }

    public override long SolvePuzzle2(string[] input)
    {
        return input.Sum(line => GetJolts(line, 12));
    }

    public static long GetJolts(string line, int numberOfBatteries)
    {
        var solutionDigits = new List<int>();
        var lastIndex = -1;
        var digits = line.Select(d => int.Parse(d.ToString())).ToArray();
        for (var batteryIndex = 0; batteryIndex < numberOfBatteries; batteryIndex++)
        {
            var maxIndexToScan = (line.Length - (numberOfBatteries - batteryIndex - 1));
            var digitRange = digits[(lastIndex + 1)..maxIndexToScan];
            var solutionDigit = digitRange.Max();
            lastIndex = digitRange.IndexOf(solutionDigit) + lastIndex + 1;
            solutionDigits.Add(solutionDigit);
        }

        var result = long.Parse(string.Join("", solutionDigits));
        return result;
    }
}