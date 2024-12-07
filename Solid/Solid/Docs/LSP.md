### **Liskov Substitution Principle (LSP)**

**Definition**: Subtypes must be substitutable for their base types without altering the correctness of the program.
- In other words, if a class `A` is a subclass of class `B`, then objects of type `B` should be replaceable with objects of type `A` without breaking the application.

**Why**: Ensures that derived classes extend the behavior of their base classes without changing their core functionality or introducing unexpected behavior.

**Pattern to Implement LSP**:
- **Template Method Pattern**: To enforce behavior through an abstract class.
- **Factory Method Pattern**: To create objects ensuring they conform to expected behavior.

In OOP:  
Polymorphism: Subtypes must be substitutable for their base types, ensuring consistency in behavior.

---

### **Example (C#)**:

Let’s consider a shape hierarchy where we calculate the area of different shapes. Violating LSP could look like this:

```csharp
// Violating LSP
public class Rectangle
{
    public virtual double Width { get; set; }
    public virtual double Height { get; set; }

    public double CalculateArea()
    {
        return Width * Height;
    }
}

public class Square : Rectangle
{
    public override double Width
    {
        set { base.Width = base.Height = value; }
    }

    public override double Height
    {
        set { base.Width = base.Height = value; }
    }
}
```

#### Problem:
The `Square` class overrides `Width` and `Height` in a way that breaks the behavior of the `Rectangle` class. If you use `Square` as a `Rectangle`, the `CalculateArea` function might not work as expected.

---

#### Refactored Code Using LSP:

```csharp
// Base class
public abstract class Shape
{
    public abstract double CalculateArea();
}

// Rectangle class
public class Rectangle : Shape
{
    public double Width { get; set; }
    public double Height { get; set; }

    public override double CalculateArea()
    {
        return Width * Height;
    }
}

// Square class
public class Square : Shape
{
    public double Side { get; set; }

    public override double CalculateArea()
    {
        return Side * Side;
    }
}
```

#### Usage:
```csharp
Shape rectangle = new Rectangle { Width = 4, Height = 5 };
Console.WriteLine($"Rectangle Area: {rectangle.CalculateArea()}");

Shape square = new Square { Side = 4 };
Console.WriteLine($"Square Area: {square.CalculateArea()}");
```

Now `Rectangle` and `Square` are both substitutable for the `Shape` base class without breaking the application.