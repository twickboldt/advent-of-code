using Range = Runner.Utils.Range;

namespace Runner.Puzzles._2025;

public class Day5 : DailyPuzzle
{
    public override int Year => 2025;
    public override int Day => 5;

    public override long SolvePuzzle1(string[] input)
    {
        var freshIngredients = new List<(long, long)>();

        var freshnessCounter = 0;
        var part2Reached = false;
        foreach (var line in input)
        {
            if (line == "")
            {
                part2Reached = true;
                continue;
            }

            if (!part2Reached)
            {
                var ingredients = line.Split('-');
                var startIngredient = long.Parse(ingredients[0]);
                var endIngredient = long.Parse(ingredients[1]);
                freshIngredients.Add((startIngredient, endIngredient));
            }
            else
            {
                var ingredientId = long.Parse(line);
                if (freshIngredients.Any(freshIngredient =>
                        freshIngredient.Item1 <= ingredientId && ingredientId <= freshIngredient.Item2))
                {
                    freshnessCounter++;
                }
            }
        }

        return freshnessCounter;
    }

    public override long SolvePuzzle2(string[] input)
    {
        var freshIngredients = new List<Range>();
        foreach (var line in input)
        {
            if (line == "")
            {
                break;
            }

            var ingredients = line.Split('-');
            var startIngredient = long.Parse(ingredients[0]);
            var endIngredient = long.Parse(ingredients[1]);
            freshIngredients.Add(new Range(startIngredient, endIngredient));
        }

        var filteredFreshIngredients = new List<Range>();
        for (var index = 0; index < freshIngredients.Count; index++)
        {
            var freshIngredient = freshIngredients[index];

            // if an existing range includes the new one, skip it
            if (filteredFreshIngredients.Any(fi => fi.Includes(freshIngredient)))
            {
                continue;
            }

            // if this range includes any existing ranges, remove them
            filteredFreshIngredients = filteredFreshIngredients
                .Where(fi => !freshIngredient.Includes(fi))
                .ToList();

            foreach (var filteredFreshIngredient in filteredFreshIngredients)
            {
                if (filteredFreshIngredient.OverlapsWith(freshIngredient))
                {
                    freshIngredient = freshIngredient.MoveOutOfRange(filteredFreshIngredient);
                }
            }

            filteredFreshIngredients.Add(freshIngredient);
        }

        return filteredFreshIngredients.Sum(fi => fi.InclusiveCount());
    }
}