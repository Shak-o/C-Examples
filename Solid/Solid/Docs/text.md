# SRP

SRP (Single Responsibility Principle) გვეუბნება, რომ თითოეული მოდული მხოლოდ ერთ მოქმედების გამომწვევზე
უნდა იყოს პასუხისმგებელი. მოქმედში იგულისხმება ჯგუფი, რომელიც იწვევს (უკვეთავს, ითხოვს) ცვლილებებს
ჩვენს ფუნქციონალში.

როგორც რობერტ მარტინი ამბობს, კლასს უნდა ჰქონდეს მხოლოდ ერთი მიზეზი შეცვლისა. გამომდინარე იქიდან, რომ
ზემოხსენებულ წინდადაებაში დაწერილმა სიტყვამ "მიზეზი" გამოიწვია დაბნეულობა, რობერტმა მოგვიანებით დააზუსტა
რას გულისხმობდა ამაში. მან განმარტა, რომ SRP შეგვიძლია სხვანაირადაც ჩამოვაყალიბოთ: "ერთად შევაგროვოთ
ისეთი რაღაცები რომლებიც საერთო მიზეზის გამო იცვლებიან, განვაცალკევოთ ისეთი რაღაცები, რომლებიც სხვადასხვა
მიზეზით იცვლებიან".

**Answer from Matt Timmermans
on [stackoverflow](https://stackoverflow.com/questions/46541197/does-the-single-responsibility-principle-work-in-oop)
**  
I like to state the single responsibility principle this way: "Every thing you write -- every module, class, interface,
or method, should have one job. It should do the whole job and only that job.

Notice that some of these things you write are big (modules), some are small (methods), some are in between (classes),
and some of the big things are made of smaller things.

That is not a problem, because jobs or responsibilities also come in various sizes and can be decomposed hierarchically.
The job of the police force, for example, is to "protect and serve" -- one job, that decomposes into "patrol the
streets", "solve crimes", etc., which can each be handled by a different unit. That creates the need for coordination (a
different job), and the job of each unit breaks down into jobs for individual officers, etc.

For every big job, there are many ways to break it down into smaller jobs, and every one of those can be modeled by a
software design that adheres to SRP and the other SOLID principles. Deciding how to break a problem down is a big part
of the art of software design.

# ISP

Software Engineering ში Interface Segregation Principle გვეუბნება რომ კოდის არც ერთი ნაწილი არ
უნდა იყოს დამოკიდებული (ან ჰქონდეს რაიმე სახის კავშრი) ისეთ მეთოდებზე, რომლებიც მას არ სჭირდება. ISP შლის ინტერფეისებს
ისე რომ დიდი
და კომპლექსური ინტერფეისებისაგან შეიქმნას პატარა და ფოკუსირებული ნაგლეჯები. ასეთ შემცირებულ
ინტერფეისებს role interface ებსაც უწოდებენ. ISP ის მთავარი მიზანია რომ სისტემის სხვადასხვა ნაწილები
ნაკლებად იყოს ერთმანეთთან გადაჯაჭვული, რათა ბოლო სერიაში რეფაქტორინგი ადვილად გამოვიდეს და ცვლილებებმა
ნაკლები ტკივილი მოიტანოს.

While the Interface Segregation Principle (ISP) originated in the context of object-oriented programming and code-level
interfaces, its core ideas can indeed be generalized to software architecture and system design. The fundamental concept
of ISP is about minimizing dependencies and ensuring that components only rely on the functionalities they actually
need. This principle promotes modularity, flexibility, and maintainability—not just in code, but also in the broader
architectural structures of software systems.

# OCP
The **Open/Closed Principle (OCP)** is one of the five SOLID principles of object-oriented programming and software design. It states that:

### **"A software entity (such as a class, module, or function) should be open for extension, but closed for modification."**

#### **Theoretical Explanation**
1. **Open for Extension**:
    - The behavior of a module, class, or function should be extendable to accommodate new functionality.
    - This means new features can be added without altering the existing code.

2. **Closed for Modification**:
    - Existing, tested code should not need to be changed when adding new functionality.
    - This reduces the risk of introducing bugs into the existing system.

#### **Key Benefits**
- **Maintains Stability**: Once a piece of code is written, tested, and deployed, it remains stable and untouched, reducing the risk of introducing new errors.
- **Supports Scalability**: As requirements evolve, new features can be added without rewriting or altering existing code.
- **Encourages Modular Design**: Code is designed in small, independent units that can be extended or replaced.

#### **How It's Achieved in Theory**
- **Abstraction**: By using interfaces, abstract classes, or polymorphism, behaviors can be defined in a way that allows extensions to replace or add implementations without changing the original structure.
- **Design Patterns**: Patterns like Strategy, Decorator, and Observer facilitate adhering to the Open/Closed Principle.

A real-life example where the **Open/Closed Principle (OCP)** shines is in building an API that handles multiple services, such as a payment gateway integrating various payment methods. This can include **3-tier architecture**, **repositories**, and extensible service logic for each payment provider.

