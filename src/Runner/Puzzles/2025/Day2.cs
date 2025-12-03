using System.Text.RegularExpressions;

namespace Runner.Puzzles._2025;

public class Day2 : DailyPuzzle
{
    public override int Year => 2025;
    public override int Day => 2;
    public override long SolvePuzzle1(string[] input)
    {
        var inputLine = input[0];
        long solution = 0;
        var productIdRanges = inputLine.Split(",");
        foreach (var range in productIdRanges)
        {
            var productIds = range.Split("-");
            var productIdStart = long.Parse(productIds[0].ToString());
            var productIdEnd = long.Parse(productIds[1]);

            for (; productIdStart <= productIdEnd; productIdStart++)
            {
                var productIdString = productIdStart.ToString();
                // ungerade Anzahl an Ziffern
                var length = productIdString.Length;
                if (length % 2 == 1)
                    continue;
                
                if (productIdString[..(length / 2)] == productIdString[(length / 2)..])
                {
                    solution += productIdStart;
                }
            }
        }

        return solution;
    }

    public override long SolvePuzzle2(string[] input)
    {
        var inputLine = input[0];
        long solution = 0;
        var productIdRanges = inputLine.Split(",");
        foreach (var range in productIdRanges)
        {
            var productIds = range.Split("-");
            var productIdStart = long.Parse(productIds[0].ToString());
            var productIdEnd = long.Parse(productIds[1]);

            for (; productIdStart <= productIdEnd; productIdStart++)
            {
                var productIdString = productIdStart.ToString();
                // ungerade Anzahl an Ziffern
                var length = productIdString.Length;

                for (var i = 1; i <= length / 2; i++)
                {
                    if (length % i != 0)
                    {
                        continue;
                    }

                    var numberOfRepetitionsNeeded = length / i;
                    var pattern = $"({productIdString[..i]}){{{numberOfRepetitionsNeeded}}}";
                    if (Regex.IsMatch(productIdString, pattern))
                    {
                        solution += productIdStart;
                        break;
                    }
                }
            }
        }

        return solution;
    }
}