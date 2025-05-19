using CsgoMatchData.Logic.Models;
using CsgoMatchData.Logic.Services.Interfaces;
using CsgoMatchData.Parser.Models;

namespace CsgoMatchData.Logic.Services;

public class MatchResultService : IMatchResultService
{
    private readonly IRoundResultService _roundResultService;

    public MatchResultService(IRoundResultService roundResultService)
    {
        _roundResultService =
            roundResultService ?? throw new ArgumentNullException(nameof(roundResultService));
    }

    public MatchResult GetMatchResult()
    {
        var roundResults = _roundResultService.GetRoundResults();

        var teamScoreDictionary = new Dictionary<string, int>();

        foreach (var roundResult in roundResults)
        {
            IncrementTerroristScore(roundResult, teamScoreDictionary);
            IncrementCounterTerroristScore(roundResult, teamScoreDictionary);
        }

        var teamScoreList = teamScoreDictionary.Select(x => new TeamScore(x.Key, x.Value)).ToList();

        return new MatchResult(teamScoreList, roundResults);
    }

    private static void IncrementCounterTerroristScore(
        RoundResult roundResult,
        IDictionary<string, int> teamScores
    )
    {
        if (
            roundResult.RoundWinType
            is RoundWinType.CounterTerroristsWin
                or RoundWinType.CounterTerroristsWinByDefusingBomb
        )
        {
            AddTeamScore(roundResult.TeamPlayingCounterTerrorist, teamScores);
        }
    }

    private static void IncrementTerroristScore(
        RoundResult roundResult,
        IDictionary<string, int> teamScores
    )
    {
        if (
            roundResult.RoundWinType
            is RoundWinType.TerroristsWin
                or RoundWinType.TerroristsWinByBombExplosion
        )
        {
            AddTeamScore(roundResult.TeamPlayingTerrorist, teamScores);
        }
    }

    private static void AddTeamScore(string team, IDictionary<string, int> teamScores)
    {
        if (!teamScores.ContainsKey(team))
        {
            teamScores.Add(team, 1);
        }
        else
        {
            teamScores[team]++;
        }
    }
}
