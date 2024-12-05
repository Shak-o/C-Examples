### **Single Responsibility Principle (SRP)**
**Definition**: A class should have only one reason to change, meaning it should only have one responsibility or one purpose.

**Why**: This makes the code easier to understand, test, and maintain.

**Pattern to Implement SRP**:
- **Facade Pattern**: To group related functionality and delegate responsibilities to individual classes.
- **Repository Pattern**: To separate data access logic from business logic.

---

### **Example (C#)**:

Let's consider a system that manages employee data. Without SRP, you might write a single class for everything:

```csharp
// NOT following SRP
public class EmployeeService
{
    public void AddEmployee(Employee employee)
    {
        // Add employee to the database
    }

    public void GenerateEmployeeReport()
    {
        // Generate a report about employees
    }
}
```

Here, the `EmployeeService` class is doing multiple things: managing employee data and generating reports.

#### Refactored Code Using SRP:

```csharp
// Following SRP
public class EmployeeRepository
{
    public void AddEmployee(Employee employee)
    {
        // Add employee to the database
    }
}

public class EmployeeReportGenerator
{
    public void GenerateEmployeeReport()
    {
        // Generate a report about employees
    }
}
```

Now, each class has a single responsibility:
- `EmployeeRepository` handles database operations.
- `EmployeeReportGenerator` handles report generation.