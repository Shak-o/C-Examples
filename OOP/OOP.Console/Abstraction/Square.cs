namespace OOP.Console.Abstraction;

public class Square : Shape
{
    private int _sideA;
    private int _sideB;
    private int _sideC;
    private int _sideD;
    
    public override double Area()
    {
        return Math.Pow(_sideA, 2);
    }
}