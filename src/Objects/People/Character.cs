using System.Collections.Generic;
using System.Linq;
using static GlobalVariables;

public class Character : SaltComponent
{
    // Private Variables
    
    // Public Variables
    protected Weapon Weapon;
    public LinkedList<ItemStack> Inventory = new LinkedList<ItemStack>();
    
    public override void Awake()
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
            var addedToStack = false;
            foreach (var stack in Inventory.Where(stack => i.GetName() == stack.Name))
            {
                stack.Items.AddFirst(i);
                addedToStack = true;
            }

            if (!addedToStack)
            {
                var stack = new ItemStack(i);
                Inventory.AddLast(stack);
            }
            
            GameLog += "You pick up the " + i.GetName() + ".";
            return;
        }
        GameLog += "You don't see that item here.";
    }

    public bool RemoveFromInventory(Item i)
    {
        foreach (var stack in from stack in Inventory where i.GetName() == stack.Name from item in stack.Items where i == item select stack)
        {
            stack.Items.Remove(i);
            Location.AddSaltComponent(i);
            if (stack.Items.Count == 0)
                player.Inventory.Remove(stack);
            return true;
        }

        return false;
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