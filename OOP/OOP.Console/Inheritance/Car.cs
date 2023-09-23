namespace OOP.Console.Inheritance;

/// <summary>
/// Inheritance is a fundamental concept in object-oriented programming (OOP) where a new class is derived from an
/// existing class. This mechanism allows the derived class (often called the "subclass" or "child class") to inherit
/// attributes and behaviors (i.e., fields and methods) from the existing class
/// (often called the "superclass" or "parent class").
/// </summary>
public class Car : Vehicle
{
    public int DoorCount { get; set; }

    public void PracticeMethod()
    {
        MoveForward();
        System.Console.WriteLine($"Model {Model}, DoorCount {DoorCount}");
    }
}