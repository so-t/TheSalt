using System;
using UnityEngine;
using static GlobalVariables;

public class Poison : Status
{
    //Private Variables
    private readonly int _damage;
    
    //Public Variables
    public Poison(SaltGameObject target, float duration, int damage)
    {
        SetTarget(target);
        SetDuration(Time.time + duration);
        SetPriority((int) StatusPriorities.DAMAGE);
        _damage = damage;
    }

    public override bool ShouldBeRemoved()
    {
        return GetDuration() < Time.time;
    }

    public override void Affect(SaltGameObject target)
    {
        target.SetHealth(target.GetHealth() -_damage);
        if (target == Player)
            GameLog += "You take <color=#b02323>" + _damage + "</color> points of poison damage!\n";
    }
}