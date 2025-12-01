namespace Runner.Puzzles._2023;

public class Day4 : DailyPuzzle
{
    public override int Year => 2023;
    public override int Day => 4;

    public override long SolvePuzzle1(string[] input)
    {
        return input.Sum(line =>
        {
            var parts = line.Split(": ");
            var cardId = int.Parse(parts[0][4..].Trim());
            var numberParts = parts[1].Split(" | ");
            var numbers = numberParts[0].Split(' ').Where(n => n != "").Select(n => int.Parse(n.Trim())).ToArray();
            var winningNumbers = numberParts[1].Split(' ').Where(n => n != "").Select(n => int.Parse(n.Trim()))
                .ToArray();

            var card = new Card(cardId, numbers.ToArray(), winningNumbers.ToArray());
            return card.Score();
        });
    }

    public override long SolvePuzzle2(string[] input)
    {
        throw new NotImplementedException();
    }

    private record Card(int Id, int[] Numbers, int[] WinningNumbers)
    {
        public long Score()
        {
            var countOfWinningNumbers = Numbers.Count(number => WinningNumbers.Contains(number));
            if (countOfWinningNumbers == 0)
            {
                return 0;
            }

            return (long)Math.Pow(2, countOfWinningNumbers - 1);
        }
    }
}