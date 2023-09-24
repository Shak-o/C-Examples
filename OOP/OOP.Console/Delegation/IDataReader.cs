namespace OOP.Console.Delegation;

public interface IDataReader
{
    public Task<string> ReadDataAsync();
    public string ReadData();
}