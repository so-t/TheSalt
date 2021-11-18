using System;
using System.Linq;
using System.Net.Http.Headers;
using System.Text.RegularExpressions;
using TMPro;
using UnityEngine;
using static GlobalVariables;


public class MainInputParsing : MonoBehaviour
{
    public TMP_InputField inputField;
    public TMP_Text display;
    
    // Start is called before the first frame update
    void Start()
    {
        inputField = gameObject.GetComponent<TMP_InputField>();
        var submit = new TMP_InputField.SubmitEvent();
        submit.AddListener(Submit);
        inputField.onEndEdit = submit;
        inputField.ActivateInputField();
    }
    
    void MovePlayer(int direction){
        if(CurrentRoom.HasConnection(direction)){
            if (direction == (int) Directions.DOWN)
            {
                CurrentLevel += 1;
            }

            if (direction == (int) Directions.UP)
            {
                CurrentLevel -= 1;
            }
            CurrentRoom = CurrentRoom.GetConnection(direction);
            if (!CurrentRoom.GetVisited())
            {
                CurrentRoom.SetVisited(true);
                for (int dir = (int) Directions.NORTH; dir < 4; dir++)
                {
                    if (CurrentRoom.GetConnection(dir) != null && !CurrentRoom.GetConnection(dir).GetDiscovered())
                    {
                        CurrentRoom.GetConnection(dir).SetDiscovered(true);
                    }
                }
            }
            
            // <color=#292b30>---<</color> A Normal Room <color=#292b30>>--------------------------------------</color>

            string title = "---< " + CurrentRoom.GetTitle() + " >";
            GameLog = "<color=#292b30>---<</color> " + CurrentRoom.GetTitle() + " <color=#292b30>>";
            for (int x = title.Length; x < (int) Maps.MAX_CHAR_PER_MAIN_DISPLAY_LINE; x++)
            {
                GameLog += "-";
            }
            GameLog += "</color>\n" + CurrentRoom.GetFullDescription();
        } else {
            GameLog += "There is no path in that direction!";
        }
    }
    
    void ParseInput(string input){
        var message = "\n";

        // Inputting "quit" will return false from this fxn, which causes the loop in main.cpp to end, thus exiting the game
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
                MovePlayer((int) Directions.NORTH);
                DoUpdateMapDisplay = true;
                DoUpdateLogDisplay = true;
            } else if (Regex.IsMatch(input, "[Ee]ast$"))
            {
                MovePlayer((int) Directions.EAST);
                DoUpdateMapDisplay = true;
                DoUpdateLogDisplay = true;
            } else if (Regex.IsMatch(input, "[Ww]est$"))
            {
                MovePlayer((int)  Directions.WEST);
                DoUpdateMapDisplay = true;
                DoUpdateLogDisplay = true;
            } else if (Regex.IsMatch(input, "[Ss]outh$"))
            {
                MovePlayer((int) Directions.SOUTH);
                DoUpdateMapDisplay = true;
                DoUpdateLogDisplay = true;
            } else if (Regex.IsMatch(input, "[Dd]own$"))
            {
                MovePlayer((int) Directions.DOWN);
                DoUpdateMapDisplay = true;
                DoUpdateLogDisplay = true;
            } else if (Regex.IsMatch(input, "[Uu]p$"))
            {
                MovePlayer((int) Directions.UP);
                DoUpdateMapDisplay = true;
                DoUpdateLogDisplay = true;
            }else {
                message += "Move where?";
            }
        }
        // Inputs starting with "Look" handled here
        // "Look" on it's own will display the full description of the current room.
        // "Look" followed by "map" will display a visual printout of all rooms and their connections (This is aceived by calling "printMap()").
        else if(Regex.IsMatch(input, "^[Ll]ook")){
            if(Regex.IsMatch(input, "^[Ll]ook(&|[Aa]round|(.*)[Rr]oom)*$")){
                message += CurrentRoom.GetFullDescription();
            }
        }

        // Inputs starting with "Attack" handled here
        else if (Regex.IsMatch(input, "^[Aa]ttack")){
            if(Regex.IsMatch(input, "^[Aa]ttack$")){
                message += "Attack what?";
            }
            else if(Regex.IsMatch(input, " (.*)$")){
                bool attacked = false;
                // Make a copy of the user-entered target and set to lowercase
                string target = input;
                target = input.Split(' ').Last().ToLower();
                // For each NPC in the room, we check if the name, set to lowercase, matches the input target.
                foreach (SaltGameObject obj in CurrentRoom.Objects){
                    if(obj.GetName().ToLower() == target){
                        if(obj.GetIsAlive()){
                            message += "You attack " + obj.GetName() + " for " + Player.Attack(obj) + " points of damage" + (obj.GetIsAlive() ? "!" : ", finishing " + obj.GetThirdPersonObjective() + "!");
                            attacked = true;
                            if(obj.GetWeapon() != null && obj.GetIsAlive()){
                                message += "\n" + obj.GetName() + " attacks you for " + obj.Attack(Player) + " points of damage!";
                            }
                        } else {
                            message += obj.GetName() + " is already dead.";
                            attacked = true;
                        }
                    }
                }
                if(!attacked) message += "Attack what?";
            }
        }
        GameLog += message;
    }

    private void Submit(string str)
    {
        ParseInput(str);
        inputField.SetTextWithoutNotify("");
        inputField.ActivateInputField();

    }

    // Update is called once per frame
    void Update()
    {
        
    }
}