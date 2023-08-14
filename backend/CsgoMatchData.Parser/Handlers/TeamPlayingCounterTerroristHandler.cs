using CsgoMatchData.Parser.Handlers.Abstractions;
using CsgoMatchData.Parser.Models.Actions;
using CsgoMatchData.Parser.Models.Actions.Abstractions;

namespace CsgoMatchData.Parser.Handlers;

public class TeamPlayingCounterTerroristHandler : ActionHandler
{
    public override EventBase? Parse(string actionText)
    {
        if (!actionText.Contains(@"MatchStatus: Team playing ""CT"": "))
        {
            return base.Parse(actionText);
        }

        var teamName = actionText[55..];

        return new TeamPlayingCounterTerroristEvent(teamName);
    }
}