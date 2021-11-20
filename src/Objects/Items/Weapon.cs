using TMPro;

public class Weapon : Item
{
    // Private Variables
    private int _damage;
    private string _description;
    
    // Public Variables
    public void SetWeaponType(Weapons type)
    {
        switch (type)
        {
            case Weapons.QUARTERSTAFF:
                _damage = (int) WeaponDamages.QUARTERSTAFF;
                break;
            case Weapons.SOLDIERS_SPEAR:
                _damage = (int) WeaponDamages.SOLDIERS_SPEAR;
                break;
            case Weapons.WOODCUTTING_AXE:
                _damage = (int) WeaponDamages.WOODCUTTING_AXE;
                break;
            case Weapons.BLACKSMITHS_HAMMER:
                _damage = (int) WeaponDamages.BLACKSMITHS_HAMMER;
                break;
            case Weapons.UNARMED:
                _damage = (int) WeaponDamages.UNARMED;
                break;
        }
    }

    public int GetDamage()
    {
        return _damage;
    }

}
