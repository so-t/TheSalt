public class SaltGameObject
{
        // Private variables
        private string _name, _description;
        private int _health, _maxHealth;
        private PronounSet _pronounSet = new PronounSet((int) Genders.NEUTER);

        // Public variables

        public void SetName(string name)
        {
                _name = name;
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

        public void SetMaxHealth(int maxHealth)
        {
                _maxHealth = maxHealth;
        }

        public int GetMaxHealth()
        {
                return _maxHealth;
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

        public virtual void Update()
        {
        }

}