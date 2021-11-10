
using static Constants;
public class SaltGameObject
{
        // Private variables
        private string _name, _description;
        private int _health, _maxHealth;
        private PronounSet _pronounSet = new PronounSet(Genders.NEUTER);

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
                _pronounSet = pronouns
        }       
        
        public string GetSecondPersonSubjective() 
        {
                return PronounSet.SecondPersonSubjective();
        }
        
        public string GetSecondPersonObjective() 
        {
                return PronounSet.SecondPersonObjective();
        }
        
        public string GetSecondPersonDependentPossessive() 
        {
                return PronounSet.SecondPersonDependentPossessive();
        }
        
        public string GetSecondPersonIndependentPossessive() 
        {
                return PronounSet.SecondPersonIndependentPosessive();
        }
        
        public string GetSecondPersonReflexive() 
        {
                return PronounSet.SecondPersonReflexive();
        }

        public string GetThirdPersonSubjective() 
        {
                return PronounSet.ThirsPersonSubjective();
        }
        
        public string GetThirdPersonObjective() 
        {
                return PronounSet.ThirdPersonObjective();
        }
        
        public string GetThirdPersonDependentPossessive() 
        {
                return PronounSet.ThirdPersonDependentPosessive();
        }
        
        public string GetThirdPersonIndependentPossessive() 
        {
                return PronounSet.ThirdPersonIndependentPosessive();
        }
        
        public string GetThirdPersonReflexive() 
        {
                return PronounSet.ThirdPersonReflexive();
        }

        public virtual void Update()
        {
        }

}