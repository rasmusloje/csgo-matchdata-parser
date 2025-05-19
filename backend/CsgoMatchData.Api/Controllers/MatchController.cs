using CsgoMatchData.Api.Responses;
using CsgoMatchData.Logic.Services.Interfaces;
using Microsoft.AspNetCore.Mvc;

namespace CsgoMatchData.Api.Controllers;

[ApiController]
[Route("api/match")]
public class MatchController : ControllerBase
{
    private readonly IMatchTeamsService _matchTeamsService;
    private readonly IMatchResultService _matchResultService;

    public MatchController(
        IMatchTeamsService matchTeamsService,
        IMatchResultService matchResultService
    )
    {
        _matchTeamsService = matchTeamsService;
        _matchResultService = matchResultService;
    }

    [HttpGet]
    [Route("teams")]
    public TeamResponse Get()
    {
        var teams = _matchTeamsService.GetMatchTeamsWithPlayers();

        return new TeamResponse(teams.TeamOne, teams.TeamTwo);
    }

    [HttpGet]
    [Route("results")]
    public MatchStatisticResponse GetMatchResult()
    {
        var matchResult = _matchResultService.GetMatchResult();

        return new MatchStatisticResponse(matchResult);
    }
}
