public class Item : SaltComponent
{
    //Private Variables
    
    //Public Variables
    public override void Defend(int damage)
    {
        SetHealth(damage >= GetHealth() ?  GetHealth() - damage : 0);
        if (GetHealth() == 0) SetIsAlive(false);
    }

}