using System.Linq;
using UnityEngine;
using static GlobalVariables;

public class Player : Character
{
        // Private Variables
        
        // Public Variables
        public override void Move(Directions dir)
        {
                if(player.GetLocation().HasConnection((int) dir)){
                        if (dir == Directions.DOWN)
                                CurrentLevel += 1;
                        else if (dir == Directions.UP) CurrentLevel -= 1;

                        player.SetLocation(player.GetLocation().GetConnection((int) dir));
                        if (!player.GetLocation().GetVisited())
                        {
                                player.GetLocation().SetVisited(true);
                                for (var d = (int) Directions.NORTH; d < 4; d++)
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
                        GameLog += "</color>\n\n" + player.GetLocation().GetDescription();
                        
                        DoUpdateMapDisplay = true;
                        DoUpdateLogDisplay = true;
                } else {
                        GameLog += "There is no path in that direction!";
                }
        }

        public void Look()
        {
                GameLog += Location.GetDescription();
        }

        public override void StartAttacking(SaltComponent target)
        {
                if (!target.IsAlive())
                        GameLog += target.GetName() + " is already dead.";
                else 
                        base.StartAttacking(target);
        }

        public override void Attack(SaltComponent target)
        {
                TimeOfLastAction = Time.time;
                
                var damage = Rand.Next(1, GetWeapon().GetDamage());
                target.Defend(damage);
                GameLog += "You attack " + target.GetName() + " for " + damage + " points of damage" + 
                           (target.IsAlive() ? "!" : ", finishing " + target.GetThirdPersonObjective() + "!");
                
                if (!target.IsAlive())
                        StopAttacking();
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
                        foreach (var stack in Inventory)
                        {
                                GameLog += "\n\t" + stack.Name + (stack.Items.Count > 1 ? "\tx" + stack.Items.Count : ""); 
                        }
                        return;
                }
                
                foreach (var obj in Location.components.Where(obj => obj.GetName().ToLower().Contains(s)))
                {
                        GameLog += obj.GetDescription();
                        return;
                }

                foreach (var obj in Inventory.Where(obj => obj.Name.ToLower().Contains(s)))
                {
                        GameLog += obj.Description;
                        return;
                }
                
                GameLog += "You don't see that here.";
        }

        public override void Update()
        {
                if (IsAlive() && IsAttacking() && TimeOfLastAction + MinTimeTimeBetweenActions < Time.time)
                {
                        GameLog += "\n";
                        Attack(Target);
                }
        }
}