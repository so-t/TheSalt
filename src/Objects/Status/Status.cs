using UnityEngine;

public class Status : SaltComponent
{
    //Private variables
    private SaltComponent _target;
    private int _priority;
    

    //Public variables
    protected bool Initialized = false;

    public virtual void Affect(SaltComponent target) { }

    public void SetTarget(SaltComponent target)
    {
        _target = target;
    }

    public void SetPriority(int priority)
    {
        _priority = priority;
    }

    public int GetPriority()
    {
        return _priority;
    }

    public virtual bool ShouldBeRemoved ()
    {
        return false;
    }

    //TODO Change duration implementation
    public override void Update()
    {
        Affect(_target);
    }
}