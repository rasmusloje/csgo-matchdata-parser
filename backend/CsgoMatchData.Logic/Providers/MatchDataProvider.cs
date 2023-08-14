using CsgoMatchData.Logic.Providers.Interfaces;
using CsgoMatchData.Parser.Models;

namespace CsgoMatchData.Logic.Providers;

public class MatchDataProvider : IMatchDataProvider
{
    private readonly IReadOnlyCollection<Round> _rounds;

    public MatchDataProvider(IReadOnlyCollection<Round> rounds)
    {
        _rounds = rounds;
    }
    
    public IReadOnlyCollection<Round> GetMatchRounds()
    {
        return _rounds;
    }
}