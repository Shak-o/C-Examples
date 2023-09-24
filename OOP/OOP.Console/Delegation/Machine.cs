namespace OOP.Console.Delegation;
/// <summary>
/// Delegation is a design pattern in object-oriented programming where an object handles a request by delegating to another object,
/// called its delegate. Instead of doing the work itself, the delegating object forwards the task to the delegate object. This
/// pattern allows responsibilities to be shared and promotes separation of concerns, leading to more modular and reusable code.
/// 
/// The main idea behind delegation is to use composition in situations where inheritance might seem like the only solution.
/// It can be summarized by the phrase: "Delegation is when you want your object to perform some work, but instead,
/// it hands off the request to a helper object."
/// </summary>
public class Machine
{
    /// <summary>
    /// This might be file reader or console reader or any other reader. So machine class will delegate the task of
    /// reading data to other classes. 
    /// </summary>
    private readonly IDataReader _dataReader;

    public Machine(IDataReader dataReader)
    {
        _dataReader = dataReader;
    }

    public string ReadData() => _dataReader.ReadData();

    public Task<string> ReadDataAsync() => _dataReader.ReadDataAsync();
}