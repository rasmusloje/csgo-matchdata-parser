using System.Text.RegularExpressions;
using CsgoMatchData.Parser.Handlers.Abstractions;
using CsgoMatchData.Parser.Helpers;
using CsgoMatchData.Parser.Models;
using CsgoMatchData.Parser.Models.Actions;
using CsgoMatchData.Parser.Models.Actions.Abstractions;

namespace CsgoMatchData.Parser.Handlers;

public class DoorDestroyedHandler : ActionHandler
{
    public override EventBase? Parse(string actionText)
    {
        var isPropDoorRotatingDestroyed = actionText.Contains("killed other \"prop_door_rotating");
        if (!isPropDoorRotatingDestroyed)
        {
            return base.Parse(actionText);
        }

        var lastItemInString = actionText.Split(" ").Last();
        var weaponPattern = new Regex("[A-Za-z0-9]+", RegexOptions.IgnoreCase);
        var match = weaponPattern.Match(lastItemInString);
        var weapon = new Weapon(match.Value);

        var player = PlayerExtractor.ParsePlayerFromActionText(actionText);

        return new DoorDestroyedEvent(weapon, player);
    }
}
