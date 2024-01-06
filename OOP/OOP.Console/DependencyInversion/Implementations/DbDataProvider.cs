namespace OOP.Console.DependencyInversion.Implementations;

public class DbDataProvider : ITextDataProvider
{
    public string ReadText()
    {
        return "Reading from Db";
    }
}