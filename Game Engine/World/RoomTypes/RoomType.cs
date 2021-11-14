using System.Collections.Generic;
using System.Linq;
using System.Text.RegularExpressions;
using static GlobalVariables;
namespace Game_Engine.World.RoomTypes
{
    public abstract class RoomType
    {
        // Private variables
        private string _description = "", _physicalFeature = "", _sensoryFeature = "";
        private Room _room;

        // Public Variables
        public List<NPC> NPCs = new List<NPC>();

        public RoomType(Room room)
        {
            _room = room;
        }
        
        public void CreateNPC()
        {
            NPC npc = new NPC();
            npc.SetCurrentRoom(_room);
            NPCs = NPCs.Prepend(npc).ToList();
            
        }

        public void CreateSensoryFeature()
        {
            _sensoryFeature = sensoryFeatures[Rand.Next(0, (int) Arrays.SENSORY_FEATURE_ARRAY_LENGTH)];
            Regex scentRegex = new Regex("#scent");
            while (scentRegex.IsMatch(_sensoryFeature))
            {
                _sensoryFeature = scentRegex.Replace(_sensoryFeature, scents[Rand.Next(0, (int) Arrays.SCENT_ARRAY_LENGTH)], 1);
            }

        }

        public void CreatePhysicalFeature()
        {
            _physicalFeature = physicalFeatures[Rand.Next(0, (int) Arrays.PHYSICAL_FEATURE_ARRAY_LENGTH)];
            Regex materialRegex = new Regex("#material");
            Regex colorRegex = new Regex("#color");
            while (materialRegex.IsMatch(_physicalFeature))
            {
                string material = materials[Rand.Next(0, (int) Arrays.MATERIALS_ARRAY_LENGTH)];
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
}