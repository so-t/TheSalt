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
            case (int) Weapons.QUARTERSTAFF:
                _damage = (int) WeaponDamages.QUARTERSTAFF;
                break;
            case (int) Weapons.SOLDIERS_SPEAR:
                _damage = (int) WeaponDamages.SOLDIERS_SPEAR;
                break;
            case (int) Weapons.WOODCUTTING_AXE:
                _damage = (int) WeaponDamages.WOODCUTTING_AXE;
                break;
            case (int) Weapons.BLACKSMITHS_HAMMER:
                _damage = (int) WeaponDamages.BLACKSMITHS_HAMMER;
                break;
            case (int) Weapons.UNARMED:
                _damage = (int) WeaponDamages.UNARMED;
                break;
        }
    }

    public int GetDamage()
    {
        return _damage;
    }

}
