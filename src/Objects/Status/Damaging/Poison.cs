using System;
using UnityEngine;
using static GlobalVariables;

public class Poison : Status
{
    //Private Variables
    private float _tickInterval = 2.0f, _timeOfLastTick;
    private int _damage, _ticks;
    
    //Public Variables
    public void Init(SaltComponent target, int ticks, int damage)
    {
        SetTarget(target);
        SetPriority((int) StatusPriorities.DAMAGE);
        _timeOfLastTick = 0.0f;
        _ticks = ticks;
        _damage = damage;
        Initialized = true;
    }

    public override bool ShouldBeRemoved()
    {
        return _ticks == 0;
    }

    public override void Affect(SaltComponent target)
    {
        if (!Initialized || _ticks <= 0 || !(_timeOfLastTick + _tickInterval <= Time.time)) return;
        _timeOfLastTick = Time.time;
        _ticks -= 1;
        target.SetHealth(target.GetHealth() - _damage);
        if (target == Player)
            GameLog += "You take <color=#b02323>" + _damage + "</color> points of poison damage!\n";
    }
}