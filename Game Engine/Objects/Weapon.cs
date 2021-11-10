using static Constants;

public class Weapon
{
    // Private Variables
    private int _damage;
    private string _description;
    
    // Public Variables
    public Weapon(int type)
    {
        switch (type)
        {
            case Weapons.QUARTERSTAFF:
                _damage = WeaponDamages.QUARTERSTAFF_DAMAGE;
                break;
            case Weapons.SOLDIERS_SPEAR:
                _damage = WeaponDamages.SOLDIERS_SPEAR_DAMAGE;
                break;
            case Weapons.WOODCUTTING_AXE:
                _damage = WeaponDamages.WOODCUTTING_AXE_DAMAGE;
                break;
            case Weapons.BLACKSMITHS_HAMMER:
                _damage = WeaponDamages.BLACKSMITHS_HAMMER_DAMAGE;
                break;
            case Weapons.UNARMED:
                _damage = WeaponDamages.UNARMED_DAMAGE;
                break;
        }
    }

    public int GetDamage()
    {
        return _damage;
    }

}
