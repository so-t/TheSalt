public class SecondPersonPronouns
{
    private readonly string 
        _subjective = "you",
        _objective = "you", 
        _dependentPossessive = "your", 
        _independentPossessive = "yours", 
        _reflexive = "yourself";
    
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