using CsgoMatchData.Logic.Models;

namespace CsgoMatchData.Api.Responses;

public record TeamResponse(Team TeamOne, Team TeamTwo);