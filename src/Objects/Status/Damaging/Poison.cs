using UnityEngine;
using static GlobalVariables;

public class Poison : Status
{
    //Private Variables
    private float _tickInterval = 1.0f, _timeOfLastTick;
    private int _damage, _ticks;
    
    //Public Variables
    public void Init(SaltComponent target, int ticks, int damage)
    {
        _timeOfLastTick = Time.time;
        _ticks = ticks;
        _damage = damage;
        Target = target;
        Initialized = true;
    }

    public override bool ShouldBeRemoved()
    {
        return _ticks == 0;
    }

    public override void Update()
    {
        if (!Initialized || _ticks <= 0 || !(_timeOfLastTick + _tickInterval <= Time.time)) return;
        _timeOfLastTick = Time.time;
        _ticks -= 1;
        Target.SetHealth(Target.GetHealth() - _damage);
        if (Target == Player)
        {
            GameLog += "You take <color=#b02323>" + _damage + "</color> points of poison damage!\n";
        }

        if (ShouldBeRemoved()) 
            Destroy(this);
    }
}