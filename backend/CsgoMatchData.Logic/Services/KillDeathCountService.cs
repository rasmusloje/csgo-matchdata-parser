using CsgoMatchData.Logic.Models;
using CsgoMatchData.Logic.Providers.Interfaces;
using CsgoMatchData.Logic.Services.Interfaces;
using CsgoMatchData.Parser.Models.Actions;

namespace CsgoMatchData.Logic.Services;

public class KillDeathCountService : IKillDeathCountService
{
    private readonly IMatchDataProvider _matchDataProvider;

    public KillDeathCountService(IMatchDataProvider matchDataProvider)
    {
        _matchDataProvider = matchDataProvider ?? throw new ArgumentNullException(nameof(matchDataProvider));
    }
    
    public IReadOnlyCollection<PlayerKillDeathCount> GetPlayerKillDeathCounts()
    {
        var rounds = _matchDataProvider.GetMatchRounds();
        
        var killEvents = rounds
            .SelectMany(round => round.Events)
            .Where(roundEvent => roundEvent.EventBase is KillEvent)
            .Select(roundEvent => roundEvent.EventBase)
            .Cast<KillEvent>();

        var killDeathCounts = new Dictionary<string, KillDeathCounter>();
        
        foreach (var killEvent in killEvents)
        {
            IncrementKills(killDeathCounts, killEvent);
            IncrementDeaths(killDeathCounts, killEvent);
        }

        var mappedKillCountResult = killDeathCounts
            .Select(killCount => 
                new PlayerKillDeathCount(
                    killCount.Key, 
                    killCount.Value.KillCounter,
                    killCount.Value.DeathCounter));

        return mappedKillCountResult.ToList();
    }

    private static void IncrementKills(IDictionary<string, KillDeathCounter> killDeathCounts, KillEvent killEvent)
    {
        if (!killDeathCounts.ContainsKey(killEvent.Killer.Name))
        {
            killDeathCounts.Add(killEvent.Killer.Name, new KillDeathCounter(1, 0));
        }
        else
        {
            killDeathCounts[killEvent.Killer.Name].KillCounter++;
        }
    }
    
    private static void IncrementDeaths(IDictionary<string, KillDeathCounter> killDeathCounts, KillEvent killEvent)
    {
        if (!killDeathCounts.ContainsKey(killEvent.Victim.Name))
        {
            killDeathCounts.Add(killEvent.Victim.Name, new KillDeathCounter(0, 1));
        }
        else
        {
            killDeathCounts[killEvent.Victim.Name].DeathCounter++;
        }
    }

    private class KillDeathCounter
    {
        public KillDeathCounter(int killCounter, int deathCounter)
        {
            KillCounter = killCounter;
            DeathCounter = deathCounter;
        }

        public int KillCounter { get; set; }
        public int DeathCounter { get; set; }
    }
}