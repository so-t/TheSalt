using System;
using static Constants;
using static GlobalVariables;

namespace Game_Engine.World.RoomTypes
{
    public class Staircase : RoomType
    {
        // Private Variables
        private string _title = "A Staircase";
        
        // Public Variables

        public Staircase(Room room) : base(room)
        {
            if (Rand.Next(0, 101) <= 33)
            {
                CreateNPC();
            }
            if (Rand.Next(0, 101) <= 33)
            {
                CreatePhysicalFeature();
            }
            if (Rand.Next(0, 101) <= 33)
            {
                CreateSensoryFeature();
            }
        }

        public override string GetTitle()
        {
            return _title;
        }
    }
}