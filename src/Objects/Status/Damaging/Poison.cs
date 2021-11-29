using UnityEngine;
using static GlobalVariables;

public class Poison : Status
{
    //Private Variables
    private const float TickInterval = 10.0f;
    private float _timeOfLastTick;
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

    public override void Combine(Status s)
    {
        _damage += ((Poison) s)._damage;
        _ticks += ((Poison) s)._ticks;
        Destroy(s);
    }

    public override bool ShouldBeRemoved()
    {
        return _ticks == 0;
    }

    public override void Update()
    {
        if (ShouldBeRemoved())
        {
            Target.RemoveStatus(GetType());
            Destroy(this);
        }
        
        if (!Initialized || !(_timeOfLastTick + TickInterval <= Time.time)) return;
        
        _timeOfLastTick = Time.time;
        _ticks -= 1;
        Target.SetHealth(Target.GetHealth() - _damage);
        
        if (Target == player)
            GameLog += "You take <color=#b02323>" + _damage + "</color> points of poison damage!\n";
    }
}