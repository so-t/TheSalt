using System.Diagnostics.CodeAnalysis;
using Markov;
using UnityEngine;
using Random = System.Random;

[SuppressMessage("ReSharper", "StringLiteralTypo")]
public static class GlobalVariables
{
    public static GameObject TheSalt;
    public static int PlayerOrigin, GameRegion, CurrentLevel;
    public static string GameLog;
    public static Map[] GameMap = new Map[5];
    public static readonly Random Rand = new Random();
    public static Player player;
    public static bool DoUpdateMapDisplay = true, DoUpdateLogDisplay = true, DoSetDisplayAlignmentMiddle = false, DoSetDisplayAlignmentTop = false;
    public static MarkovChain<char> NameChain = new MarkovChain<char>(3);

    public static readonly string[] Items = 
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

    public static readonly string[] ItemLocations = {
        "right hand",
        "left hand",
        "back"
    };

    public static readonly string[] TattooLocations = {
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

    public static readonly string[] Origins = 
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

    public static readonly string[] PhysicalFeatures =
    {
        "Sunlight filters in through small holes and cracks in the walls and ceiling.\n",
        "The room is small, you have to duck through the doorframe to avoid hitting your head.\n",
        "The room is large.\n",
        "The room is cavernous.\n",
        "The room is dimly lit by torchlight.\n",
        "The room has a dilapidated light fixture suspended from the ceiling, seemingly repaired by another traveler, proving a modest amount of light.\n",
        "The room is unlit.\n",
        "The room has walls covered in #colorvines</color> that creep upward in hope of finding light. They bare #colorflowers</color>.\n",
        "A short grass grows underfoot, dappled with #colorweeds</color>.\n",
        "The traces of a small fire still remain singed to the walls.\n",
        "A few animal bones rest in a pile, all picked clean.\n",
        "Indecipherable runes are carved into the walls, and staring at them too long gives you a headache.\n",
        "Diminutive salt crystals line the corners of the ceiling. they are worth nothing, but provide a bit of light by which to see.\n",
        "A few stones of varying sizes are piled up by the far wall, seemingly for no reason.\n",
        "A shattered dagger lays next to the old remains of some beast.\n",
        "The ceiling above you is domed, and #colorpainted</color>.\n",
        "There is a crack in the ceiling, and you can just barely see Peria's rings overhead.\n",
        "The walls are made of #material.\n",
        "The floors and walls are lined with #color#material</color> tiles.\n",
        "The walls are covered in #colorgraffiti</color>.\n",
        "Lined up against the walls are all manner of crates, their contents plundered long ago.\n",
        "The entire room is overgrown with #colorfoliage</color>, but not so densely that you can't navigate it.\n",
        "There's a large puddle in the center of the room, 1d6 inches deep.\n"
    };

    public static readonly string[] SensoryFeatures =
    {
        "The area is<color=#D6ECEF> frigid</color>, but you're able to bear it.\n",
        "The area is filled with warm, stagnant air.\n",
        "The area smells vaguely of #scent.\n",
        "The area smells strongly of #scent.\n",
        "It seems <color=#D6ECEF>colder</color> here.\n",
        "The air here is balmy.\n",
        "This chamber is echoey, your own voice calls out back to you.\n",
        "While here, you feel on edge.\n",
        "You cannot shake the feeling that there is someone behind you, even when there isn't.\n",
        "There is a constant scraping sound from behind the walls. You're unable to discern its origin.\n"
    };
    
    public static readonly string[] Materials =
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

    public static readonly string[] Scents =
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
