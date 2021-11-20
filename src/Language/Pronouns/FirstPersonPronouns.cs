public class FirstPersonPronouns
{
    private readonly string 
        _subjective = "I",
        _objective = "me", 
        _dependentPossessive = "my", 
        _independentPossessive = "mine", 
        _reflexive = "myself";
    
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