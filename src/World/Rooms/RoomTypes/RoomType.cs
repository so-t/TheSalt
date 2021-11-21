using System.Collections.Generic;
using System.Text.RegularExpressions;
using static GlobalVariables;

public abstract class RoomType
{
    // Private variables
    private string _description = "", _physicalFeature = "", _sensoryFeature = "";
    private Room _room;

    // Public Variables
    public LinkedList<SaltComponent> components = new LinkedList<SaltComponent>();

    protected RoomType(Room room)
    {
        _room = room;
    }

    protected void CreateNPC()
    {
        NPC npc = TheSalt.AddComponent<NPC>();
        npc.SetLocation(_room);
        npc.SetLocation(_room);
        components.AddFirst(npc);
        
    }

    protected void CreateSensoryFeature()
    {
        _sensoryFeature = SensoryFeatures[Rand.Next(0, (int) Arrays.SENSORY_FEATURE_ARRAY_LENGTH)];
        Regex scentRegex = new Regex("#scent");
        while (scentRegex.IsMatch(_sensoryFeature))
        {
            _sensoryFeature = scentRegex.Replace(_sensoryFeature, Scents[Rand.Next(0, (int) Arrays.SCENT_ARRAY_LENGTH)], 1);
        }

    }

    protected void CreatePhysicalFeature()
    {
        _physicalFeature = PhysicalFeatures[Rand.Next(0, (int) Arrays.PHYSICAL_FEATURE_ARRAY_LENGTH)];
        Regex materialRegex = new Regex("#material");
        Regex colorRegex = new Regex("#color");
        while (materialRegex.IsMatch(_physicalFeature))
        {
            string material = Materials[Rand.Next(0, (int) Arrays.MATERIALS_ARRAY_LENGTH)];
            _physicalFeature = materialRegex.Replace(_physicalFeature, material, 1);
        }
        while (colorRegex.IsMatch(_physicalFeature))
        {
            string color = "";
            switch (Rand.Next(0, 5))
            {
                case 0:
                    color = "<color=#7B0D1E>";
                    break;
                case 1:
                    color = "<color=#55D6BE>";
                    break;
                case 2:
                    color = "<color=#8C5E58>";
                    break;
                case 3:
                    color = "<color=#ABC8C7>";
                    break;
                case 4:
                    color = "<color=#4B2142>";
                    break;
                
            }
            _physicalFeature = colorRegex.Replace(_physicalFeature, color, 1);
        }
        
    }

    public void SetDescription(string description)
    {
        _description = description;
    }
    
    public virtual string GetDescription()
    {
        return _description;
    }

    public virtual string GetPhysicalFeature()
    {
        return _physicalFeature;
    }

    public virtual string GetSensoryFeature()
    {
        return _sensoryFeature;
    }

    public abstract string GetTitle();

}