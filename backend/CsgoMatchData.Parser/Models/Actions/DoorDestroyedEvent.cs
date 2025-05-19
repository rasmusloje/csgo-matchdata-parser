using CsgoMatchData.Parser.Models.Actions.Abstractions;

namespace CsgoMatchData.Parser.Models.Actions;

public class DoorDestroyedEvent : EventBase
{
    public DoorDestroyedEvent(Weapon weaponUsed, Player destroyedBy)
    {
        WeaponUsed = weaponUsed;
        DestroyedBy = destroyedBy;
    }

    public Weapon WeaponUsed { get; }
    public Player DestroyedBy { get; }
}
