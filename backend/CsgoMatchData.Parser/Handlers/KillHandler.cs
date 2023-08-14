using System.Text.RegularExpressions;
using CsgoMatchData.Parser.Handlers.Abstractions;
using CsgoMatchData.Parser.Models;
using CsgoMatchData.Parser.Models.Actions;
using CsgoMatchData.Parser.Models.Actions.Abstractions;

namespace CsgoMatchData.Parser.Handlers;

public class KillHandler : ActionHandler
{
    public override EventBase? Parse(string actionText)
    {
        if (!actionText.Contains("killed") || actionText.Contains("killed other"))
        {
            return base.Parse(actionText);
        }
        
        var playerAndWeaponSeparationPattern = new Regex(@"\""(.*?)\""", RegexOptions.IgnoreCase);
        var playerNameAndWeaponSeparationMatches = playerAndWeaponSeparationPattern.Matches(actionText).ToList();

        var killerNameString = playerNameAndWeaponSeparationMatches[0].Value;
        var victimNameString = playerNameAndWeaponSeparationMatches[1].Value;
        
        var playerPattern = new Regex("[A-Za-z0-9]+", RegexOptions.IgnoreCase);
        var killerNameMatch = playerPattern.Match(killerNameString);
        var victimNameMatch = playerPattern.Match(victimNameString);
        var killerNameTeamType = ParseTeamTypeFromPlayerString(killerNameString);
        var victimNameTeamType = ParseTeamTypeFromPlayerString(victimNameString);

        var weaponUsedToKill = playerNameAndWeaponSeparationMatches[2].Value;
        var weaponWithoutQuotationMarks = weaponUsedToKill.Replace("\"", string.Empty);
        
        var killDistanceInUnits = CalculateKillDistanceInUnits(actionText);

        var killerPlayer = new Player(killerNameMatch.Value, killerNameTeamType);
        var victimPlayer = new Player(victimNameMatch.Value, victimNameTeamType);
        var weaponUsed = new Weapon(weaponWithoutQuotationMarks);
        var killDistance = new Distance(killDistanceInUnits);

        return new KillEvent(killerPlayer, victimPlayer, weaponUsed, killDistance);
    }

    private TeamType ParseTeamTypeFromPlayerString(string playerString)
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
    
    private static float CalculateKillDistanceInUnits(string actionText)
    {
        var playerPointsPattern = new Regex("\\[(.*?)\\]", RegexOptions.IgnoreCase);
        var playerPointMatches = playerPointsPattern.Matches(actionText);
        
        var playerPointValuesPattern = new Regex("([+-]?(?=\\.\\d|\\d)(?:\\d+)?(?:\\.?\\d*))(?:[Ee]([+-]?\\d+))?", RegexOptions.IgnoreCase);
        var killerPointValueMatches = playerPointValuesPattern.Matches(playerPointMatches[0].Value);
        var killerX = float.Parse(killerPointValueMatches[0].Value);
        var killerY = float.Parse(killerPointValueMatches[1].Value);
        var killerZ = float.Parse(killerPointValueMatches[2].Value);
        
        var victimPointValueMatches = playerPointValuesPattern.Matches(playerPointMatches[1].Value);
        var victimX = float.Parse(victimPointValueMatches[0].Value);
        var victimY = float.Parse(victimPointValueMatches[1].Value);
        var victimZ = float.Parse(victimPointValueMatches[2].Value);
        
        var deltaX = killerX - victimX;
        var deltaY = killerY - victimY;
        var deltaZ = killerZ - victimZ;
        
        var killDistanceInUnits = (float)Math.Sqrt(deltaX * deltaX + deltaY * deltaY + deltaZ * deltaZ);
        
        return killDistanceInUnits;
    }
}