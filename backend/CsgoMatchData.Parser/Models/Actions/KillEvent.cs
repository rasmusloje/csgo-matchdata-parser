using CsgoMatchData.Parser.Models.Actions.Abstractions;

namespace CsgoMatchData.Parser.Models.Actions;

public class KillEvent : EventBase
{
    public KillEvent(Player killer, Player victim, Weapon weapon, Distance killDistance)
    {
        Killer = killer;
        Victim = victim;
        WeaponUsed = weapon;
        KillDistance = killDistance;
    }

    public Player Killer { get; }
    public Player Victim { get; }
    public Weapon WeaponUsed { get; }
    public Distance KillDistance { get; }
}