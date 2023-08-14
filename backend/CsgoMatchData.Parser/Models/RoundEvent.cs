using CsgoMatchData.Parser.Models.Actions.Abstractions;

namespace CsgoMatchData.Parser.Models;

public class RoundEvent
{
    public RoundEvent(DateTime timestamp, EventBase eventBase)
    {
        Timestamp = timestamp;
        EventBase = eventBase;
    }

    public DateTime Timestamp { get; }
    public EventBase EventBase { get; }
}