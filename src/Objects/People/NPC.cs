using System.Collections.Generic;
using System.Linq;
using Markov;
using UnityEngine;
using static GlobalVariables;

public class NPC : Character
{
    // Private Variables
    private int _origin, _gender, _gearLocation, _tattooLocation, _gear;
    private bool _hasTattoo, _hasGear;
    private float _timeOfLastAction;
    private const float MinTimeTimeBetweenActions = 30.0f;

    private void MoveNPC()
    {
        List<int> connections = new List<int>();
        for (var dir = (int) Directions.NORTH; dir < 4; dir++)
        {
            if (Location.HasConnection(dir)) connections.Add(dir);
        }

        int direction = connections[Rand.Next(connections.Count)];

        if (Location == player.GetLocation())
        {
            Location.components.Remove(this);
            Location = Location.GetConnection(direction);
            Location.components.AddFirst(this);
            GameLog += "\n<color=#292b30>" + GetName() + " heads ";
            switch (direction)
            {
                case (int) Directions.NORTH:
                    GameLog += "north.\n";
                    break;
                case (int) Directions.SOUTH:
                    GameLog += "south.\n";
                    break;
                case (int) Directions.EAST:
                    GameLog += "east.\n";
                    break;
                case (int) Directions.WEST:
                    GameLog += "west.\n";
                    break;
            }
            GameLog += "</color>";
        } 
        else if (Location.GetConnection(direction) == player.GetLocation())
        {
            Location.components.Remove(this);
            Location = Location.GetConnection(direction);
            Location.components.AddFirst(this);
            GameLog += "\n<color=#292b30>" + GetName() + " arrives from the ";
            switch (direction)
            {
                case (int) Directions.NORTH:
                    GameLog += "south.\n";
                    break;
                case (int) Directions.SOUTH:
                    GameLog += "north.\n";
                    break;
                case (int) Directions.EAST:
                    GameLog += "west.\n";
                    break;
                case (int) Directions.WEST:
                    GameLog += "east.\n";
                    break;
            }
            GameLog += "</color>";
        }
    }
    
    // TODO Fix: Currently if an object/NPC spawns in the starting room it will not return the correct description for the intro room message
    // Public Variables
    public override void Awake()
    {
        base.Awake();
        _timeOfLastAction = Rand.Next(0, 21) + Time.time;
        _origin = Rand.Next(0, (int) Arrays.ORIGIN_ARRAY_LENGTH);
        
        /* Begin Markov Chain for Name Creation */
        char[] n;
        do
        {
            n = NameChain.Chain(Rand).ToArray();
        } while (n.Length > 7);
        n[0] = char.ToUpper(n[0]);
        SetName(new string(n));
        /* End Name Generation */
        
        _gender = Rand.Next(0, (int) Arrays.GENDER_TYPES);
        SetPronouns(new PronounSet(_gender));
        SetHealth(10);
        SetIsAlive(true);
        
        _hasTattoo = Rand.Next(0, 101) <= 35;
        if (_hasTattoo) _tattooLocation = Rand.Next(0, (int) Arrays.TATTOO_LOCATION_ARRAY_LENGTH);
        
        _hasGear = Rand.Next(0, 101) <= 33;
        _gear = Rand.Next(0, (int) Arrays.ITEM_ARRAY_LENGTH);
        _gearLocation = Rand.Next(0, (int) Arrays.ITEM_LOCATION_ARRAY_LENGTH);

        if (_gear < 4)
            Weapon.SetWeaponType((Weapons) _gear);
        else 
            Weapon.SetWeaponType(Weapons.UNARMED);
        
        var description = char.ToUpper( GetThirdPersonSubjective()[0]) + GetThirdPersonSubjective().Substring(1)
                                                                        + (_gender == (int) Genders.EPICENE ? " appear" : " appears") + " to be from " 
                                                                        + GlobalVariables.Origins[_origin] 
                                                                        + ".";
        if (_hasTattoo)
            description += " " 
                           + char.ToUpper(GetThirdPersonSubjective()[0]) + GetThirdPersonSubjective().Substring(1) 
                           + (_gender == (int) Genders.EPICENE ? " have" : " has") 
                           + (_tattooLocation < (int) Arrays.PLURL_TATTOO_CUTOFF ? " a tattoo" : " tattoos") 
                           + " on " 
                           + GetThirdPersonDependentPossessive()
                           + " " 
                           + TattooLocations[_tattooLocation] 
                           + ".";

        if (_hasGear)
            description += " "
                           + char.ToUpper(GetThirdPersonSubjective()[0]) + GetThirdPersonSubjective().Substring(1)
                           + (_gender == (int) Genders.EPICENE ? " carry a " : " carries a ")
                           + Items[_gear]
                           + (_gearLocation == (int) EquipmentSlots.BACKSTRAP ? 
                               " strapped to " + GetThirdPersonDependentPossessive() + " " + ItemLocations[_gearLocation] 
                               : " in " + GetThirdPersonDependentPossessive() + " " + ItemLocations[_gearLocation])
                           + ".";
            
        SetDescription(description);
    }

    public override void Attack(SaltComponent target)
    {
        int damage = Rand.Next(1, GetWeapon().GetDamage());
        target.Defend(damage);
        if(target == player)
            GameLog += "\n" + GetName() + " attacks you for " + damage + " points of damage!";
    }
    
    public override void Update()
    {
        if (!GetIsAlive() || !(_timeOfLastAction + MinTimeTimeBetweenActions < Time.time)) return;
        _timeOfLastAction = Time.time;
        MoveNPC();
    }
}