using static Constants;

public class Map
{
    // Private variables
    private Room[,] _rooms  = new Room[MAP_WIDTH,MAP_HEIGHT];
    private int _roomCount;

    // Public variables
    public void SetRoom(Room room, int x, int y){
        _rooms[x,y] = room;
    }

    public Room GetRoom(int x, int y){
        return _rooms[x,y];
    }

    public void IncrementRoomCount(){
        _roomCount++;
    }

    public int GetRoomCount(){
        return _roomCount;
    }

    public Room[,] GetRoomList()
    {
        return _rooms;
    }
}