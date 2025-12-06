namespace Runner.Utils;

public record Range(long From, long To)
{
    public bool OverlapsWith(Range other)
    {
        return From <= other.To && To >= other.From;
    }
    
    public bool Includes(Range other)
    {
        return From <= other.From && To >= other.To;
    }

    public Range MoveOutOfRange(Range other)
    {
        if (other.From > From)
        {
            return this with { To = other.From - 1 };
        }

        return this with { From = other.To + 1 };
    }

    public long InclusiveCount()
    {
        return To - From + 1;
    }
}