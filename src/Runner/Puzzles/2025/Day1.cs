namespace Runner.Puzzles._2025;

public class Day1 : DailyPuzzle
{
    public override int Year => 2025;
    public override int Day => 1;

    public override long SolvePuzzle1(string[] input)
    {
        var zeroCounter = 0;
        var dial = 50;
        foreach (var line in input)
        {
            dial += ParseDialRotation(line);
            dial %= 100;
            if (dial < 0)
                dial += 100;
            if (dial == 0)
                zeroCounter++;
        }

        return zeroCounter;
    }

    public override long SolvePuzzle2(string[] input)
    {
        var zeroCounter = 0;
        var dial = 50;
        foreach (var line in input)
        {
            var rotations = ParseDialRotation(line);
            var goUp = rotations > 0;
            for (var i = 0; i < Math.Abs(rotations); i++)
            {
                dial += goUp ? 1 : -1;
                if (dial == 100)
                {
                    dial = 0;
                }
                else if (dial < 0)
                {
                    dial = 99;
                }

                if (dial == 0)
                    zeroCounter++;
            }
        }

        return zeroCounter;
    }

    private static int ParseDialRotation(string line)
    {
        var direction = line[0] == 'L' ? -1 : 1;
        var amount = int.Parse(line[1..]);
        return direction * amount;
    }
}