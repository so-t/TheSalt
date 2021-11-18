using UnityEngine;

public class Status : SaltGameObject
{
    //Private variables
    private SaltGameObject _target;
    private float _duration;
    private int _priority;
    

    //Public variables
    public virtual void Affect(SaltGameObject target)
    {
    }
    
    public virtual void AdjustDuration()
    {
    }

    public void SetTarget(SaltGameObject target)
    {
        _target = target;
    }

    public void SetDuration(float duration)
    {
        _duration = duration;
    }

    public float GetDuration()
    {
        return _duration;
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

    public override void Update()
    {
        Affect(_target);
        AdjustDuration();
    }
}