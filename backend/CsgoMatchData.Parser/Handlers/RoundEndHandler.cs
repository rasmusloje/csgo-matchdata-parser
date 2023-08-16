using MatchData.Parser.Handlers.Abstractions;
using MatchData.Parser.Models.Actions;
using MatchData.Parser.Models.Actions.Abstractions;

namespace MatchData.Parser.Handlers;

public class RoundEndHandler : ActionHandler
{
    public override EventBase? Parse(string actionText)
    {
        if (!actionText.Contains("Round_End"))
        {
            return base.Parse(actionText);
        }

        var roundEnd = TimeExtractor.ParseTimestampFromActionLog(actionText);

        return new RoundEndEvent(roundEnd);
    }
}