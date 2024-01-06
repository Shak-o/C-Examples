namespace OOP.Console.DependencyInversion.Implementations;

public class FileDataProvider : ITextDataProvider
{
    public string ReadText()
    {
        return "Reading data from file";
    }
}