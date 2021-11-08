using static GlobalVariables;
using static Constants;


public class Character : SaltGameObject
{
    // Private Variables
    private bool _isALive;
    private Weapon _weapon = new Weapon(UNARMED);

    // Public Variables
    public void Defend(int damage)
    {
        SetHealth(damage >= GetHealth() ?  GetHealth() - damage : 0);
        if (GetHealth() == 0) _isALive = false;
    }

    public int Attack(Character target)
    {
        int damage = Rand.Next( 1, _weapon.GetDamage() );
        target.Defend(damage);
        return damage;
    }

    public void SetIsAlive(bool isAlive)
    {
        _isALive = isAlive;
    }

    public bool GetIsAlive()
    {
        return _isALive;
    }

    public void SetWeapon(Weapon weapon)
    {
        _weapon = weapon;
    }

    public Weapon GetWeapon()
    {
        return _weapon;
    }

    public override void Update()
    {
        
    }
}