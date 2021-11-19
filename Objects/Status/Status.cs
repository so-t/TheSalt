using UnityEngine;

public class Status : SaltGameObject
{
    //Private variables
    private SaltGameObject _target;
    private int _priority;
    

    //Public variables
    public virtual void Affect(SaltGameObject target) { }

    public void SetTarget(SaltGameObject target)
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