namespace Runner;

public abstract class DailyPuzzle
{
    public abstract int Year { get; }
    public abstract int Day { get; }
    
    public abstract long SolvePuzzle1(string[] input);
    public abstract long SolvePuzzle2(string[] input);
}