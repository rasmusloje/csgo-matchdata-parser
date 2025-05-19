using CsgoMatchData.Api.Responses;
using CsgoMatchData.Logic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CsgoMatchData.Api.Controllers;

[ApiController]
[Route("api/match/statistics")]
[Produces("application/json")]
public class MatchStatisticsController : ControllerBase
{
    private readonly IKillDistanceService _killDistanceService;
    private readonly IKillDeathCountService _killDeathCountService;

    public MatchStatisticsController(
        IKillDistanceService killDistanceService,
        IKillDeathCountService killDeathCountService
    )
    {
        _killDistanceService = killDistanceService;
        _killDeathCountService = killDeathCountService;
    }

    [HttpGet]
    [Route("kill-distances")]
    public KillDistanceResponse GetKillDistances()
    {
        var killDistanceStatistics = _killDistanceService.GetKillDistanceStatistics();

        return new KillDistanceResponse(
            killDistanceStatistics.ShortestDistance,
            killDistanceStatistics.AvgDistance,
            killDistanceStatistics.LongestDistance
        );
    }

    [HttpGet]
    [Route("kill-death")]
    public PlayerKillDeathResponse Get()
    {
        var playerKillDeathCounts = _killDeathCountService.GetPlayerKillDeathCounts();

        return new PlayerKillDeathResponse(playerKillDeathCounts);
    }
}
