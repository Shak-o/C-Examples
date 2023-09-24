using System.Text;

namespace OOP.Console.Delegation;

public class FileReader : IDataReader
{
    private readonly string _filePath;
    
    public FileReader(string filePath)
    {
        _filePath = filePath;
    }
    
    public Task<string> ReadDataAsync()
    { 
        return File.ReadAllTextAsync(_filePath);
    }

    public string ReadData()
    {
        return File.ReadAllText(_filePath);
    }
}