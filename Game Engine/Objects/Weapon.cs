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
            case QUARTERSTAFF:
                _damage = QUARTERSTAFF_DAMAGE;
                break;
            case SOLDIERS_SPEAR:
                _damage = SOLDIERS_SPEAR_DAMAGE;
                break;
            case WOODCUTTING_AXE:
                _damage = WOODCUTTING_AXE_DAMAGE;
                break;
            case BLACKSMITHS_HAMMER:
                _damage = BLACKSMITHS_HAMMER_DAMAGE;
                break;
            case UNARMED:
                _damage = UNARMED_DAMAGE;
                break;
        }
    }

    public int GetDamage()
    {
        return _damage;
    }

}
