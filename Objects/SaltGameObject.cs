using System.Collections.Generic;
using UnityEditor.SceneManagement;

public class SaltGameObject
{
        // Private variables
        private string _name, _description;
        private int _health, _maxHealth;
        private LinkedList<Status> _status = new LinkedList<Status>();
        private bool _isALive;
        private Weapon _weapon;
        private PronounSet _pronounSet = new PronounSet((int) Genders.NEUTER);

        // Public variables
        public void SetName(string name)
        {
                _name = name;
        }

        public void AddNewStatus(Status status)
        {
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

        public void SetDescription(string description)
        {
                _description = description;
        }

        public string GetDescription()
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
        
        public virtual int Attack(SaltGameObject target)
        {
                return 0;
        }
        
        public virtual void Defend(int damage)
        {
                SetHealth(damage >= GetHealth() ?  GetHealth() - damage : 0);
                if (GetHealth() == 0) SetIsAlive(false);
        }

        public void SetMaxHealth(int maxHealth)
        {
                _maxHealth = maxHealth;
        }

        public int GetMaxHealth()
        {
                return _maxHealth;
        }

        public void SetIsAlive(bool isAlive)
        {
                _isALive = isAlive;
        }

        public bool GetIsAlive()
        {
                return _isALive;
        }

        public void SetWeapon(Weapon weapon)
        {
                _weapon = weapon;
        }

        public Weapon GetWeapon()
        {
                return _weapon;
        }

        public void SetPronouns(PronounSet pronouns)
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

        public string GetThirdPersonSubjective() 
        {
                return _pronounSet.ThirdPersonSubjective();
        }
        
        public string GetThirdPersonObjective() 
        {
                return _pronounSet.ThirdPersonObjective();
        }
        
        public string GetThirdPersonDependentPossessive() 
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

        public void ApplyStatus()
        {
                for (var node = _status.First; node != null; )
                {
                        var status = node.Value;
                        status.Update();

                        if (status.ShouldBeRemoved())
                        {
                                var temp = node;
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