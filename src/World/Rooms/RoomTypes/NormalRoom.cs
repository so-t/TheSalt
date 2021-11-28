using static GlobalVariables;
public class NormalRoom : RoomType
{
    // Private Variables
    private string _title = "A Normal Room";
        
    // Public Variables
    public NormalRoom(Room room) : base(room)
    { 
        if (Rand.Next(0, 101) <= 33)
                CreateNPC(); 
        
        if (Rand.Next(0, 101) <= 33)
            CreatePhysicalFeature();
        
        if (Rand.Next(0, 101) <= 33)
            CreateSensoryFeature();
    }
        
        public override string GetTitle()
        {
            return _title; 
        }
}
