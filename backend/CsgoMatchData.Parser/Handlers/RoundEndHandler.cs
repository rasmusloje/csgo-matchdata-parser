using CsgoMatchData.Parser.Handlers.Abstractions;
using CsgoMatchData.Parser.Helpers;
using CsgoMatchData.Parser.Models.Actions;
using CsgoMatchData.Parser.Models.Actions.Abstractions;

namespace CsgoMatchData.Parser.Handlers;

public class RoundEndHandler : ActionHandler
{
    public override EventBase? Parse(string actionText)
    {
        if (!actionText.Contains("Round_End"))
        {
            return base.Parse(actionText);
        }

        var roundEnd = TimeExtractor.ParseTimestampFromActionText(actionText);

        return new RoundEndEvent(roundEnd);
    }
}