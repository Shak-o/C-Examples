### **Open/Closed Principle (OCP)**

**Definition**: A class should be **open for extension** but **closed for modification**.
- You should be able to add new functionality without changing existing code.

**Why**: This makes the system more maintainable and less prone to introducing bugs when extending functionality.

**Pattern to Implement OCP**:
- **Strategy Pattern**: To allow behaviors to be selected at runtime.
- **Decorator Pattern**: To dynamically add behavior to objects without altering their structure.

In OOP:  
Inheritance: Extend behavior through subclassing without modifying existing code.  
Polymorphism: Use polymorphic behavior to introduce new functionality via interfaces or abstract classes.

---

### **Example (C#)**:

Let's consider a payment processing system. Without OCP, you might modify a `PaymentProcessor` class every time a new payment method is added:

```csharp
// NOT following OCP
public class PaymentProcessor
{
    public void ProcessPayment(string paymentType)
    {
        if (paymentType == "CreditCard")
        {
            // Process credit card payment
        }
        else if (paymentType == "PayPal")
        {
            // Process PayPal payment
        }
        else if (paymentType == "ApplePay")
        {
            // Process ApplePay payment
        }
    }
}
```

Every time a new payment method is introduced, this class needs to be modified, violating OCP.

#### Refactored Code Using OCP (with Strategy Pattern):

```csharp
// Payment strategy interface
public interface IPaymentMethod
{
    void ProcessPayment();
}

// Implementations of different payment methods
public class CreditCardPayment : IPaymentMethod
{
    public void ProcessPayment()
    {
        Console.WriteLine("Processing credit card payment...");
    }
}

public class PayPalPayment : IPaymentMethod
{
    public void ProcessPayment()
    {
        Console.WriteLine("Processing PayPal payment...");
    }
}

public class ApplePayPayment : IPaymentMethod
{
    public void ProcessPayment()
    {
        Console.WriteLine("Processing ApplePay payment...");
    }
}

// Payment processor using the strategy
public class PaymentProcessor
{
    private readonly IPaymentMethod _paymentMethod;

    public PaymentProcessor(IPaymentMethod paymentMethod)
    {
        _paymentMethod = paymentMethod;
    }

    public void Process()
    {
        _paymentMethod.ProcessPayment();
    }
}
```

#### Usage:
```csharp
var creditCardPayment = new CreditCardPayment();
var paymentProcessor = new PaymentProcessor(creditCardPayment);
paymentProcessor.Process();

var payPalPayment = new PayPalPayment();
var paymentProcessor2 = new PaymentProcessor(payPalPayment);
paymentProcessor2.Process();
```

Now, to add a new payment method, you just create a new class implementing `IPaymentMethod` without changing existing code.