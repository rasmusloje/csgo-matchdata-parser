using CsgoMatchData.Logic.Providers.Interfaces;
using CsgoMatchData.Logic.Services.Interfaces;
using CsgoMatchData.Parser.Models;
using CsgoMatchData.Parser.Models.Actions;

namespace CsgoMatchData.Logic.Services;

public class KillDistanceService : IKillDistanceService
{
    private readonly IMatchDataProvider _matchDataProvider;

    public KillDistanceService(IMatchDataProvider matchDataProvider)
    {
        _matchDataProvider = matchDataProvider ?? throw new ArgumentNullException(nameof(matchDataProvider));
    }
    
    public (Distance ShortestDistance, Distance AvgDistance, Distance LongestDistance) GetKillDistanceStatistics()
    {
        var rounds = _matchDataProvider.GetMatchRounds();
        
        var killEvents = rounds
            .SelectMany(round => round.Events)
            .Where(roundEvent => roundEvent.EventBase is KillEvent)
            .Select(roundEvent => roundEvent.EventBase)
            .Cast<KillEvent>()
            .ToList();

        var shortestDistanceKill = killEvents.Min(killEvent => killEvent.KillDistance.DistanceInUnits);
        var averageDistanceKill = killEvents.Average(killEvent => killEvent.KillDistance.DistanceInUnits);
        var longestDistanceKill = killEvents.Max(killEvent => killEvent.KillDistance.DistanceInUnits);

        return (
            new Distance(shortestDistanceKill), 
            new Distance(averageDistanceKill),
            new Distance(longestDistanceKill));
    }
}