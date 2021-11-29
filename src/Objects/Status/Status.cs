public class Status : SaltComponent
{
    //Private variables
    private int _priority;
    

    //Public variables
    protected bool Initialized = false;
    
    public virtual bool ShouldBeRemoved()
    {
        return false;
    }

    public virtual void Combine(Status s) {}

    public override void Update()
    {
    }
}