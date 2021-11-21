using System.Collections.Generic;

public class ItemStack
{
        // Private Variables
        
        // Public Variables
        public LinkedList<Item> Items = new LinkedList<Item>();
        public readonly string Name, Description;
        
        public ItemStack(Item i)
        {
                Name = i.GetName();
                Description = i.GetDescription();
                Items.AddFirst(i);
        }
}