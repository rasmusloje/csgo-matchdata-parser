using CsgoMatchData.Logic.Models;

namespace CsgoMatchData.Logic.Services.Interfaces;

public interface IRoundResultService
{
    IReadOnlyCollection<RoundResult> GetRoundResults();
}
