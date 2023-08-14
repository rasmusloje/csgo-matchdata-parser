namespace CsgoMatchData.Logic.Models;

public record MatchResult(IReadOnlyCollection<TeamScore> TeamScores, IReadOnlyCollection<RoundResult> RoundResults);