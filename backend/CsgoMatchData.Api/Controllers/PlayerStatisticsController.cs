using CsgoMatchData.Api.Responses;
using CsgoMatchData.Logic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CsgoMatchData.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class PlayerStatisticsController : ControllerBase
{
    private readonly IKillDeathCountService _killDeathCountService;

    public PlayerStatisticsController(IKillDeathCountService killDeathCountService)
    {
        _killDeathCountService = killDeathCountService ?? throw new ArgumentNullException(nameof(killDeathCountService));
    }

    [HttpGet]
    [Route("KillDeath")]
    public PlayerKillDeathResponse Get()
    {
        var playerKillDeathCounts = _killDeathCountService.GetPlayerKillDeathCounts();

        return new PlayerKillDeathResponse(playerKillDeathCounts);
    }
}