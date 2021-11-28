using static GlobalVariables;

public class Antidote : Consumable
{
    // Private Variables
    
    // Public Variables
    public override void Awake()
    {
        SetName("Antidote");
        SetDescription("An antidote.");
    }
    
    public override void Use(SaltComponent target)
    {
        target.RemoveStatus(typeof(Poison));
        GameLog += "You remove the cap from the bottle of antidote and drink...";
    }
}