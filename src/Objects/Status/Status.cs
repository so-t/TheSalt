public class Status : SaltComponent
{
    //Private variables
    private int _priority;
    

    //Public variables
    protected SaltComponent Target;
    protected bool Initialized = false;
    
    public virtual bool ShouldBeRemoved ()
    {
        return false;
    }

    public override void Update()
    {
    }
}