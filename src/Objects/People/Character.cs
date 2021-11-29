using System.Collections.Generic;
using System.Linq;
using UnityEngine;
using static GlobalVariables;

public class Character : SaltComponent
{
    // Private Variables
    private void AddToInventory(Item i)
    {
        foreach (var stack in Inventory.Where(stack => i.GetName() == stack.Name))
        {
            stack.Items.AddFirst(i);
            return;
        }
        
        var newStack = new ItemStack(i);
        Inventory.AddLast(newStack);
    }

    private Item RemoveFromInventory(ItemStack stack)
    {
        var i = stack.Get();

        if (stack.Count() == 0)
            player.Inventory.Remove(stack);

        return i;
    }
    
    // Public Variables
    protected Weapon Weapon;
    public readonly LinkedList<ItemStack> Inventory = new LinkedList<ItemStack>();
    
    public override void Awake()
    {
        SetHealth(10);
        SetIsAlive(true);
        TimeOfLastAction = Time.time;
        Weapon = TheSalt.AddComponent<Weapon>();
        Weapon.SetWeaponType(Weapons.UNARMED);
    }
    
    public virtual void Move(Directions dir){}

    public override void StartAttacking(SaltComponent target)
    {
        Target = target;
        TimeOfLastAction = Time.time;
        SetIsAttacking(true);
        Attack(target);
        if (!target.IsAttacking())
            target.StartAttacking(this);
    }

    public override void Defend(int damage)
    {
        SetHealth(GetHealth() - damage);
        if (GetHealth() <= 0) SetIsAlive(false);
    }

    public void Take(Item i)
    {
        if (Location.components.Remove(i))
        {
            AddToInventory(i);
            
            GameLog += "You pick up the " + i.GetName() + ".";
            return;
        }
        GameLog += "You don't see that item here.";
    }

    public void Drop(ItemStack stack)
    {
        var i = RemoveFromInventory(stack);
        
        Location.components.AddLast(i);
        GameLog += "You drop the " + i.GetName();
    }

    public void Use(ItemStack stack)
    {
        var i = RemoveFromInventory(stack);

        ((Consumable) i).Use(this);
    }

    protected Weapon GetWeapon()
    {
        return Weapon;
    }

    public void Equip(ItemStack stack)
    {
        if (stack.Items.First.Value.GetType() != typeof(Weapon)) return;
        
        if (Weapon.GetName() != "Unarmed")
            AddToInventory(Weapon);
            
        Weapon = (Weapon) stack.Get();
        if (stack.Count() == 0)
            Inventory.Remove(stack);
        GameLog += "You equip the " + Weapon.GetName() + ".";
    }
}