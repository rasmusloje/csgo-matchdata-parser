using CsgoMatchData.Parser.Models;

namespace CsgoMatchData.Logic.Providers.Interfaces;

public interface IMatchDataProvider
{
    IReadOnlyCollection<Round> GetMatchRounds();
}