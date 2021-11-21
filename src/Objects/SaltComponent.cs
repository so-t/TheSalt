﻿using UnityEngine;

public class SaltComponent : MonoBehaviour
{
        // Private variables
        private string _name, _description;
        private int _health, _maxHealth;
        private bool _isALive;
        private PronounSet _pronounSet = new PronounSet((int) Genders.NEUTER);
        
        // Public variables

        public virtual void Start() {}

        protected void SetName(string s)
        {
                _name = s;
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
        
        public virtual void Attack(SaltComponent target) {}
        
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
        public virtual void Update()
        {
        }

}