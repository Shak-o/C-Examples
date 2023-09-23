namespace OOP.Console.Composition;

/// <summary>
/// In object-oriented design and programming, composition is a way to combine simple objects or data types into more
/// complex ones. This design principle promotes the concept of "has-a" relationship rather than an "is-a" relationship
/// (which is more aligned with inheritance). Using composition, we can create more complex objects by adding
/// (or "composing") simpler objects.
/// </summary>
public class Person
{
    public string Name { get; set; } = null!;
    public Home Home { get; set; } = null!;
}