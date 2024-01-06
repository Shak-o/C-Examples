namespace OOP.Console.DependencyInversion;

/// <summary>
/// The Dependency Inversion Principle (DIP) is often summarized with two key points:
/// 
/// 1)High-level modules should not depend on low-level modules, but both should depend on abstractions.
/// 2)Abstractions should not depend upon details; details should depend upon abstractions.
/// 
/// In simpler terms, DIP advises programmers to avoid hard-coding dependencies between different parts of a program,
/// and instead to rely on abstract interfaces. This way, high-level and low-level components can remain separate,
/// making the codebase more modular and easier to maintain and extend.
/// </summary>
public class TextReader
{
    /// <summary>
    /// Here instead of injecting all data providers separately we just used one interface. That solved our problem of
    /// hard coded dependencies;
    /// </summary>
    private readonly ITextDataProvider _textDataProvider;

    public TextReader(ITextDataProvider textDataProvider)
    {
        _textDataProvider = textDataProvider;
    }

    public string Read() => _textDataProvider.ReadText();
}