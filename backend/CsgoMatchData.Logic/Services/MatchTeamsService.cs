using CsgoMatchData.Logic.Models;
using CsgoMatchData.Logic.Providers.Interfaces;
using CsgoMatchData.Logic.Services.Interfaces;
using CsgoMatchData.Parser.Models;
using CsgoMatchData.Parser.Models.Actions;

namespace CsgoMatchData.Logic.Services;

public class MatchTeamsService : IMatchTeamsService
{
    private readonly IMatchDataProvider _matchDataProvider;

    public MatchTeamsService(IMatchDataProvider matchDataProvider)
    {
        _matchDataProvider =
            matchDataProvider ?? throw new ArgumentNullException(nameof(matchDataProvider));
    }

    public (Team TeamOne, Team TeamTwo) GetMatchTeamsWithPlayers()
    {
        var rounds = _matchDataProvider.GetMatchRounds().ToList();

        var killEvents = rounds
            .SelectMany(round =>
                round.Events.Select(roundEvent => roundEvent.EventBase).OfType<KillEvent>()
            )
            .ToList();

        var firstRoundEvents = rounds[0].Events.Select(roundEvent => roundEvent.EventBase).ToList();
        var teamOneEvent = firstRoundEvents.OfType<TeamPlayingCounterTerroristEvent>().Single();
        var teamTwoEvent = firstRoundEvents.OfType<TeamPlayingTerroristEvent>().Single();

        var teamOnePlayers = new HashSet<string>();
        var teamTwoPlayers = new HashSet<string>();
        var loopCounter = 0;

        while (teamOnePlayers.Count != 5 || teamTwoPlayers.Count != 5)
        {
            var killer = killEvents[loopCounter].Killer;
            var victim = killEvents[loopCounter].Victim;

            AddPlayerToTeam(killer, teamOnePlayers, teamTwoPlayers);
            AddPlayerToTeam(victim, teamOnePlayers, teamTwoPlayers);

            loopCounter++;
        }

        var teamOne = new Team(teamOneEvent.TeamName, teamOnePlayers);
        var teamTwo = new Team(teamTwoEvent.TeamName, teamTwoPlayers);

        return (teamOne, teamTwo);
    }

    private static void AddPlayerToTeam(
        Player killer,
        ISet<string> teamOnePlayers,
        ISet<string> teamTwoPlayers
    )
    {
        if (killer.TeamType == TeamType.CounterTerrorist)
        {
            if (!teamOnePlayers.Contains(killer.Name))
            {
                teamOnePlayers.Add(killer.Name);
            }
        }
        else if (killer.TeamType == TeamType.Terrorist)
        {
            if (!teamTwoPlayers.Contains(killer.Name))
            {
                teamTwoPlayers.Add(killer.Name);
            }
        }
    }
}
