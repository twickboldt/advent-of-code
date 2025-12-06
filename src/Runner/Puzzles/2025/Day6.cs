namespace Runner.Puzzles._2025;

public class Day6 : DailyPuzzle
{
    public override int Year => 2025;
    public override int Day => 6;

    public override long SolvePuzzle1(string[] input)
    {
        var columns = new List<List<long>>();
        var result = 0L;
        for (var i = 0; i < input.Length; i++)
        {
            var elements = input[i].Split(' ', StringSplitOptions.RemoveEmptyEntries);
            for (var columnIndex = 0; columnIndex < elements.Length; columnIndex++)
            {
                if (i == 0)
                {
                    columns.Add([]);
                }

                if (i == input.Length - 1)
                {
                    // last line so we now get the operators and have to calculate the column
                    if (elements[columnIndex] == "+")
                    {
                        result += columns[columnIndex].Sum();
                    }
                    else
                    {
                        result += columns[columnIndex].Aggregate(1L, (acc, val) => acc * val);
                    }

                    continue;
                }

                columns[columnIndex].Add(int.Parse(elements[columnIndex]));
            }
        }

        return result;
    }

    public override long SolvePuzzle2(string[] input)
    {
        var solution = 0L;
        var numberEndIndizes = new List<int>();
        var lastLine = input[^1];
        for (var c = 1; c < lastLine.Length; c++)
        {
            if (lastLine[c] != ' ')
            {
                numberEndIndizes.Add(c - 1);
            }
        }

        numberEndIndizes.Add(lastLine.Length);

        var addition = lastLine[0] == '+';
        var currentEndIndexTracker = 0;
        var currentEndIndexResult = addition ? 0L : 1L;
        for (var columnIndex = 0; columnIndex < lastLine.Length; columnIndex++)
        {
            if (columnIndex == numberEndIndizes[currentEndIndexTracker])
            {
                addition = lastLine[numberEndIndizes[currentEndIndexTracker] + 1] == '+';
                
                // Leerspalte skippen
                currentEndIndexTracker++;

                solution += currentEndIndexResult;
                currentEndIndexResult = addition ? 0L : 1L;
                continue;
            }

            var numberChars = new List<char>();
            for (var rowIndex = 0; rowIndex < input.Length - 1; rowIndex++)
            {
                var currentChar = input[rowIndex][columnIndex];
                if (currentChar != ' ')
                {
                    numberChars.Add(currentChar);
                }
            }
            var actualNumber = int.Parse(new string(numberChars.ToArray()));
            if (addition)
            {
                currentEndIndexResult += actualNumber;
            }
            else
            {
                currentEndIndexResult *= actualNumber;
            }
        }

        // last temporary result is not added but too lazy to fix it in the loop
        solution += currentEndIndexResult;
        
        return solution;
    }
}