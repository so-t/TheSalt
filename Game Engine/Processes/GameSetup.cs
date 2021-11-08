using System;
using System.Linq;
using UnityEditor;
using UnityEngine;
using static GlobalVariables;
using static Constants;
[CLSCompliant(false)]

public class GameSetup : MonoBehaviour
{
    // Private variables
    
    // Public variables
    public TextAsset nameBases;
    
    // Start is called before the first frame update
    void Start()
    {
        Player = new Character();
        names = nameBases.ToString().Split(',','\n');
        WorldBuilder builder = new WorldBuilder();
        GameMap = builder.CreateMap();
        CurrentLevel = 0;
        string title = "--- < " + CurrentRoom.GetTitle() + " >";
        GameLog = "<color=#292b30>---<</color> " + CurrentRoom.GetTitle() + " <color=#292b30>>";
        for (int x = title.Length; x < MAX_CHAR_PER_MAIN_DISPLAY_LINE; x++)
        {
            GameLog += "-";
        }
        GameLog += "</color>\n" + CurrentRoom.GetFullDescription();

    }

    // Update is called once per frame
    void Update()
    {
        foreach (var map in GameMap)
        {
            if (map != null)
            {
                foreach (var room in map.GetRoomList())
                {
                    if (room != null)
                    {
                        foreach (var npc in room.NPCs.ToList())
                        {
                            if (npc != null) npc.Update();
                        }
                    }
                }
            }
        }
    }
}
