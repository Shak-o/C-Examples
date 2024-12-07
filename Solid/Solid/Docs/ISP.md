### **Interface Segregation Principle (ISP)**

**Definition**: A class should not be forced to implement interfaces it does not use. Instead of having one large interface, split it into smaller, more specific interfaces.

**Why**: It prevents classes from having unnecessary dependencies and makes the code more maintainable and easier to test.

**Pattern to Implement ISP**:
- **Adapter Pattern**: To adapt different interfaces to a client’s needs.
- **Proxy Pattern**: To provide a simplified interface to complex functionality.

In OOP:  
Abstraction: Define small, specific interfaces tailored to the needs of clients instead of large, general-purpose ones.

---

### **Example (C#)**:

Let’s consider an example where a large interface violates ISP.

#### Violating ISP:

```csharp
public interface IWorker
{
    void Work();
    void Eat();
}

public class Robot : IWorker
{
    public void Work()
    {
        Console.WriteLine("Robot is working...");
    }

    public void Eat()
    {
        // Robots don't eat, but are forced to implement this method
        throw new NotImplementedException();
    }
}

public class Human : IWorker
{
    public void Work()
    {
        Console.WriteLine("Human is working...");
    }

    public void Eat()
    {
        Console.WriteLine("Human is eating...");
    }
}
```

#### Problem:
The `Robot` class is forced to implement the `Eat` method, which makes no sense for robots.

---

#### Refactored Code Using ISP:

```csharp
// Split the interface into smaller, more specific interfaces
public interface IWorkable
{
    void Work();
}

public interface IEatable
{
    void Eat();
}

// Human implements both IWorkable and IEatable
public class Human : IWorkable, IEatable
{
    public void Work()
    {
        Console.WriteLine("Human is working...");
    }

    public void Eat()
    {
        Console.WriteLine("Human is eating...");
    }
}

// Robot implements only IWorkable
public class Robot : IWorkable
{
    public void Work()
    {
        Console.WriteLine("Robot is working...");
    }
}
```

#### Usage:
```csharp
IWorkable humanWorker = new Human();
humanWorker.Work();

IEatable humanEater = new Human();
humanEater.Eat();

IWorkable robotWorker = new Robot();
robotWorker.Work();
```

Now, `Robot` is no longer forced to implement the `Eat` method, adhering to ISP.

---