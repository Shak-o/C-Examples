namespace OOP.Console.DependencyInversion.Implementations;

public class ConsoleDataProvider : ITextDataProvider
{
    public string ReadText()
    {
        return "Reading data from console";
    }
}