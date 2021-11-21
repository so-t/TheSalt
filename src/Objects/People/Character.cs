using System.Collections.Generic;
using UnityEngine;
using static GlobalVariables;

public class Character : SaltComponent
{
    // Private Variables
    
    // Public Variables
    protected Weapon Weapon;
    protected LinkedList<Item> Inventory = new LinkedList<Item>();
    
    public override void Start()
    {
        Weapon = TheSalt.AddComponent<Weapon>();
        Weapon.SetWeaponType(Weapons.UNARMED);
    }

    public override void Attack(SaltComponent target)
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

    public void AddToInventory(Item i)
    {
        Inventory.AddLast(i);
    }

    public bool RemoveFromInventory(Item i)
    {
        return Inventory.Remove(i);
    }

    protected Weapon GetWeapon()
    {
        return Weapon;
    }

    public void Equip(Item i)
    {
        if (i.GetType() == typeof(Weapon))
            Weapon = (Weapon) i;
    }


    public override void Update() {}
}