---

### **Scenario: Payment API**

You are building a **Payment API** that processes payments using multiple providers (e.g., PayPal, Stripe, Square). The API adheres to a **3-tier architecture**:

1. **Presentation Layer**: Handles HTTP requests.
2. **Business Logic Layer**: Processes the request and applies the business logic.
3. **Data Access Layer**: Manages database interactions through repositories.

The requirements:
- New payment providers can be added with minimal changes to existing code.
- Payment methods (e.g., card, bank transfer) and behavior differ between providers.

---

### **Initial Design (Violation of OCP)**

A naive implementation might look like this in the **Business Logic Layer**:

```csharp
public class PaymentService
{
    public string ProcessPayment(string provider, decimal amount)
    {
        if (provider == "PayPal")
        {
            // Logic for PayPal payment
            return "PayPal payment processed.";
        }
        else if (provider == "Stripe")
        {
            // Logic for Stripe payment
            return "Stripe payment processed.";
        }
        else if (provider == "Square")
        {
            // Logic for Square payment
            return "Square payment processed.";
        }
        else
        {
            throw new NotImplementedException("Unknown provider.");
        }
    }
}
```

#### **Issues**:
1. Adding a new provider requires modifying the `ProcessPayment` method, increasing the risk of bugs.
2. No clear separation of concerns.
3. Violates OCP as the code must be modified for new functionality.

---

### **Refactored Design (Adheres to OCP)**

#### **Step 1: Define a Payment Abstraction**
Create an interface for all payment providers:

```csharp
public interface IPaymentProvider
{
    string Name { get; }
    string ProcessPayment(decimal amount);
}
```

#### **Step 2: Implement Payment Providers**
Each provider implements the `IPaymentProvider` interface:

```csharp
public class PayPalProvider : IPaymentProvider
{
    public string Name => "PayPal";

    public string ProcessPayment(decimal amount)
    {
        // PayPal-specific logic
        return $"PayPal payment of {amount:C} processed.";
    }
}

public class StripeProvider : IPaymentProvider
{
    public string Name => "Stripe";

    public string ProcessPayment(decimal amount)
    {
        // Stripe-specific logic
        return $"Stripe payment of {amount:C} processed.";
    }
}
```

#### **Step 3: Use a Factory or Service Locator**
Introduce a **factory** to manage providers dynamically:

```csharp
public class PaymentProviderFactory
{
    private readonly IEnumerable<IPaymentProvider> _providers;

    public PaymentProviderFactory(IEnumerable<IPaymentProvider> providers)
    {
        _providers = providers;
    }

    public IPaymentProvider GetProvider(string name)
    {
        return _providers.FirstOrDefault(p => p.Name.Equals(name, StringComparison.OrdinalIgnoreCase))
               ?? throw new NotImplementedException($"Provider {name} not implemented.");
    }
}
```

#### **Step 4: Update the Service Layer**
The `PaymentService` now delegates the responsibility to the factory:

```csharp
public class PaymentService
{
    private readonly PaymentProviderFactory _providerFactory;

    public PaymentService(PaymentProviderFactory providerFactory)
    {
        _providerFactory = providerFactory;
    }

    public string ProcessPayment(string provider, decimal amount)
    {
        var paymentProvider = _providerFactory.GetProvider(provider);
        return paymentProvider.ProcessPayment(amount);
    }
}
```

#### **Step 5: Data Access with Repositories**
A repository can handle transaction logging or audit trails:

```csharp
public interface IPaymentRepository
{
    void LogTransaction(string provider, decimal amount, string status);
}

public class PaymentRepository : IPaymentRepository
{
    public void LogTransaction(string provider, decimal amount, string status)
    {
        // Save to the database
        Console.WriteLine($"Logged: {provider}, {amount:C}, {status}");
    }
}
```

#### **Step 6: Use Dependency Injection (DI)**
Wire up dependencies in the **Startup.cs** or similar configuration file:

```csharp
services.AddScoped<IPaymentProvider, PayPalProvider>();
services.AddScoped<IPaymentProvider, StripeProvider>();
services.AddScoped<PaymentProviderFactory>();
services.AddScoped<PaymentService>();
services.AddScoped<IPaymentRepository, PaymentRepository>();
```

---

### **Adding a New Provider**
To add a new provider (e.g., Square), create a new implementation:

```csharp
public class SquareProvider : IPaymentProvider
{
    public string Name => "Square";

    public string ProcessPayment(decimal amount)
    {
        // Square-specific logic
        return $"Square payment of {amount:C} processed.";
    }
}
```

Register the provider in your DI container, and you're done! No changes to existing classes like `PaymentService` or `PaymentProviderFactory`.

---

### **Benefits of This Design**
1. **Adherence to OCP**: Adding a new provider does not modify existing code, only extends functionality.
2. **Separation of Concerns**: Each provider handles its logic independently.
3. **Scalability**: Easy to add new providers or modify existing ones.
4. **Testability**: Individual providers can be unit tested, and the factory/service can be mocked in tests.

