using System.Collections.Generic;
using System.Linq;
using Game_Engine.World.RoomTypes;
using Unity.Mathematics;
using UnityEngine;
using static Constants;
using static GlobalVariables;

public class WorldBuilder
{
       // Private variables
       private List<Room> _rooms = new List<Room>();

       // Public variablesHandlerDrawMiniMapHandler
       public void GenerateRoom(Map map, int x, int y)
       {
           // probabilityMod is used to adjust the chances of certain conditionals over the life of this method
           var probabilityMod = 0;
           
           // Create target room
           if(map.GetRoom(x,y) == null)
           {
               Room room = new Room(x,y);
               _rooms.Add(room);
               map.SetRoom(room, x, y);
               map.IncrementRoomCount();
           }

           // Create connections between target room and neighbors
           // This process loops until at least one connection is made between this room and it's neighbors
           while(map.GetRoom(x,y).GetConnectionCount() <= 4 && probabilityMod <= 120 - Maps.ROOM_CONNECTION_PROBABILITY_BASELINE){
               if(y+1 < Maps.MAP_HEIGHT && map.GetRoom(x,y+1) != null && !map.GetRoom(x,y).HasConnection(Directions.NORTH)){
                   if(x == Maps.MAP_WIDTH/2-1 && y+1 == Maps.MAP_HEIGHT/2-1){
                       if(map.GetRoom(x, y+1).GetConnectionCount() == 0){
                           map.GetRoom(x, y).SetConnection(Directions.NORTH, map.GetRoom(x, y+1));
                           map.GetRoom(x, y+1).SetConnection(Directions.SOUTH, map.GetRoom(x,y));
                       }
                   } else if(Rand.Next(0,101) - probabilityMod < Maps.ROOM_CONNECTION_PROBABILITY_BASELINE){
                       map.GetRoom(x, y).SetConnection(Directions.NORTH, map.GetRoom(x, y+1));
                       map.GetRoom(x, y+1).SetConnection(Directions.SOUTH, map.GetRoom(x, y));
                   }
               }
               if(x+1 < MAP_WIDTH && map.GetRoom(x+1, y) != null  && !map.GetRoom(x,y).HasConnection(Directions.EAST)){
                   if(x+1 == Maps.MAP_WIDTH/2-1 && y == Maps.MAP_HEIGHT/2-1){
                       if(map.GetRoom(x+1, y).GetConnectionCount() == 0){
                           map.GetRoom(x, y).SetConnection(Directions.EAST, map.GetRoom(x+1, y));
                           map.GetRoom(x+1, y).SetConnection(Directions.WEST, map.GetRoom(x, y));
                       }
                   } else if(Rand.Next(0,101) - probabilityMod < Maps.ROOM_CONNECTION_PROBABILITY_BASELINE){
                       map.GetRoom(x, y).SetConnection(Directions.EAST, map.GetRoom(x+1, y));
                       map.GetRoom(x+1, y).SetConnection(Directions.WEST, map.GetRoom(x, y));
                   }
               }
               if(y-1 >= 0 && map.GetRoom(x, y-1) != null && !map.GetRoom(x,y).HasConnection(Directions.SOUTH)){
                   if(x == Maps.MAP_WIDTH/2-1 && y-1 == Maps.MAP_HEIGHT/2-1){
                       if(map.GetRoom(x, y-1).GetConnectionCount() == 0){
                           map.GetRoom(x, y).SetConnection(Directions.SOUTH, map.GetRoom(x, y-1));
                           map.GetRoom(x, y-1).SetConnection(Directions.NORTH, map.GetRoom(x, y));
                       }
                   } else if(Rand.Next(0,101) - probabilityMod < Maps.ROOM_CONNECTION_PROBABILITY_BASELINE){
                       map.GetRoom(x, y).SetConnection(Directions.SOUTH, map.GetRoom(x, y-1));
                       map.GetRoom(x, y-1).SetConnection(Directions.NORTH, map.GetRoom(x, y));
                   }
               }
               if(x-1 >= 0 && map.GetRoom(x-1, y) != null && !map.GetRoom(x,y).HasConnection(Directions.WEST)){
                   if(x-1 == Maps.MAP_WIDTH/2-1 && y == Maps.MAP_HEIGHT/2-1){
                       if(map.GetRoom(x-1, y).GetConnectionCount() == 0){
                           map.GetRoom(x, y).SetConnection(Directions.WEST, map.GetRoom(x-1, y));
                           map.GetRoom(x-1, y).SetConnection(Directions.EAST, map.GetRoom(x, y));
                       }
                   } else if(Rand.Next(0,101) - probabilityMod < Maps.ROOM_CONNECTION_PROBABILITY_BASELINE){
                       map.GetRoom(x, y).SetConnection(Directions.WEST, map.GetRoom(x-1, y));
                       map.GetRoom(x-1, y).SetConnection(Directions.EAST, map.GetRoom(x, y));
                   }
               }
               probabilityMod += 1;
           }

           // Reset probabilityMod for use in the next steps
           probabilityMod = 0;

           // Generate neighbor rooms
           // neighborCount is used to keep track of how many neighboring rooms are generated over the life of this method
           int neighborCount = 0;
           while(neighborCount <= 4 && map.GetRoomCount() < Maps.MAX_ROOM_COUNT && probabilityMod <= 100 - Maps.ROOM_CREATION_PROBABILITY_BASELINE){
               switch(Rand.Next(0,4)){
                   case Directions.NORTH:
                       if(y+1 < Maps.MAP_HEIGHT){
                           if(map.GetRoom(x, y+1) == null && Rand.Next(0,101) - probabilityMod < Maps.ROOM_CREATION_PROBABILITY_BASELINE){
                               GenerateRoom(map, x, y+1);
                               map.GetRoom(x, y).SetConnection(Directions.NORTH, map.GetRoom(x, y+1));
                               map.GetRoom(x, y+1).SetConnection(Directions.SOUTH, map.GetRoom(x, y));
                               neighborCount++;
                           }
                       }
                       break;
                   case Directions.EAST:
                       if(x+1 < Maps.MAP_WIDTH){
                           if(map.GetRoom(x+1, y) == null && Rand.Next(0,101) - probabilityMod < Maps.ROOM_CREATION_PROBABILITY_BASELINE){
                               GenerateRoom(map, x+1, y);
                               map.GetRoom(x, y).SetConnection(Directions.EAST, map.GetRoom(x+1, y));
                               map.GetRoom(x+1, y).SetConnection(Directions.WEST, map.GetRoom(x, y));
                               neighborCount++;
                           }
                       }
                       break;
                   case Directions.SOUTH:
                       if(y-1 >= 0){
                           if(map.GetRoom(x, y-1) == null && Rand.Next(0,101) - probabilityMod < Maps.ROOM_CREATION_PROBABILITY_BASELINE){
                               GenerateRoom(map, x, y-1);
                               map.GetRoom(x, y).SetConnection(Directions.SOUTH, map.GetRoom(x, y-1));
                               map.GetRoom(x, y-1).SetConnection(Directions.NORTH, map.GetRoom(x, y));
                               neighborCount++;
                           }
                       }
                       break;
                   case Directions.WEST:
                       if(x-1 >= 0){
                           if(map.GetRoom(x-1, y) == null && Rand.Next(0,101) - probabilityMod < Maps.ROOM_CREATION_PROBABILITY_BASELINE){
                               GenerateRoom(map, x-1, y);
                               map.GetRoom(x, y).SetConnection(Directions.WEST, map.GetRoom(x-1, y));
                               map.GetRoom(x-1, y).SetConnection(Directions.EAST, map.GetRoom(x, y));
                               neighborCount++;
                           }
                       }
                       break;
               }
               // Adjust probabilityMod for next loop
               probabilityMod += 5;
           }
       }

