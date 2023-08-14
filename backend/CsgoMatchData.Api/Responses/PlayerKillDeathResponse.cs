using CsgoMatchData.Logic.Models;

namespace CsgoMatchData.Api.Responses;

public record PlayerKillDeathResponse(IReadOnlyCollection<PlayerKillDeathCount> PlayerKillDeathCounts);