using CsgoMatchData.Logic.Models;

namespace CsgoMatchData.Logic.Services.Interfaces;

public interface IMatchTeamsService
{
    (Team TeamOne, Team TeamTwo) GetMatchTeamsWithPlayers();
}