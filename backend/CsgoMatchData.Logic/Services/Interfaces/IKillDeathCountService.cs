using CsgoMatchData.Logic.Models;

namespace CsgoMatchData.Logic.Services.Interfaces;

public interface IKillDeathCountService
{
    IReadOnlyCollection<PlayerKillDeathCount> GetPlayerKillDeathCounts();
}
