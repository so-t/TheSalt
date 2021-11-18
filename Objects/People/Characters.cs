using static GlobalVariables;

public class Character : SaltGameObject
{
    // Private Variables

    // Public Variables
    public override int Attack(SaltGameObject target)
    {
        int damage = Rand.Next( 1, GetWeapon().GetDamage() );
        target.Defend(damage);
        return damage;
    }

    public override void Update()
    {
        ApplyStatus();
    }
}