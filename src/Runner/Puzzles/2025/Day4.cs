using Runner.Utils;

namespace Runner.Puzzles._2025;

public class Day4 : DailyPuzzle
{
    public override int Year => 2025;
    public override int Day => 4;

    public override long SolvePuzzle1(string[] input)
    {
        return GetPaperRollsWithLessThan4Neighbors(PrepareInput(input)).Count;
    }

    public override long SolvePuzzle2(string[] input)
    {
        var solution = 0;
        var preparedInput = PrepareInput(input);
        while (true)
        {
            var paperRolls = GetPaperRollsWithLessThan4Neighbors(preparedInput);
            if (paperRolls.Count == 0)
            {
                return solution;
            }

            solution += paperRolls.Count;
            foreach (var paperRoll in paperRolls)
            {
                preparedInput[paperRoll.Y][paperRoll.X] = '.';
            }
        }
    }

    private static List<Coordinate2D> GetPaperRollsWithLessThan4Neighbors(char[][] input)
    {
        var paperRollLocations = new List<Coordinate2D>();
        var totalLines = input.Length;
        for (var lineNr = 0; lineNr < totalLines; lineNr++)
        {
            var totalColumns = input[lineNr].Length;
            for (var columnNr = 0; columnNr < totalColumns; columnNr++)
            {
                var currentChar = input[lineNr][columnNr];
                if (currentChar != '@')
                {
                    continue;
                }

                var neighborPaperRollCount = 0;
                // check above
                if (lineNr > 0)
                {
                    // check top left
                    if (columnNr > 0 && input[lineNr - 1][columnNr - 1] == currentChar)
                    {
                        neighborPaperRollCount++;
                    }

                    // check top middle
                    if (input[lineNr - 1][columnNr] == currentChar)
                    {
                        neighborPaperRollCount++;
                    }

                    // check top right
                    if (columnNr < totalColumns - 1 && input[lineNr - 1][columnNr + 1] == currentChar)
                    {
                        neighborPaperRollCount++;
                    }
                }

                // check left
                if (columnNr > 0 && input[lineNr][columnNr - 1] == currentChar)
                {
                    neighborPaperRollCount++;
                }

                // check right
                if (columnNr < totalColumns - 1 && input[lineNr][columnNr + 1] == currentChar)
                {
                    neighborPaperRollCount++;
                }

                // check below
                if (lineNr < totalLines - 1)
                {
                    // check below left
                    if (columnNr > 0 && input[lineNr + 1][columnNr - 1] == currentChar)
                    {
                        neighborPaperRollCount++;
                    }

                    // check below middle
                    if (input[lineNr + 1][columnNr] == currentChar)
                    {
                        neighborPaperRollCount++;
                    }

                    // check below right
                    if (columnNr < totalColumns - 1 && input[lineNr + 1][columnNr + 1] == currentChar)
                    {
                        neighborPaperRollCount++;
                    }
                }

                if (neighborPaperRollCount < 4)
                {
                    paperRollLocations.Add(new Coordinate2D(columnNr, lineNr));
                }
            }
        }

        return paperRollLocations;
    }

    private static char[][] PrepareInput(string[] input)
    {
        return input.Select(line => line.Select(c => c).ToArray()).ToArray();
    }
}