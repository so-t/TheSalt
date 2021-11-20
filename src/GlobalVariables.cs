using UnityEngine;
using Random = System.Random;

public static class GlobalVariables
{
    public static GameObject TheSalt;
    public static int PlayerOrigin, GameRegion, CurrentLevel;
    public static string GameLog;
    public static Map[] GameMap = new Map[5];
    public static Room CurrentRoom = null;
    public static Random Rand = new Random();
    public static Character Player;
    public static bool DoUpdateMapDisplay = true, DoUpdateLogDisplay = true, DoSetDisplayAlignmentMiddle = false, DoSetDisplayAlignmentTop = false;

    public static string[] items = 
    {
        "quarterstaff",
        "soldier's spear",
        "woodcutting axe",
        "blacksmith's hammer",
        "small lantern",
        "large lantern",
        "rapier",
        "scimitar",
        "stone claymore",
        "hooked spear",
        "adventurer's sword",
        "morning star",
        "fine broadsword",
        "disc",
        "gatherer’s basket",
        "salt flute",
        "cage containing a small rodent",
        "bundle of driftwood",
        "large jug",
        "portable greenhouse",
        "coil of sturdy looking rope",
        "pickaxe",
        "small tree",
        "bottle, with liquid sloshing loudly inside,",
        "orb"
    };

    public static string[] itemLocations = {
        "right hand",
        "left hand",
        "back"
    };

    public static string[] tattooLocations = {
        "left arm",
        "right arm", 
        "left leg", 
        "right leg", 
        "tongue", 
        "left eye", 
        "right eye",
        "neck", 
        "face", 
        "forehead", 
        "head", 
        "back",
        "chest", 
        "arms", 
        "eyes", 
        "legs"
    };

    public static string[] origins = 
    {
        "Imperial",
        "Orelander",
        "Elharan",
        "Olondian",
        "Khazian",
        "Myninian",
        "Magus",
        "Caelesti",
        "Delrenese",
        "the Jackals"
    };

    public static string[] physicalFeatures =
    {
        "\nSunlight filters in through small holes and cracks in the walls and ceiling.\n",
        "\nThe room is small, you have to duck through the doorframe to avoid hitting your head.\n",
        "\nThe room is large.\n",
        "\nThe room is cavernous.\n",
        "\nThe room is dimly lit by torchlight.\n",
        "\nThe room has a dilapidated light fixture suspended from the ceiling, seemingly repaired by another traveler, proving a modest amount of light.\n",
        "\nThe room is unlit.\n",
        "\nThe room has walls covered in #colorvines</color> that creep upward in hope of finding light. They bare #colorflowers</color>.\n",
        "\nA short grass grows underfoot, dappled with #colorweeds</color>.\n",
        "\nThe traces of a small fire still remain singed to the walls.\n",
        "\nA few animal bones rest in a pile, all picked clean.\n",
        "\nIndecipherable runes are carved into the walls, and staring at them too long gives you a headache.\n",
        "\nDiminutive salt crystals line the corners of the ceiling. they are worth nothing, but provide a bit of light by which to see.\n",
        "\nA few stones of varying sizes are piled up by the far wall, seemingly for no reason.\n",
        "\nA shattered dagger lays next to the old remains of some beast.\n",
        "\nThe ceiling above you is domed, and #colorpainted</color>.\n",
        "\nThere is a crack in the ceiling, and you can just barely see Peria's rings overhead.\n",
        "\nThe walls are made of #material.\n",
        "\nThe floors and walls are lined with #color#material</color> tiles.\n",
        "\nThe walls are covered in #colorgraffiti</color>.\n",
        "\nLined up against the walls are all manner of crates, their contents plundered long ago.\n",
        "\nThe entire room is overgrown with #colorfoliage</color>, but not so densely that you can't navigate it.\n",
        "\nThere's a large puddle in the center of the room, 1d6 inches deep.\n"
    };

    public static string[] sensoryFeatures =
    {
        "\nThe area is<color=#D6ECEF> frigid</color>, but you're able to bear it.\n",
        "\nThe area is filled with warm, stagnant air.\n",
        "\nThe area smells vaguely of #scent.\n",
        "\nThe area smells strongly of #scent.\n",
        "\nIt seems <color=#D6ECEF>colder</color> here.\n",
        "\nThe air here is balmy.\n",
        "\nThis chamber is echoey, your own voice calls out back to you.\n",
        "\nWhile here, you feel on edge.\n",
        "\nYou cannot shake the feeling that there is someone behind you, even when there isn't.\n",
        "\nThere is a constant scraping sound from behind the walls. You're unable to discern its origin.\n"
    };
    
    public static string[] materials =
    {
        "iron",
        "some sort of strange metal",
        "wood",
        "smoothed stone",
        "engraved stone",
        "marble",
        "granite",
        "#colorglass</color>"
        
    };

    public static string[] scents =
    {
        "fish",
        "ash",
        "charred wood",
        "citrus",
        "fruit",
        "chemicals",
        "mint",
        "rotting meat",
        "a floral perfume",
        "vanilla",
        "vinegar",
        "spice",
        "smoke",
        "tobacco smoke",
        "lilac",
        "peach"
    };

    public static string[] names;
}