       public Room GetFurthestRoom(Map map, int x, int y)
       {
           Room room = null;
           Queue<Room> toVisit = new Queue<Room>();
           toVisit.Enqueue(map.GetRoom(x, y));
           while (toVisit.Count != 0)
           {
               room = toVisit.Dequeue();
               room.SetVisited(true);
               for (int dir = Directions.NORTH; dir < 4; dir++)
               {
                   if (room.HasConnection(dir) && !room.GetConnection(dir).GetVisited())
                   {
                       toVisit.Enqueue(room.GetConnection(dir));
                   }
               }
           }

           return room;
       } 
       
       public Map[] CreateMap()
       {
           Map[] maps = new Map[Maps.MAX_FLOOR_COUNT];
           var floorCount = 0;
           var x = MAP_WIDTH / 2 - 1;
           var y = MAP_HEIGHT / 2 - 1;
           while(floorCount < Maps.MAX_FLOOR_COUNT)
           {
               MonoBehaviour.print(floorCount);
               maps[floorCount] = new Map();
               
               while (maps[floorCount].GetRoomCount() < Maps.MAX_ROOM_COUNT)
               {
                   GenerateRoom(maps[floorCount], x, y);
               }
               
               if (floorCount > 0) 
               {
                   maps[floorCount].GetRoom(x,y).SetRoomType(new Staircase(maps[floorCount].GetRoom(x,y)));
                   maps[floorCount-1].GetRoom(x,y).SetConnection(Directions.DOWN, maps[floorCount].GetRoom(x,y));
                   maps[floorCount].GetRoom(x,y).SetConnection(Directions.UP, maps[floorCount-1].GetRoom(x,y));
               }
               
               if (floorCount < MAX_FLOOR_COUNT-1)
               {
                   var furthestRoom = GetFurthestRoom(maps[floorCount], x, y);
                   furthestRoom.SetRoomType(new Staircase(furthestRoom));
                   x = furthestRoom.GetXY().Item1;
                   y = furthestRoom.GetXY().Item2;
               }
               floorCount++;
           }
               
           _rooms.ForEach(room =>
           {
               if (room.GetRoomType() == null)
               {
                   room.SetRoomType(new NormalRoom(room));
               }

               room.SetVisited(false);
               room.NPCs = room.GetRoomType().NPCs;
           });

           CurrentRoom = maps[0].GetRoom(Maps.MAP_WIDTH / 2 - 1, Maps.MAP_HEIGHT / 2 - 1);
           CurrentRoom.SetVisited(true);
           for (int dir = Directions.NORTH; dir < 5; dir++)
           {
               if (CurrentRoom.GetConnection(dir) != null)
               {
                   CurrentRoom.GetConnection(dir).SetDiscovered(true);
               }
           }
           return maps;
       }
}