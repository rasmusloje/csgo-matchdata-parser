using CsgoMatchData.Api.Responses;
using CsgoMatchData.Logic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CsgoMatchData.Api.Controllers;

[ApiController]
[Route("api/[controller]")]
[Produces("application/json")]
public class MatchController : ControllerBase
{
    private readonly IMatchTeamsService _matchTeamsService;

    public MatchController(
        IMatchTeamsService matchTeamsService)
    {
        _matchTeamsService = matchTeamsService ?? throw new ArgumentNullException(nameof(matchTeamsService));
    }

    [HttpGet]
    [Route("Teams")]
    public TeamResponse Get()
    {
        var teams = _matchTeamsService.GetMatchTeamsWithPlayers();

        return new TeamResponse(teams.TeamOne, teams.TeamTwo);
    }
}