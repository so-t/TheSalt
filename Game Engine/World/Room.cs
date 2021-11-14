using System.Collections.Generic;
using Game_Engine.World.RoomTypes;

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
            case (int) Directions.NORTH:
                return _north != null;
            case (int) Directions.SOUTH:
                return _south != null;
            case (int) Directions.EAST:
                return _east != null;
            case (int) Directions.WEST:
                return _west != null;
            case (int) Directions.UP:
                return _up != null;
            case (int) Directions.DOWN:
                return _down != null;
        }

        return false;
    }

    public void SetConnection(int direction, Room room){
        if (GetConnection(direction) == null) {
            switch (direction)
            {
                case (int) Directions.NORTH:
                    _north = room;
                    _connectionCount += 1;
                    break;
                case (int) Directions.SOUTH:
                    _south = room;
                    _connectionCount += 1;
                    break;
                case (int) Directions.EAST:
                    _east = room;
                    _connectionCount += 1;
                    break;
                case (int) Directions.WEST:
                    _west = room;
                    _connectionCount += 1;
                    break;
                case (int) Directions.UP:
                    _up = room;
                    break;
                case (int) Directions.DOWN:
                    _down = room;
                    break;
            }
        }
    }

    public Room GetConnection(int direction){
        switch (direction)
        {
            case (int) Directions.NORTH:
                return _north;
            case (int) Directions.SOUTH:
                return _south;
            case (int) Directions.EAST:
                return _east;
            case (int) Directions.WEST:
                return _west;
            case (int) Directions.UP:
                return _up;
            case (int) Directions.DOWN:
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
                if(HasConnection((int) Directions.NORTH)){
                    retVal += "<color=#292b30><b>North</color></b>.";
                } else if (HasConnection((int) Directions.EAST)){
                    retVal += "<color=#292b30><b>East</color></b>.";
                } else if (HasConnection((int) Directions.SOUTH)){
                    retVal += "<color=#292b30><b>South</color></b>.";
                } else if (HasConnection((int) Directions.WEST)){
                    retVal += "<color=#292b30><b>West</color></b>.";
                }
            } else {
                retVal += "\nThere are exits to the ";
                int count = 0;
                for (int i = 0; i < (int) Maps.MAX_HORIZONTAL_CONNECTION_COUNT; i++){
                    if(count == GetConnectionCount()-1 && HasConnection(i)){
                        if(i == (int) Directions.NORTH){
                            retVal += "and <color=#292b30><b>North</color></b>.";
                        } else if(i == (int) Directions.EAST){
                            retVal += "and <color=#292b30><b>East</color></b>.";
                        } else if(i == (int) Directions.SOUTH){
                            retVal += "and <color=#292b30><b>South</color></b>.";
                        } else if(i == (int) Directions.WEST){
                            retVal += "and <color=#292b30><b>West</color></b>. ";
                        }
                    } else if(count < GetConnectionCount()-1 && HasConnection(i)){
                        if(i == (int) Directions.NORTH){
                            retVal += "<color=#292b30><b>North</color></b>, ";
                        } else if(i == (int) Directions.EAST){
                            retVal += "<color=#292b30><b>East</color></b>, ";
                        } else if(i == (int) Directions.SOUTH){
                            retVal += "<color=#292b30><b>South</color></b>, ";
                        } else if(i == (int) Directions.WEST){
                            retVal += "<color=#292b30><b>West</color></b>, ";
                        }
                        count++;
                    }
                }
            }
        }
        if(HasConnection((int) Directions.DOWN) || HasConnection((int) Directions.UP)) retVal += "\nThere is a <color=#292b30>staircase</color> leading " + (HasConnection((int) Directions.DOWN) ? "<color=#292b30>further below</color>.": "<color=#292b30>up</color>.") ;

        foreach (NPC npc in NPCs)
        {
            retVal += "\n\nYou see " + npc.GetName() + " here. " + npc.GetDescription();
        };
        
        return retVal;
    }
}
    