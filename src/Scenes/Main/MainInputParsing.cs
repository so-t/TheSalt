using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using static GlobalVariables;

[SuppressMessage("ReSharper", "StringLiteralTypo")]
public class MainInputParsing : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text display;
    
    // Start is called before the first frame update
    public void Start()
    {
        inputField = gameObject.GetComponent<TMP_InputField>();
        var submit = new TMP_InputField.SubmitEvent();
        submit.AddListener(Submit);
        inputField.onEndEdit = submit;
        inputField.ActivateInputField();
    }

    void ParseInput(string input)
    {
        GameLog += "\n<color=#292b30>" + input + "</color>\n";

        // Inputting "quit" will call Application.Quit(), thus exiting the game
        if (Regex.IsMatch(input, "[Qq]uit"))
        {
            Application.Quit();
        } 
        
        // Inputs starting with "Move" handled here.
        // "Move" followed by a direction checks if a room connection exists in that direction before moving the player.
        // "Move" followed by no direction will display a message clarifying a direction is needed
        if (Regex.IsMatch(input, "^[Mm]ove"))
        {
            if (Regex.IsMatch(input, "[Nn]orth$"))
            {
                player.Move(Directions.NORTH);
                DoUpdateMapDisplay = true;
                DoUpdateLogDisplay = true;
            } else if (Regex.IsMatch(input, "[Ee]ast$"))
            {
                player.Move(Directions.EAST);
                DoUpdateMapDisplay = true;
                DoUpdateLogDisplay = true;
            } else if (Regex.IsMatch(input, "[Ww]est$"))
            {
                player.Move(Directions.WEST);
                DoUpdateMapDisplay = true;
                DoUpdateLogDisplay = true;
            } else if (Regex.IsMatch(input, "[Ss]outh$"))
            {
                player.Move(Directions.SOUTH);
                DoUpdateMapDisplay = true;
                DoUpdateLogDisplay = true;
            } else if (Regex.IsMatch(input, "[Dd]own$"))
            {
                player.Move(Directions.DOWN);
                DoUpdateMapDisplay = true;
                DoUpdateLogDisplay = true;
            } else if (Regex.IsMatch(input, "[Uu]p$"))
            {
                player.Move(Directions.UP);
                DoUpdateMapDisplay = true;
                DoUpdateLogDisplay = true;
            }else {
                GameLog += "Move where?";
            }
        }
        
        // Inputs starting with "Look" handled here
        // "Look" on it's own will display the full description of the current room.
        else if(Regex.IsMatch(input, "^[Ll]ook"))
        {
            if(Regex.IsMatch(input, "^[Ll]ook ?(&|[Aa]round|(.*)[Rr]oom)*$")){
                player.Look();
            }
            else
            {
                // Make a copy of the user-entered target and set to lowercase
                var target = input.Split(' ').Last().ToLower();
                
                player.Look(target);
            }
        }

        // Inputs starting with "Attack" handled here
        else if (Regex.IsMatch(input, "^[Aa]ttack"))
        {
            if(Regex.IsMatch(input, "^[Aa]ttack$"))
            {
                GameLog += "Attack what?";
            }
            else if(Regex.IsMatch(input, " (.*)$"))
            {
                // Make a copy of the user-entered target and set to lowercase
                var target = input.Split(' ').Last().ToLower();
                var hasAttacked = false;
                
                // For each NPC in the room, we check if the name, set to lowercase, matches the input target.
                foreach (var obj in player.GetLocation().components.Where(obj => obj.GetName().ToLower() == target))
                {
                    hasAttacked = true;
                    player.Attack(obj);
                    if (obj.GetIsAlive())
                    {
                        obj.Attack(player);
                    }
                    break;
                }
                if(!hasAttacked) GameLog += "You don't see that here.";
            }
        }
        
        // Inputs starting with "Take" handled here
        else if (Regex.IsMatch(input, "^[Tt]ake"))
        {
            if (Regex.IsMatch(input, "^[Tt]ake ?$"))
            {
                GameLog += "Take what?";
            }
            else if(Regex.IsMatch(input, " (.*)$")){
                // Make a copy of the user-entered target and set to lowercase
                var target = input.Split(' ').Last().ToLower();
                
                // For each Item in the room, we check if the name, set to lowercase, contains the input target.
                foreach (var obj in player.GetLocation().components.Where(obj => (obj.GetType() == typeof(Item) || obj.GetType() == typeof(Weapon) || obj.GetType() == typeof(Consumable) || obj.GetType() == typeof(Antidote)) && obj.GetName().ToLower().Contains(target)))
                {
                    player.AddToInventory((Item) obj);
                    break;
                }
            }
        }
        
        // Inputs starting with "Equip" handled here
        else if (Regex.IsMatch(input, "^[Ee]quip"))
        {
            if (Regex.IsMatch(input, "^[Ee]quip ?$"))
            {
                GameLog += "Equip what?";
            }
            else if(Regex.IsMatch(input, " (.*)$")){
                // Make a copy of the user-entered target and set to lowercase
                var target = input.Split(' ').Last().ToLower();
                
                // For each Item in the room, we check if the name, set to lowercase, contains the input target.
                foreach (var stack in player.Inventory.Where(stack => stack.Name.ToLower().Contains(target)))
                {
                    var i = stack.Items.First.Value;
                    stack.Items.RemoveFirst();
                    player.Equip(i);
                    break;
                }
            }
        }
        
        // Inputs starting with "Use" handled here
        else if (Regex.IsMatch(input, "^[Uu]se"))
        {
            if (Regex.IsMatch(input, "^[Uu]se ?$"))
            {
                GameLog += "Use what?";
            }
            else if(Regex.IsMatch(input, " (.*)$")){
                // Make a copy of the user-entered target and set to lowercase
                var target = input.Split(' ').Last().ToLower();
                
                // For each Item in the room, we check if the name, set to lowercase, contains the input target.
                foreach (var stack in player.Inventory.Where(stack => stack.Name.ToLower().Contains(target)))
                {
                    var i = stack.Get();

                    if (stack.Count() == 0)
                        player.Inventory.Remove(stack);
                        
                    player.Use((Consumable) i);
                    break;
                }
            }
        }
    }

    private void Submit(string str)
    {
        ParseInput(str);
        inputField.SetTextWithoutNotify("");
        inputField.ActivateInputField();
    }
}