﻿using UnityEngine;
using static GlobalVariables;

public class GameSetup : MonoBehaviour
{
    // Private variables

    // Public variables
    public TextAsset nameBases;
    
    // Start is called before the first frame update
    void Start()
    {
        TheSalt = new GameObject();
        Player = TheSalt.AddComponent<Character>();
        names = nameBases.ToString().Split(',','\n');
        WorldBuilder builder = new WorldBuilder();
        GameMap = builder.CreateMap();
        CurrentLevel = 0;
        string title = "--- < " + CurrentRoom.GetTitle() + " >";
        GameLog = "<color=#292b30>---<</color> " + CurrentRoom.GetTitle() + " <color=#292b30>>";
        for (int x = title.Length; x < (int) Maps.MAX_CHAR_PER_MAIN_DISPLAY_LINE; x++)
        {
            GameLog += "-";
        }
        GameLog += "</color>\n" + CurrentRoom.GetDescription();

    }
}
