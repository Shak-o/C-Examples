namespace OOP.Console.OpenClosed;

/// <summary>
/// The Open/Closed Principle (OCP) is one of the five SOLID principles of object-oriented programming and design.
/// It suggests that software entities (like classes, modules, functions, etc.) should be open for extension,
/// but closed for modification. This means you should be able to add new functionality without changing the existing code,
/// which helps in maintaining code stability and reducing the risk of breaking existing functionality.
/// </summary>
public interface IMessageSender
{
    void SendMessage();
}