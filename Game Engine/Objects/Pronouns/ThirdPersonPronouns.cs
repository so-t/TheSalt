using System;
using static Constants;

namespace Salt_Systems.Properties
{
    public class ThirdPersonPronouns
    {
        private readonly string 
            _subjective,
            _objective, 
            _dependentPossessive, 
            _independentPossessive, 
            _reflexive; 
        
        // A char can be supplied to the constructor to create a pronoun set for a specific gender.
        // Supplying the char 'm' will produce a Masculine pronoun set, supplying an 'f' a female pronoun set, 
        // supplying an 'e' an Epicene (or Non-binary) pronoun set, and supplying 'i' an Inanimate pronoun set
        public ThirdPersonPronouns(int gender)
        {
            switch (gender)
            {
                case Genders.MASCULINE:
                    _subjective = "he";
                    _objective = "him";
                    _dependentPossessive = "his";
                    _independentPossessive = "his";
                    _reflexive = "himself";
                    break;
                case Genders.FEMININE:
                    _subjective = "she";
                    _objective = _dependentPossessive = "her";
                    _independentPossessive = "hers";
                    _reflexive = "herself";
                    break;
                case Genders.EPICENE:
                    _subjective = "they";
                    _objective = "them";
                    _dependentPossessive = "their";
                    _independentPossessive = "theirs";
                    _reflexive = "themself";
                    break;
                case Genders.NEUTER:
                    _subjective = _objective = "it";
                    _dependentPossessive = _independentPossessive = "its";
                    _reflexive = "itself";
                    break;
            }     
        }

        // If no char is supplied to the constructor third person pronouns for a random gender
        // (of the implemented genders: Masculine, Feminine, Epicene or Inanimate) will be created
        public ThirdPersonPronouns()
        {
            var r = new Random();
            switch (r.Next(4))
            {
                case 0:
                    _subjective = "he";
                    _objective = "him";
                    _dependentPossessive = _independentPossessive = "his";
                    _reflexive = "himself";
                    break;
                case 1:
                    _subjective = "she";
                    _objective = _dependentPossessive = "her";
                    _independentPossessive = "hers";
                    _reflexive = "herself";
                    break;
                case 2:
                    _subjective = "they";
                    _objective = "them";
                    _dependentPossessive = "their";
                    _independentPossessive = "theirs";
                    _reflexive = "themself";
                    break;
                case 3:
                    _subjective = _objective = "it";
                    _dependentPossessive = _independentPossessive = "its";
                    _reflexive = "itself";
                    break;
            }
        }
        
        public string Subjective()
        {
            return _subjective;
        }

        public string Objective()
        {
            return _objective;
        }

        public string DependentPossessive()
        {
            return _dependentPossessive;
        }

        public string IndependentPossessive()
        {
            return _independentPossessive;
        }

        public string Reflexive()
        {
            return _reflexive;
        }
    }
}