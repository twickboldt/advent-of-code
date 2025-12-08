namespace Runner.Puzzles._2025;

public class Day7 : DailyPuzzle
{
    public override int Year => 2025;
    public override int Day => 7;

    public override long SolvePuzzle1(string[] input)
    {
        var totalColumns = input[0].Length;
        var splitCounter = 0;
        var tachyonBeamPositions = new bool[input.Length];
        tachyonBeamPositions[input[0].IndexOf('S')] = true;
        for (var rowIndex = 1; rowIndex < input.Length; rowIndex++)
        {
            for (var colIndex = 0; colIndex < totalColumns; colIndex++)
            {
                // above is a tachyon beam
                if (tachyonBeamPositions[colIndex])
                {
                    if (input[rowIndex][colIndex] == '^')
                    {
                        // split beam
                        var splits = false;
                        if (colIndex > 0 && input[rowIndex][colIndex - 1] == '.')
                        {
                            tachyonBeamPositions[colIndex - 1] = true;
                            splits = true;
                        }

                        if (colIndex < totalColumns - 1 && input[rowIndex][colIndex + 1] == '.')
                        {
                            tachyonBeamPositions[colIndex + 1] = true;
                            splits = true;
                        }

                        if (splits)
                            splitCounter++;

                        tachyonBeamPositions[colIndex] = false;
                    }
                }
            }
        }

        return splitCounter;
    }

    public override long SolvePuzzle2(string[] input)
    {
        var totalColumns = input[0].Length;
        var timelines = new long[totalColumns];
        
        timelines[input[0].IndexOf('S')] = 1;

        for (var rowIndex = 1; rowIndex < input.Length; rowIndex++)
        {
            var newTimelines = new long[totalColumns];
            for (var colIndex = 0; colIndex < totalColumns; colIndex++)
            {
                if (input[rowIndex][colIndex] == '^')
                {
                    // beam splits and creates new timelines
                    newTimelines[colIndex - 1] += timelines[colIndex];
                    newTimelines[colIndex + 1] += timelines[colIndex];
                }
                else
                {
                    newTimelines[colIndex] += timelines[colIndex];
                }
            }

            timelines = newTimelines;
        }

        return timelines.Sum();
    }
}