public class SaltGameObject
{
        // Private variables
        private string _name, _description;
        private int _health, _maxHealth;

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

        public virtual void Update()
        {
        }

}