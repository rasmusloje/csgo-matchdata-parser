using MatchData.Parser.Handlers.Abstractions;
using MatchData.Parser.Models.Actions;
using MatchData.Parser.Models.Actions.Abstractions;

namespace MatchData.Parser.Handlers;

public class RoundStartHandler : ActionHandler
{
    public override EventBase? Parse(string actionText)
    {
        if (!actionText.Contains("Round_Start"))
        {
            return base.Parse(actionText);
        }

        var roundStart = TimeExtractor.ParseTimestampFromActionLog(actionText);

        return new RoundStartEvent(roundStart);
    }
}