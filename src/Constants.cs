public enum Armors
{
}

public enum ArmorClass
{
}

public enum Origins
{
    IMPERIAL,
    ORELANDER,
    OLONDIAN,
    KHAZIAN,
    MUNINIAN,
    MAGUS,
    CAELESTIANS,
    DELTENESE,
    JACKAL,
}

public enum Genders
{
    MASCULINE,
    FEMININE,
    EPICENE,
    NEUTER
}

public enum EquipmentSlots
{
    RIGHT_HAND,
    LEFT_HAND,
    BACKSTRAP
}

public enum Weapons 
{
    UNARMED,
    
    // Tier 0
    QUARTERSTAFF,
    SOLDIERS_SPEAR,
    TWIN_BLADES,
    WOODCUTTING_AXE,
    BLACKSMITHS_HAMMER,
    RAPIER,
    SCIMITAR,
    
    // Tier 1
    STONE_CLAYMORE,
    HOOKED_SPEAR,
    ADVENTURERS_SWORD,
    MORNING_STAR,
    
    // Tier 2
    FINE_BROADSWORD,
    DISC
}

public enum Maps
{
    MAP_WIDTH = 10,
    MAP_HEIGHT = 10,
    ROOM_CREATION_PROBABILITY_BASELINE = 2,
    ROOM_CONNECTION_PROBABILITY_BASELINE = 10,
    MAX_ROOM_COUNT = 25,
    MAX_HORIZONTAL_CONNECTION_COUNT = 4,
    MAX_NPC_COUNT = 4,
    MAX_FLOOR_COUNT = 5,
    MAX_CHAR_PER_MAIN_DISPLAY_LINE = 58
}

public enum Directions
{
    NORTH,
    EAST,
    SOUTH,
    WEST,
    UP,
    DOWN
}

public enum Rooms
{
    NORMAL_ROOM,
    NPC_ROOM,
    BOTANICAL_ROOM
}

public enum Arrays
{
    TATTOO_LOCATION_ARRAY_LENGTH = 16,
    PLURL_TATTOO_CUTOFF = 13,
    ORIGIN_ARRAY_LENGTH = 10,     
    GENDER_TYPES = 3,         
    ITEM_ARRAY_LENGTH = 25,          
    ITEM_LOCATION_ARRAY_LENGTH = 3,   
    PHYSICAL_FEATURE_ARRAY_LENGTH = 23,
    SENSORY_FEATURE_ARRAY_LENGTH = 10,
    SCENT_ARRAY_LENGTH = 16,
    MATERIALS_ARRAY_LENGTH = 8      
}

public enum StatusPriorities
{
    MIN = 0,
    HEALING = MIN,
    DAMAGE = 1,
    PASSIVE = MAX,
    MAX = 10
}