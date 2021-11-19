using UnityEngine;
using static GlobalVariables;

public class Character : SaltGameObject
{
    // Private Variables

    // Public Variables
    public Character()
    {
        Weapon = new Weapon((int) Weapons.UNARMED);
    }

    public override void Attack(SaltGameObject target)
    {
        if (!target.GetIsAlive())
        {
            GameLog += target.GetName() + " is already dead.";
        }
        else
        {
            int damage = Rand.Next(1, GetWeapon().GetDamage());
            target.Defend(damage);
            GameLog += "\nYou attack " + target.GetName() + " for " + damage + " points of damage" +
                   (target.GetIsAlive() ? "!" : ", finishing " + target.GetThirdPersonObjective() + "!");
        }
        
    }

    public override void Defend(int damage)
    {
        SetHealth(GetHealth() - damage);
        if (GetHealth() <= 0) SetIsAlive(false);
    }


    public override void Update()
    {
        ApplyStatus();
    }
}