using JetBrains.Annotations;

namespace Runner.Puzzles._2023;

[UsedImplicitly]
public class Day2 : DailyPuzzle
{
    public override int Year => 2023;
    public override int Day => 2;
    public override long SolvePuzzle1(string[] input)
    {
        return input.Select(ParseGame).Where(game => game.IsValid()).Sum(game => game.Id);
    }

    public override long SolvePuzzle2(string[] input)
    {
        return input.Select(ParseGame).Sum(game => game.Power());
    }

    private static Game ParseGame(string line)
    {
        var gameParts = line.Split(':');
        var gameId = int.Parse(gameParts[0].Replace("Game ", string.Empty).Trim());
        
        var hands = gameParts[1].Split(';').Select(part =>
        {
            var cubes = part.Split(',');
            var red = 0;
            var blue = 0;
            var green = 0;

            foreach (var cube in cubes)
            {
                if (cube.Contains("blue"))
                {
                    blue = int.Parse(cube.Trim().Split(' ')[0]);
                }
                else if (cube.Contains("red"))
                {
                    red = int.Parse(cube.Trim().Split(' ')[0]);
                }
                else if (cube.Contains("green"))
                {
                    green = int.Parse(cube.Trim().Split(' ')[0]);
                }
            }

            return new Hand(red, blue, green);
        });

        return new Game(gameId, hands.ToArray());
    }

    private record Game(int Id, Hand[] Hands)
    {
        public bool IsValid()
        {
            return Hands.All(hand => hand.IsValid());
        }

        public int Power()
        {
            return Hands.Max(hand => hand.Blue) * Hands.Max(hand => hand.Green) * Hands.Max(hand => hand.Red); 
        }
    }

    private record Hand(int Red, int Blue, int Green)
    {
        public bool IsValid()
        {
            return Red <= 12 && Green <= 13 && Blue <= 14;
        }
    }
}