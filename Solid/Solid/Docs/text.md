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

Would you like to explore examples or how to implement this in code?

