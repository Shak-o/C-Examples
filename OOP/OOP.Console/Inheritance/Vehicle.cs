using System;

namespace OOP.Console.Inheritance;

public class Vehicle
{
    public string Model { get; set; } = null!;

    public void MoveForward()
    {
        System.Console.WriteLine("Moving forward");
    }
}