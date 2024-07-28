namespace PatternExamples.Structural.Flyweight.With;

public class PersonFlyweight
{
    private readonly string _someLegalBs;
    
    public PersonFlyweight(string someLegalBs)
    {
        _someLegalBs = new string(someLegalBs); // FOR TESTING ONLY used new string so that it would take some memory 
    }

    public string GetLegalBs() => _someLegalBs;
}