using static GlobalVariables;

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
                SetName("Quarterstaff");
                SetDescription("The staff is not unlike the staves of apprentice mages or weatherweavers. Serves as a fine club.");
                break;
            case Weapons.SOLDIERS_SPEAR:
                _damage = (int) WeaponDamages.SOLDIERS_SPEAR;
                SetName("Soldier's Spear");
                SetDescription("A standard issue spear with an iron point, modified to have a shorter hilt.");
                break;
            case Weapons.WOODCUTTING_AXE:
                _damage = (int) WeaponDamages.WOODCUTTING_AXE;
                SetName("Woodcutting");
                SetDescription("A well-crafted tool, recently sharpened.");
                break;
            case Weapons.BLACKSMITHS_HAMMER:
                _damage = (int) WeaponDamages.BLACKSMITHS_HAMMER;
                SetName("Blacksmith's Hammer");
                var initials = (char) (Rand.Next(1, 26) + 64) + "." + (char) (Rand.Next(1, 26) + 64) + "." + (char) (Rand.Next(1, 26) + 64) + ".";
                SetDescription("The hammer shows signs of heavy use. The initials " + initials.ToUpper() + " are carved into the wooden handle");
                break;
            case Weapons.UNARMED:
                _damage = (int) WeaponDamages.UNARMED;
                SetName("Unarmed");
                SetDescription("Your fists.");
                break;
        }
    }

    public int GetDamage()
    {
        return _damage;
    }

}
