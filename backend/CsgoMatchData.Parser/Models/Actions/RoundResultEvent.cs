using CsgoMatchData.Parser.Models.Actions.Abstractions;

namespace CsgoMatchData.Parser.Models.Actions;

public class RoundResultEvent : EventBase
{
    public RoundResultEvent(RoundWinType roundWinType)
    {
        RoundWinType = roundWinType;
    }

    public RoundWinType RoundWinType { get; }
}
