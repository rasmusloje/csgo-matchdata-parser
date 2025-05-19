using CsgoMatchData.Parser.Models;

namespace CsgoMatchData.Logic.Services.Interfaces;

public interface IKillDistanceService
{
    (
        Distance ShortestDistance,
        Distance AvgDistance,
        Distance LongestDistance
    ) GetKillDistanceStatistics();
}
