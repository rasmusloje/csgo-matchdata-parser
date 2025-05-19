using CsgoMatchData.Parser.Models;

namespace CsgoMatchData.Api.Responses;

public record KillDistanceResponse(
    Distance ShortestKillDistance,
    Distance AverageKillDistance,
    Distance LongestKillDistance
);
