using System.Collections.Generic;
using System.Linq;
using Game_Engine.World.RoomTypes;
using UnityEngine;
using static Constants;
using static GlobalVariables;

public class Room
{
    // Private variables
    private int _x, _y, _connectionCount;
    private RoomType _roomType;
    private Room _north, _east, _south, _west, _up, _down;
    private bool _visited, _discovered;

    // Public variables
    public Room(int x, int y)
    {
        _x = x;
        _y = y;
    }
    
    public List<NPC> NPCs;

    public string GetPhysicalFeature()
    {
        return _roomType.GetPhysicalFeature();
    }    
    
    public string GetSensoryFeature()
    {
        return _roomType.GetSensoryFeature();
    }

    public void SetRoomType(RoomType type)
    {
        _roomType = type;
    }

    public RoomType GetRoomType()
    {
        return _roomType;
    }
    
    public void SetXY(int X, int Y){
        _x = X;
        _y = Y;
    }

    public (int, int) GetXY(){
        return (_x, _y);
    }

    public bool HasConnection(int direction){
        switch (direction)
        {
            case NORTH:
                return _north != null;
            case SOUTH:
                return _south != null;
            case EAST:
                return _east != null;
            case WEST:
                return _west != null;
            case UP:
                return _up != null;
            case DOWN:
                return _down != null;
        }

        return false;
    }

    public void SetConnection(int direction, Room room){
        if (GetConnection(direction) == null) {
            switch (direction)
            {
                case NORTH:
                    _north = room;
                    _connectionCount += 1;
                    break;
                case SOUTH:
                    _south = room;
                    _connectionCount += 1;
                    break;
                case EAST:
                    _east = room;
                    _connectionCount += 1;
                    break;
                case WEST:
                    _west = room;
                    _connectionCount += 1;
                    break;
                case UP:
                    _up = room;
                    break;
                case DOWN:
                    _down = room;
                    break;
            }
        }
    }

    public Room GetConnection(int direction){
        switch (direction)
        {
            case NORTH:
                return _north;
            case SOUTH:
                return _south;
            case EAST:
                return _east;
            case WEST:
                return _west;
            case UP:
                return _up;
            case DOWN:
                return _down;
        }

        return null;
    }

    public void SetVisited(bool visited)
    {
        _visited = visited;
    }

    public bool GetVisited()
    {
        return _visited;
    }

    public void SetDiscovered(bool discovered)
    {
        _discovered = discovered;
    }

    public bool GetDiscovered()
    {
        return _discovered;
    }

    public int GetConnectionCount(){
        return _connectionCount;
    }

    public string GetTitle()
    {
        return _roomType.GetTitle();
    }

    public string GetFullDescription()
    {
        var retVal = GetPhysicalFeature() + GetSensoryFeature();
        if(GetConnectionCount() > 0){
            if(GetConnectionCount() == 1){
                retVal += "\nThere is an exit to the ";
                if(HasConnection(NORTH)){
                    retVal += "<color=#292b30><b>North</color></b>.";
                } else if (HasConnection(EAST)){
                    retVal += "<color=#292b30><b>East</color></b>.";
                } else if (HasConnection(SOUTH)){
                    retVal += "<color=#292b30><b>South</color></b>.";
                } else if (HasConnection(WEST)){
                    retVal += "<color=#292b30><b>West</color></b>.";
                }
            } else {
                retVal += "\nThere are exits to the ";
                int count = 0;
                for (int i = 0; i < MAX_HORIZONTAL_CONNECTION_COUNT; i++){
                    if(count == GetConnectionCount()-1 && HasConnection(i)){
                        if(i == NORTH){
                            retVal += "and <color=#292b30><b>North</color></b>.";
                        } else if(i == EAST){
                            retVal += "and <color=#292b30><b>East</color></b>.";
                        } else if(i == SOUTH){
                            retVal += "and <color=#292b30><b>South</color></b>.";
                        } else if(i == WEST){
                            retVal += "and <color=#292b30><b>West</color></b>. ";
                        }
                    } else if(count < GetConnectionCount()-1 && HasConnection(i)){
                        if(i == NORTH){
                            retVal += "<color=#292b30><b>North</color></b>, ";
                        } else if(i == EAST){
                            retVal += "<color=#292b30><b>East</color></b>, ";
                        } else if(i == SOUTH){
                            retVal += "<color=#292b30><b>South</color></b>, ";
                        } else if(i == WEST){
                            retVal += "<color=#292b30><b>West</color></b>, ";
                        }
                        count++;
                    }
                }
            }
        }
        if(HasConnection(DOWN) || HasConnection(UP)) retVal += "\nThere is a <color=#292b30>staircase</color> leading " + (HasConnection(DOWN) ? "<color=#292b30>further below</color>.": "<color=#292b30>up</color>.") ;

        foreach (NPC npc in NPCs)
        {
            retVal += "\n\nYou see " + npc.GetName() + " here. " + npc.GetDescription();
        };
        
        return retVal;
    }
}
    