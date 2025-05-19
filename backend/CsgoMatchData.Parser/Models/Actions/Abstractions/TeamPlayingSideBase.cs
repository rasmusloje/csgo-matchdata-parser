namespace CsgoMatchData.Parser.Models.Actions.Abstractions;

public abstract class TeamPlayingSideBase : EventBase
{
    protected TeamPlayingSideBase(string teamName)
    {
        TeamName = teamName;
    }

    public string TeamName { get; }
}
