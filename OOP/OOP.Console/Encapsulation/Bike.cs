namespace OOP.Console;

/// <summary>
/// Encapsulation refers to the bundling of data (attributes) and methods (functions) that operate on the data into a
/// single unit or class. It also restricts direct access to some of the object's components, which is a means of
/// preventing unintended interference and misuse of the data. This is typically achieved using access specifiers like
/// private, protected, etc.
/// </summary>
public class Bike
{
    private string _ownerName;

    public string OwnerName
    {
        get
        {
            return _ownerName;
        }
        set
        {
            _ownerName = value;
        }
    }

    public Bike(string ownerName)
    {
        _ownerName = ownerName;
    }
}