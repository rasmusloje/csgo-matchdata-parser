using CsgoMatchData.Parser.Models.Actions.Abstractions;

namespace CsgoMatchData.Parser.Models.Actions;

public class DoorDestroyedEvent : EventBase
{
    public DoorDestroyedEvent(Weapon weaponUsed)
    {
        WeaponUsed = weaponUsed;
    }

    public Weapon WeaponUsed { get; }
}