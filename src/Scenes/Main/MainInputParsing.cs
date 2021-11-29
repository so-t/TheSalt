using System;
using System.Collections.Generic;
using System.Diagnostics.CodeAnalysis;
using System.Linq;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using static GlobalVariables;

[SuppressMessage("ReSharper", "StringLiteralTypo")]
public class MainInputParsing : MonoBehaviour
{
    // Private Variables
    private readonly LinkedList<string> _commands = new LinkedList<string>();
    private int _command;

    private void ParseInput(string input)
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
            } else if (Regex.IsMatch(input, "[Ee]ast$"))
            {
                player.Move(Directions.EAST);
            } else if (Regex.IsMatch(input, "[Ww]est$"))
            {
                player.Move(Directions.WEST);
            } else if (Regex.IsMatch(input, "[Ss]outh$"))
            {
                player.Move(Directions.SOUTH);
            } else if (Regex.IsMatch(input, "[Dd]own$"))
            {
                player.Move(Directions.DOWN);
            } else if (Regex.IsMatch(input, "[Uu]p$"))
            {
                player.Move(Directions.UP);
            } else
                GameLog += "Move where?";
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
                
                // For each NPC in the room, we check if the name, set to lowercase, matches the input target.
                foreach (var obj in player.GetLocation().components.Where(obj => obj.GetName().ToLower() == target))
                {
                    player.StartAttacking(obj);
                    return;
                }
                
                GameLog += "You don't see that here.";
            }
        }
        
        // Inputs starting with "Take" handled here3
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
                foreach (var obj in player.GetLocation().components.Where(obj => obj.GetType() != typeof(NPC) && obj.GetName().ToLower().Contains(target)))
                {
                    player.Take((Item) obj);
                    return;
                }
                
                GameLog += "Take what?";
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
                
                // For each Item in the Player's inventory, we check if the name, set to lowercase, contains the input target.
                foreach (var stack in player.Inventory.Where(stack => stack.Name.ToLower().Contains(target)))
                {
                    player.Equip(stack);
                    return;
                }

                GameLog += "You don't seem to have that.";
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
                
                // For each Item in the Player's inventory, we check if the name, set to lowercase, contains the input target.
                foreach (var stack in player.Inventory.Where(stack => stack.Name.ToLower().Contains(target)))
                {
                    player.Use(stack);
                    return;
                }

                GameLog += "You don't see that.";
            }
        }
        
        // Inputs starting with "Drop" handled here
        else if (Regex.IsMatch(input, "^[Dd]rop"))
        {
            if (Regex.IsMatch(input, "^[Dd]rop ?$"))
            {
                GameLog += "Drop what?";
            }
            else if (Regex.IsMatch(input, " (.*)$"))
            {
                // Make a copy of the user-entered target and set to lowercase
                var target = input.Split(' ').Last().ToLower();
                
                // For each Item in the Player's inventory, we check if the name, set to lowercase, contains the input target.
                foreach (var stack in player.Inventory.Where(stack => stack.Name.ToLower().Contains(target)))
                {
                    player.Drop(stack);
                    return;
                }

                GameLog += "You don't seem to have that";
            }
        }
    }
    
    // Public Variables
    public TMP_InputField inputField;
    public TMP_Text display;
    
    public void Start()
    {
        inputField = gameObject.GetComponent<TMP_InputField>();
        var submit = new TMP_InputField.SubmitEvent();
        submit.AddListener(Submit);
        inputField.onEndEdit = submit;
        inputField.ActivateInputField();
    }

    private void Submit(string str)
    {
        if (str != "")
        {
            ParseInput(str);
            _commands.AddFirst(str);
            _command = 0;
            inputField.SetTextWithoutNotify("");
        }
        
        inputField.ActivateInputField();
    }

    public void Update()
    {
        if (_commands.Count > 10)
        {
            _commands.RemoveLast();
        }
        if (Input.GetKeyDown("up"))
        {
            if (_command == _commands.Count) return;
            
            if (_command == 0 && (inputField.text != "" || _commands.First.Value != ""))
                _commands.AddFirst(inputField.text);

            var command = _commands.First;
            if (command == null) return;
            
            _command++;
            
            for (var i = 0; i < _command && command?.Next != null; i++)
            {
                command = command.Next;
            }

            inputField.SetTextWithoutNotify(command.Value);
            inputField.MoveTextEnd(false);
        }
        else if (Input.GetKeyDown("down"))
        {
            if (_command == 0) return;
            
            var command = _commands.First;
            if (command == null) return;
            
            _command--;
            
            for (var i = 0; i < _command && command?.Next != null; i++)
            {
                command = command.Next;
            }

            inputField.SetTextWithoutNotify(command.Value);
            inputField.MoveTextEnd(false);
        }
    }
}