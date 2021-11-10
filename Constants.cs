
// ReSharper disable InconsistentNaming

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
    QUARTERSTAFF,
    SOLDIERS_SPEAR,
    WOODCUTTING_AXE,
    BLACKSMITHS_HAMMER,
    UNARMED
}

public enum WeaponDamages
{
    QUARTERSTAFF = 3,
    SOLDIERS_SPEAR = 8,
    BLACKSMITHS_HAMMER = 3,
    WOODCUTTING_AXE = 6,
    UNARMED = 3
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
    MAX_CHAR_PER_MAIN_DISPLAY_LINE = 58;
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
    GENDER_ARRAY_LENGTH = 3,         
    ITEM_ARRAY_LENGTH = 25,          
    ITEM_LOCATION_ARRAY_LENGTH = 3,   
    PHYSICAL_FEATURE_ARRAY_LENGTH = 23,
    SENSORY_FEATURE_ARRAY_LENGTH = 10,
    SCENT_ARRAY_LENGTH = 16,
    MATERIALS_ARRAY_LENGTH = 8,      
}