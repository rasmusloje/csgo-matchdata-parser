using CsgoMatchData.Parser.Models.Actions.Abstractions;

namespace CsgoMatchData.Parser.Models.Actions;

public class TeamPlayingTerroristEvent : TeamPlayingSideBase
{
    public TeamPlayingTerroristEvent(string teamName)
        : base(teamName) { }
}
