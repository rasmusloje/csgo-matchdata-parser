using CsgoMatchData.Logic.Models;
using CsgoMatchData.Logic.Providers.Interfaces;
using CsgoMatchData.Logic.Services.Interfaces;
using CsgoMatchData.Parser.Models;
using CsgoMatchData.Parser.Models.Actions;

namespace CsgoMatchData.Logic.Services;

public class RoundResultService : IRoundResultService
{
    private readonly IMatchDataProvider _matchDataProvider;

    public RoundResultService(IMatchDataProvider matchDataProvider)
    {
        _matchDataProvider =
            matchDataProvider ?? throw new ArgumentNullException(nameof(matchDataProvider));
    }

    public IReadOnlyCollection<RoundResult> GetRoundResults()
    {
        var rounds = _matchDataProvider.GetMatchRounds();

        var roundResultEvents = rounds
            .Select(round =>
                round
                    .Events.OrderBy(roundEvent => roundEvent.Timestamp)
                    .Select(roundEvent => roundEvent.EventBase)
                    .Where(roundEvent =>
                        roundEvent
                            is RoundResultEvent
                                or TeamPlayingCounterTerroristEvent
                                or TeamPlayingTerroristEvent
                    )
            )
            .ToList();

        var roundResults = new List<RoundResult>();
        for (var i = 0; i < roundResultEvents.Count; i++)
        {
            var roundNumber = i + 1;
            var winType = RoundWinType.TerroristsWin;
            var teamPlayingCt = string.Empty;
            var teamPlayingT = string.Empty;

            foreach (var roundEvent in roundResultEvents[i])
            {
                switch (roundEvent)
                {
                    case RoundResultEvent roundResultEvent:
                        winType = roundResultEvent.RoundWinType;
                        break;
                    case TeamPlayingCounterTerroristEvent teamPlayingCounterTerroristEvent:
                        teamPlayingCt = teamPlayingCounterTerroristEvent.TeamName;
                        break;
                    case TeamPlayingTerroristEvent teamPlayingTerroristEvent:
                        teamPlayingT = teamPlayingTerroristEvent.TeamName;
                        break;
                }
            }

            roundResults.Add(new RoundResult(roundNumber, teamPlayingCt, teamPlayingT, winType));
        }

        return roundResults;
    }
}
