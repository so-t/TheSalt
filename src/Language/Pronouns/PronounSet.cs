using System;

public class PronounSet
{
    private readonly FirstPersonPronouns _firstPerson = new FirstPersonPronouns();
    private readonly SecondPersonPronouns _secondPerson = new SecondPersonPronouns();
    private readonly ThirdPersonPronouns _thirdPerson;
    
    // A char can be supplied to the constructor to create a pronoun set for a specific gender.
    // Supplying the int 0 will produce a Masculine pronoun set, supplying an 1 a Feminine pronoun set, 
    // supplying an 2 an Epicene (or Non-binary) pronoun set, and supplying 3 an Neuter (or Inanimate) pronoun set
    public PronounSet(int gender)
    {
        _thirdPerson = new ThirdPersonPronouns(gender);
    }
    
    // If no char is supplied to the constructor a random pronoun set
    // (of the implemented sets Masculine, Feminine, Epicene or Inanimate) will be created
    public PronounSet()
    {
        var r = new Random();
        switch (r.Next(4))
        {
            case 0:
                _thirdPerson = new ThirdPersonPronouns((int) Genders.MASCULINE);
                break;
            case 1:
                _thirdPerson = new ThirdPersonPronouns((int) Genders.FEMININE);
                break;
            case 2:
                _thirdPerson = new ThirdPersonPronouns((int) Genders.EPICENE);
                break;
            case 3:
                _thirdPerson = new ThirdPersonPronouns((int) Genders.NEUTER);
                break;
        }
    }

    public string FirstPersonSubjective()
    {
        return _firstPerson.Subjective();
    }
    public string FirstPersonObjective()
    {
        return _firstPerson.Subjective();
    }
    public string FirstPersonDependentPossessive()
    {
        return _firstPerson.DependentPossessive();
    }
    public string FirstPersonIndependentPossessive()
    {
        return _firstPerson.IndependentPossessive();
    }
    public string FirstPersonReflexive()
    {
        return _firstPerson.Reflexive();
    }

    public string SecondPersonSubjective() 
    {
        return _secondPerson.Subjective();
    }
    public string SecondPersonObjective() 
    {
        return _secondPerson.Subjective();
    }
    public string SecondPersonDependentPossessive() 
    {
        return _secondPerson.DependentPossessive();
    }
    public string SecondPersonIndependentPossessive() 
    {
        return _secondPerson.IndependentPossessive();
    }
    public string SecondPersonReflexive() 
    {
        return _secondPerson.Reflexive();
    }

    public string ThirdPersonSubjective() 
    {
        return _thirdPerson.Subjective();
    }
    public string ThirdPersonObjective() 
    {
        return _thirdPerson.Objective();
    }
    public string ThirdPersonDependentPossessive() 
    {
        return _thirdPerson.DependentPossessive();
    }
    public string ThirdPersonIndependentPossessive() 
    {
        return _thirdPerson.IndependentPossessive();
    }
    public string ThirdPersonReflexive() 
    {
        return _thirdPerson.Reflexive();
    }
}