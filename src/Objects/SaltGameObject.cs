using System.Collections.Generic;
using UnityEngine;

public class SaltGameObject
{
        // Private variables
        private string _name, _description;
        private int _health, _maxHealth;
        private LinkedList<Status> _status = new LinkedList<Status>();
        private bool _isALive;
        private PronounSet _pronounSet = new PronounSet((int) Genders.NEUTER);

        // Public variables
        protected Weapon Weapon;
        public int statusCount = 0;
        
        protected void SetName(string name)
        {
                _name = name;
        }

        //TODO Test to make sure adding and removing status functions as intended
        public void AddNewStatus(Status status)
        {
                statusCount += 1;
                if (_status.Count == 0)
                {
                        _status.AddFirst(status);
                }
                else
                {
                        for (var node = _status.First; node != null; node = node.Next) 
                        {
                                if (status.GetPriority() < node.Value.GetPriority())
                                {
                                        _status.AddBefore(node, status);
                                }
                        }
                }
        }

        public string GetName()
        {
                return _name;
        }

        protected void SetDescription(string description)
        {
                _description = description;
        }

        public virtual string GetDescription()
        {
                return _description;
        }
    
        public void SetHealth(int health)
        {
                _health = health;
        }

        public int GetHealth()
        {
                return _health;
        }
        
        public virtual void Attack(SaltGameObject target) {}
        
        public virtual void Defend(int damage) {}

        public void SetMaxHealth(int maxHealth)
        {
                _maxHealth = maxHealth;
        }

        public int GetMaxHealth()
        {
                return _maxHealth;
        }

        protected void SetIsAlive(bool isAlive)
        {
                _isALive = isAlive;
        }

        public bool GetIsAlive()
        {
                return _isALive;
        }

        protected virtual void SetWeapon(Weapon weapon)
        {
                Weapon = weapon;
        }

        public Weapon GetWeapon()
        {
                return Weapon;
        }

        protected void SetPronouns(PronounSet pronouns)
        {
                _pronounSet = pronouns;
        }
        
        public string GetSecondPersonSubjective() 
        {
                return _pronounSet.SecondPersonSubjective();
        }
        
        public string GetSecondPersonObjective() 
        {
                return _pronounSet.SecondPersonObjective();
        }
        
        public string GetSecondPersonDependentPossessive() 
        {
                return _pronounSet.SecondPersonDependentPossessive();
        }
        
        public string GetSecondPersonIndependentPossessive() 
        {
                return _pronounSet.SecondPersonIndependentPossessive();
        }
        
        public string GetSecondPersonReflexive() 
        {
                return _pronounSet.SecondPersonReflexive();
        }

        protected string GetThirdPersonSubjective() 
        {
                return _pronounSet.ThirdPersonSubjective();
        }
        
        public string GetThirdPersonObjective() 
        {
                return _pronounSet.ThirdPersonObjective();
        }
        
        protected string GetThirdPersonDependentPossessive() 
        {
                return _pronounSet.ThirdPersonDependentPossessive();
        }
        
        public string GetThirdPersonIndependentPossessive() 
        {
                return _pronounSet.ThirdPersonIndependentPossessive();
        }
        
        public string GetThirdPersonReflexive() 
        {
                return _pronounSet.ThirdPersonReflexive();
        }

        protected void ApplyStatus()
        {
                for (var node = _status.First; node != null; )
                {
                        var status = node.Value;
                        status.Update();

                        if (status.ShouldBeRemoved())
                        {
                                var temp = node;
                                statusCount -= 1;
                                Debug.Log("Removing an instance of poison.\n" +
                                          "The player currently has " +
                                          statusCount +
                                          " instances of poison.");
                                node = node.Next;
                                _status.Remove(temp);
                        }
                        else node = node.Next;
                }
        }

        public virtual void Update()
        {
        }

}