using System.Text.RegularExpressions;
using CsgoMatchData.Parser.Models;

namespace CsgoMatchData.Parser.Helpers;

internal class PlayerExtractor
{
    internal static Player ParsePlayerFromActionText(string actionText)
    {
        var fullPlayerInfoPattern = new Regex(@"\""(.*?)\""", RegexOptions.IgnoreCase);
        var fullPlayerInfoMatch = fullPlayerInfoPattern.Match(actionText);

        var playerNamePattern = new Regex("[A-Za-z0-9]+", RegexOptions.IgnoreCase);
        var playerName = playerNamePattern.Match(fullPlayerInfoMatch.Value);
        var teamTypeOfPlayer = ParseTeamTypeFromPlayerString(fullPlayerInfoMatch.Value);

        return new Player(playerName.Value, teamTypeOfPlayer);
    }

    private static TeamType ParseTeamTypeFromPlayerString(string playerString)
    {
        if (playerString.Contains("<CT>"))
        {
            return TeamType.CounterTerrorist;
        }

        if (playerString.Contains("<TERRORIST>"))
        {
            return TeamType.Terrorist;
        }

        throw new ArgumentException($"{nameof(TeamType)} doesn't exist");
    }
}
