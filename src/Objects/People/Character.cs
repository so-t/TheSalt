using System.Collections.Generic;
using static GlobalVariables;

public class Character : SaltComponent
{
    // Private Variables
    
    // Public Variables
    protected Weapon Weapon;
    public LinkedList<Item> Inventory = new LinkedList<Item>();
    
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
            GameLog += "You attack " + target.GetName() + " for " + damage + " points of damage" +
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
        if (Location.components.Remove(i))
        {
            Inventory.AddLast(i);
            GameLog += "You pick up the " + i.GetName() + ".";
            return;
        }
        GameLog += "You don't see that item here.";
    }

    public bool RemoveFromInventory(Item i)
    {
        var node = Inventory.Find(i);
        if (node != null)
            Location.components.AddFirst(i);
        return Inventory.Remove(i);
    }

    protected Weapon GetWeapon()
    {
        return Weapon;
    }

    public void Equip(Item i)
    {
        if (i.GetType() == typeof(Weapon))
        {
            Weapon = (Weapon) i;
            GameLog += "You equip the " + i.GetName() + ".";
        }
    }

    public override void Update() {}
}