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
            case Directions.NORTH:
                return _north != null;
            case Directions.SOUTH:
                return _south != null;
            case Directions.EAST:
                return _east != null;
            case Directions.WEST:
                return _west != null;
            case Directions.UP:
                return _up != null;
            case Directions.DOWN:
                return _down != null;
        }

        return false;
    }

    public void SetConnection(int direction, Room room){
        if (GetConnection(direction) == null) {
            switch (direction)
            {
                case Directions.NORTH:
                    _north = room;
                    _connectionCount += 1;
                    break;
                case Directions.SOUTH:
                    _south = room;
                    _connectionCount += 1;
                    break;
                case Directions.EAST:
                    _east = room;
                    _connectionCount += 1;
                    break;
                case Directions.WEST:
                    _west = room;
                    _connectionCount += 1;
                    break;
                case Directions.UP:
                    _up = room;
                    break;
                case Directions.DOWN:
                    _down = room;
                    break;
            }
        }
    }

    public Room GetConnection(int direction){
        switch (direction)
        {
            case Directions.NORTH:
                return _north;
            case Directions.SOUTH:
                return _south;
            case Directions.EAST:
                return _east;
            case Directions.WEST:
                return _west;
            case Directions.UP:
                return _up;
            case Directions.DOWN:
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
                if(HasConnection(Directions.NORTH)){
                    retVal += "<color=#292b30><b>North</color></b>.";
                } else if (HasConnection(Directions.EAST)){
                    retVal += "<color=#292b30><b>East</color></b>.";
                } else if (HasConnection(Directions.SOUTH)){
                    retVal += "<color=#292b30><b>South</color></b>.";
                } else if (HasConnection(Directions.WEST)){
                    retVal += "<color=#292b30><b>West</color></b>.";
                }
            } else {
                retVal += "\nThere are exits to the ";
                int count = 0;
                for (int i = 0; i < MAX_HORIZONTAL_CONNECTION_COUNT; i++){
                    if(count == GetConnectionCount()-1 && HasConnection(i)){
                        if(i == Directions.NORTH){
                            retVal += "and <color=#292b30><b>North</color></b>.";
                        } else if(i == Directions.EAST){
                            retVal += "and <color=#292b30><b>East</color></b>.";
                        } else if(i == Directions.SOUTH){
                            retVal += "and <color=#292b30><b>South</color></b>.";
                        } else if(i == Directions.WEST){
                            retVal += "and <color=#292b30><b>West</color></b>. ";
                        }
                    } else if(count < GetConnectionCount()-1 && HasConnection(i)){
                        if(i == Directions.NORTH){
                            retVal += "<color=#292b30><b>North</color></b>, ";
                        } else if(i == Directions.EAST){
                            retVal += "<color=#292b30><b>East</color></b>, ";
                        } else if(i == Directions.SOUTH){
                            retVal += "<color=#292b30><b>South</color></b>, ";
                        } else if(i == Directions.WEST){
                            retVal += "<color=#292b30><b>West</color></b>, ";
                        }
                        count++;
                    }
                }
            }
        }
        if(HasConnection(Directions.DOWN) || HasConnection(Directions.UP)) retVal += "\nThere is a <color=#292b30>staircase</color> leading " + (HasConnection(Directions.DOWN) ? "<color=#292b30>further below</color>.": "<color=#292b30>up</color>.") ;

        foreach (NPC npc in NPCs)
        {
            retVal += "\n\nYou see " + npc.GetName() + " here. " + npc.GetDescription();
        };
        
        return retVal;
    }
}
    