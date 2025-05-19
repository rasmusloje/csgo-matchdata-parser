using CsgoMatchData.Parser.Handlers.Abstractions;
using CsgoMatchData.Parser.Models.Actions;
using CsgoMatchData.Parser.Models.Actions.Abstractions;

namespace CsgoMatchData.Parser.Handlers;

public class TeamPlayingTerroristHandler : ActionHandler
{
    public override EventBase? Parse(string actionText)
    {
        if (!actionText.Contains(@"MatchStatus: Team playing ""TERRORIST"": "))
        {
            return base.Parse(actionText);
        }

        var teamName = actionText[62..];

        return new TeamPlayingTerroristEvent(teamName);
    }
}
