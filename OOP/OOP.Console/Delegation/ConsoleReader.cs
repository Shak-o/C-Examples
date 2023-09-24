namespace OOP.Console.Delegation;

public class ConsoleReader : IDataReader
{
    public Task<string> ReadDataAsync()
    {
        var data = System.Console.ReadLine() ?? string.Empty;
        return Task.FromResult(data);
    }

    public string ReadData()
    {
        return System.Console.ReadLine() ?? string.Empty;
    }
}