using CsgoMatchData.Parser.Models.Actions.Abstractions;

namespace CsgoMatchData.Parser.Models.Actions;

public class TeamPlayingCounterTerroristEvent : TeamPlayingSideBase
{
    public TeamPlayingCounterTerroristEvent(string teamName) : base(teamName)
    { }
}