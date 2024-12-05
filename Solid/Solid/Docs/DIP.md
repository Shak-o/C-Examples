### **Dependency Inversion Principle (DIP)**

**Definition**: High-level modules should not depend on low-level modules. Both should depend on abstractions.
- Abstractions should not depend on details. Details should depend on abstractions.

**Why**: This promotes loosely coupled code, making the system more flexible and easier to maintain.

**Pattern to Implement DIP**:
- **Dependency Injection**: Pass dependencies through constructors, methods, or properties.
- **Service Locator Pattern**: Provide a centralized way to resolve dependencies.

---

### **Example (C#)**:

Let’s consider an example where a high-level module directly depends on a low-level module, violating DIP.

#### Violating DIP:

```csharp
public class EmailService
{
    public void SendEmail(string message)
    {
        Console.WriteLine($"Sending email: {message}");
    }
}

public class Notification
{
    private EmailService _emailService;

    public Notification()
    {
        _emailService = new EmailService(); // Direct dependency on low-level module
    }

    public void Send(string message)
    {
        _emailService.SendEmail(message);
    }
}
```

#### Problem:
The `Notification` class directly depends on the `EmailService` class, making it hard to replace or extend.

---

#### Refactored Code Using DIP (with Dependency Injection):

1. Introduce an abstraction for the dependency:

```csharp
public interface IMessageService
{
    void SendMessage(string message);
}
```

2. Implement the abstraction:

```csharp
public class EmailService : IMessageService
{
    public void SendMessage(string message)
    {
        Console.WriteLine($"Sending email: {message}");
    }
}

public class SmsService : IMessageService
{
    public void SendMessage(string message)
    {
        Console.WriteLine($"Sending SMS: {message}");
    }
}
```

3. Refactor the high-level module to depend on the abstraction:

```csharp
public class Notification
{
    private readonly IMessageService _messageService;

    public Notification(IMessageService messageService)
    {
        _messageService = messageService; // Dependency injected
    }

    public void Send(string message)
    {
        _messageService.SendMessage(message);
    }
}
```

4. Usage:

```csharp
var emailService = new EmailService();
var notification = new Notification(emailService);
notification.Send("Hello via Email!");

var smsService = new SmsService();
var notificationSms = new Notification(smsService);
notificationSms.Send("Hello via SMS!");
```

---

### Key Benefits:
- `Notification` now depends on the abstraction (`IMessageService`) rather than the concrete implementation (`EmailService` or `SmsService`).
- You can easily add new message services (e.g., `PushNotificationService`) without modifying the `Notification` class.

---