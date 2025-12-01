using System.Text.RegularExpressions;
using JetBrains.Annotations;

namespace Runner.Puzzles._2023;

[UsedImplicitly]
public class Day1 : DailyPuzzle
{
    public override int Year => 2023;
    public override int Day => 1;

    public override long SolvePuzzle1(string[] input)
    {
        var numbers = new List<int>();
        foreach (var line in input)
        {
            var lineNumber = 0;
            foreach (var letter in line)
            {
                if (int.TryParse(letter.ToString(), out var num))
                {
                    lineNumber = num * 10;
                    break;
                }
            }

            for (var i = line.Length - 1; i >= 0; i--)
            {
                var letter = line[i];
                if (int.TryParse(letter.ToString(), out var num))
                {
                    lineNumber += num;
                    break;
                }
            }

            numbers.Add(lineNumber);
        }

        return numbers.Sum();
    }

    public override long SolvePuzzle2(string[] input)
    {
        var numberRegex = "\\d|one|two|three|four|five|six|seven|eight|nine";
        var numbers = new List<int>();
        foreach (var line in input)
        {
            var lineNumber = 0;
            for (var i = 0; i < line.Length; i++)
            {
                var match = Regex.Match(line[..(i + 1)], numberRegex);
                if (match.Success)
                {
                    if (int.TryParse(match.Value, out var num))
                    {
                        lineNumber = num * 10;
                    }
                    else
                    {
                        lineNumber = match.Value switch
                        {
                            "one" => 10,
                            "two" => 20,
                            "three" => 30,
                            "four" => 40,
                            "five" => 50,
                            "six" => 60,
                            "seven" => 70,
                            "eight" => 80,
                            "nine" => 90,
                            _ => lineNumber
                        };
                    }

                    break;
                }
            }

            for (var i = line.Length - 1; i >= 0; i--)
            {
                var match = Regex.Match(line[i..], numberRegex);
                if (match.Success)
                {
                    if (int.TryParse(match.Value, out var num))
                    {
                        lineNumber += num;
                    }
                    else
                    {
                        lineNumber += match.Value switch
                        {
                            "one" => 1,
                            "two" => 2,
                            "three" => 3,
                            "four" => 4,
                            "five" => 5,
                            "six" => 6,
                            "seven" => 7,
                            "eight" => 8,
                            "nine" => 9,
                            _ => 0
                        };
                    }

                    break;
                }
            }

            numbers.Add(lineNumber);
        }

        return numbers.Sum();
    }
}