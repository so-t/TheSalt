using System.Collections.Generic;
using System.Linq;

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

        public Item Get()
        {
                var i = Items.First();
                Items.RemoveFirst();
                return i;
        }

        public int Count()
        {
                return Items.Count;
        }
}