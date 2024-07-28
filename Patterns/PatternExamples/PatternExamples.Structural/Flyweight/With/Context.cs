using System.Text;

namespace PatternExamples.Structural.Flyweight.With;

public class Context
{
    private readonly PersonFlyweight _personFlyweight;
    public Context(PersonFlyweight personFlyweight, string name, int age)
    {
        _personFlyweight = personFlyweight;
        Name = name;
        Age = age;
    }
    
    public string Name { get; set; }
    public int Age { get; set; }

    public string GetPersonInfo()
    {
        var builder = new StringBuilder();
        builder.AppendLine($"{Name} is age of {Age} and have legal info:");
        builder.AppendLine(_personFlyweight.GetLegalBs());
        return builder.ToString();
    }
}