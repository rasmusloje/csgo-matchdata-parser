using CsgoMatchData.Parser.Models.Actions.Abstractions;

namespace CsgoMatchData.Parser.Models.Actions;

public class RoundEndEvent : EventBase
{
    public RoundEndEvent(DateTime roundEnd)
    {
        RoundEnd = roundEnd;
    }

    public DateTime RoundEnd { get; }
}
