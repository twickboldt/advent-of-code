using System.Diagnostics;

namespace Runner;

public class AdventRunner(IEnumerable<DailyPuzzle> implementations)
{
    public async Task Run()
    {
        foreach (var implementation in implementations.OrderByDescending(i => i.Year).ThenByDescending(i => i.Day))
        {
            await ExecuteSolver(implementation);
            Console.WriteLine();
        }
    }

    private static async Task ExecuteSolver(DailyPuzzle puzzle)
    {
        try
        {
            var sw = new Stopwatch();
            var input = await GetInput(puzzle.Year, puzzle.Day);
            sw.Start();
            var result = puzzle.SolvePuzzle1(input);
            sw.Stop();
            WriteResult(puzzle.Day, 1, result, sw);

            var puzzle2HasDifferentInput = File.Exists($"inputs/{puzzle.Year}/day{puzzle.Day}_{2}.txt");
            sw.Reset();
            input = await GetInput(puzzle.Year, puzzle.Day, puzzle2HasDifferentInput ? 2 : 1);
            sw.Start();
            result =
                puzzle.SolvePuzzle2(input);
            sw.Stop();
            WriteResult(puzzle.Day, 2, result, sw);
        }
        catch (Exception e)
        {
            // ignored
            Console.WriteLine(e.Message);
        }
    }

    private static void WriteResult(int dayNumber, int puzzleNumber, long result, Stopwatch sw)
    {
        var timeString = sw.Elapsed.TotalMicroseconds > 1000
            ? $"{sw.Elapsed.TotalMilliseconds}ms"
            : $"{sw.Elapsed.TotalMicroseconds}µs";
        Console.WriteLine($"Day {dayNumber} Puzzle {puzzleNumber}: {result} took: {timeString}");
    }

    private static async Task<string[]> GetInput(int year, int day, int puzzle = 1)
    {
        var input = await File.ReadAllLinesAsync($"inputs/{year}/day{day}_{puzzle}.txt");

        return input;
    }
}