using System.Linq;
using static GlobalVariables;
public class Player : Character
{
        // Private Variables
        
        // Public Variables
        public void Move(Directions dir)
        {
                if(player.GetLocation().HasConnection((int) dir)){
                        switch (dir)
                        {
                                case Directions.DOWN:
                                        CurrentLevel += 1;
                                        break;
                                case Directions.UP:
                                        CurrentLevel -= 1;
                                        break;
                        }

                        player.SetLocation(player.GetLocation().GetConnection((int) dir));
                        if (!player.GetLocation().GetVisited())
                        {
                                player.GetLocation().SetVisited(true);
                                for (int d = (int) Directions.NORTH; d < 4; d++)
                                {
                                        if (player.GetLocation().GetConnection(d) != null && !player.GetLocation().GetConnection(d).GetDiscovered())
                                        {
                                                player.GetLocation().GetConnection(d).SetDiscovered(true);
                                        }
                                }
                        }
            
                        // <color=#292b30>---<</color> A Normal Room <color=#292b30>>--------------------------------------</color>

                        string title = "---< " + player.GetLocation().GetTitle() + " >";
                        GameLog = "<color=#292b30>---<</color> " + player.GetLocation().GetTitle() + " <color=#292b30>>";
                        for (int x = title.Length; x < (int) Maps.MAX_CHAR_PER_MAIN_DISPLAY_LINE; x++)
                        {
                                GameLog += "-";
                        }
                        GameLog += "</color>\n" + player.GetLocation().GetDescription();
                } else {
                        GameLog += "There is no path in that direction!";
                }
        }

        public void Look()
        {
                GameLog += Location.GetDescription();
        }

        public void Look(string s)
        {
                if (s == "inventory")
                {
                        if (Inventory.Count == 0)
                        {
                                GameLog += "Your inventory is empty.";
                                return;
                        }

                        GameLog += "You have:";
                        foreach (var item in Inventory)
                        {
                                GameLog += "\n\t" + item.GetName();
                        }
                        return;
                }
                
                foreach (var obj in Location.components.Where(obj => obj.GetName().ToLower().Contains(s)))
                {
                        GameLog += obj.GetDescription();
                        return;
                }

                foreach (var obj in Inventory.Where(obj => obj.GetName().ToLower().Contains(s)))
                {
                        GameLog += obj.GetDescription();
                        return;
                }
                
                GameLog += "\nYou don't see that here.";
        }
}