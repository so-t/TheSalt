using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Markov;
using UnityEngine;
using static GlobalVariables;
using static Constants;

public class NPC : Character
{
    // Private Variables
    private readonly int _origin, _gender, _gearLocation, _tattooLocation, _gear;
    private readonly bool _hasTattoo, _hasGear;
    private Room _currentRoom;
    private float _timeOfLastAction = Rand.Next(0,21) + Time.time, _minTimeBetweenActions = 30.0f;

    // Public Variables
    
    public NPC()
    {
        _origin = Rand.Next(0, ORIGIN_ARRAY_LENGTH);
        var chain = new MarkovChain<char>(3);
        foreach (var name in names)
        {
            chain.Add(name, weight: 1);
        }
        char[] n;
        do
        {
            n = chain.Chain(Rand).ToArray();
        } while (n.Length > 7);
        n[0] = Char.ToUpper(n[0]);
        SetName(new string(n));
        _gender = Rand.Next(0, GENDER_ARRAY_LENGTH);
        SetHealth(10);
        SetIsAlive(true);
        
        _hasTattoo = Rand.Next(0, 101) <= 35;
        if (_hasTattoo) _tattooLocation = Rand.Next(0, TATTOO_LOCATION_ARRAY_LENGTH);
        
        _hasGear = Rand.Next(0, 101) <= 33;
        _gear = Rand.Next(0, ITEM_ARRAY_LENGTH);
        _gearLocation = Rand.Next(0, ITEM_LOCATION_ARRAY_LENGTH);
        
        SetWeapon(_gear < 4 ? new Weapon(_gear) : new Weapon(UNARMED));
        
        
        
        var description = pronouns[_gender, SUBJECTIVE_UPPER] +
                          (_gender == THEY_THEM ? " appear" : " appears") + " to be from " +
                          origins[_origin] + ".";
        if (_hasTattoo)
            description += " " 
                           + pronouns[_gender, SUBJECTIVE_UPPER] 
                           + (_gender == THEY_THEM ? " have" : " has") 
                           + (_tattooLocation < PLURL_TATTOO_CUTOFF ? " a tattoo" : " tattoos") 
                           + " on " 
                           + (_gender == SHE_HER
                               ? pronouns[_gender, OBJECTIVE]
                               : pronouns[_gender, POSSESSIVE]) 
                           + " " 
                           + tattooLocations[_tattooLocation] 
                           + ".";

        if (_hasGear)
            description += " "
                           + pronouns[_gender, SUBJECTIVE_UPPER]
                           + (_gender == THEY_THEM ? " carry a " : " carries a ")
                           + items[_gear]
                           + (_gearLocation == BACKSTRAP ? 
                               " strapped to " + (_gender == SHE_HER ? 
                                   pronouns[_gender, OBJECTIVE] 
                                   : pronouns[_gender, POSSESSIVE]) + " " + itemLocations[_gearLocation] 
                               : " in " + (_gender == SHE_HER ? 
                                   pronouns[_gender, OBJECTIVE] 
                                   : pronouns[_gender, POSSESSIVE]) + " " + itemLocations[_gearLocation])
                           + ".";
            
        SetDescription(description);
    }

    public int GetGender()
    {
        return _gender;
    }

    public void SetCurrentRoom(Room room)
    {
        _currentRoom = room;
    }

    public Room GetCurrentRoom()
    {
        return _currentRoom;
    }

    public void MoveNPC()
    {
        List<int> connections = new List<int>();
        for (var dir = NORTH; dir < 4; dir++)
        {
            if (_currentRoom.HasConnection(dir)) connections.Add(dir);
        }

        int direction = connections[Rand.Next(connections.Count)];

        if (_currentRoom == CurrentRoom)
        {
            _currentRoom.NPCs.Remove(this);
            _currentRoom = _currentRoom.GetConnection(direction);
            _currentRoom.NPCs.Add(this);
            GameLog += "<color=#292b30>" + GetName() + " heads ";
            switch (direction)
            {
                case NORTH:
                    GameLog += "north.\n";
                    break;
                case SOUTH:
                    GameLog += "south.\n";
                    break;
                case EAST:
                    GameLog += "east.\n";
                    break;
                case WEST:
                    GameLog += "west.\n";
                    break;
            }
            GameLog += "</color>";
        } 
        else if (_currentRoom.GetConnection(direction) == CurrentRoom)
        {
            _currentRoom.NPCs.Remove(this);
            _currentRoom = _currentRoom.GetConnection(direction);
            _currentRoom.NPCs.Add(this);
            GameLog += "<color=#292b30>" + GetName() + " arrives from the ";
            switch (direction)
            {
                case NORTH:
                    GameLog += "south.\n";
                    break;
                case SOUTH:
                    GameLog += "north.\n";
                    break;
                case EAST:
                    GameLog += "west.\n";
                    break;
                case WEST:
                    GameLog += "east.\n";
                    break;
            }
            GameLog += "</color>";
        }
    }

    public override void Update()
    {
        if (_timeOfLastAction + _minTimeBetweenActions < Time.time)
        {
            _timeOfLastAction = Time.time;
            MoveNPC();
        }
    }
}