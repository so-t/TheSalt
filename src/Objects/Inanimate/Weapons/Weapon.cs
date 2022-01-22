using static GlobalVariables;

public class Weapon : Item
{
    // Private Variables
    private int _damage;
    private int _defense;
    
    
    // Public Variables
    public void SetWeaponType(Weapons type)
    {
        _damage = WeaponStats[type]["damage"];
        _defense = WeaponStats[type]["defense"];
        SetName(WeaponDetails[type]["name"]);
        SetDescription(WeaponDetails[type]["description"]);
    }

    public int GetDamage()
    {
        return _damage;
    }

}
