using CsgoMatchData.Api.Responses;
using CsgoMatchData.Logic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CsgoMatchData.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class MatchStatisticsController : ControllerBase
{
    private readonly IMatchResultService _matchResultService;
    private readonly IKillDistanceService _killDistanceService;

    public MatchStatisticsController(
        IMatchResultService matchResultService,
        IKillDistanceService killDistanceService)
    {
        _matchResultService = matchResultService ?? throw new ArgumentNullException(nameof(matchResultService));
        _killDistanceService = killDistanceService ?? throw new ArgumentNullException(nameof(killDistanceService));
    }

    [HttpGet]
    [Route("Result")]
    public MatchStatisticResponse GetMatchResult()
    {
        var matchResult = _matchResultService.GetMatchResult();

        return new MatchStatisticResponse(matchResult);
    }
    
    [HttpGet]
    [Route("KillDistances")]
    public KillDistanceResponse GetKillDistances()
    {
        var killDistanceStatistics = _killDistanceService.GetKillDistanceStatistics();

        return new KillDistanceResponse(
            killDistanceStatistics.ShortestDistance, 
            killDistanceStatistics.AvgDistance, 
            killDistanceStatistics.LongestDistance);
    }
}