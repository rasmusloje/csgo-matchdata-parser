using CsgoMatchData.Parser.Models.Actions.Abstractions;

namespace CsgoMatchData.Parser.Models.Actions;

public class RoundStartEvent : EventBase
{
    public RoundStartEvent(DateTime roundStart)
    {
        RoundStart = roundStart;
    }

    public DateTime RoundStart { get; }
}
