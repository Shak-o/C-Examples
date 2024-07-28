// See https://aka.ms/new-console-template for more information

using BenchmarkDotNet.Running;
using PatternExamples.Structural.Adapter;
using PatternExamples.Structural.Bridge;
using PatternExamples.Structural.Composite;
using PatternExamples.Structural.Composite.Employees;
using PatternExamples.Structural.Decorator;
using PatternExamples.Structural.Decorator.Decorators;
using PatternExamples.Structural.Facade;
using PatternExamples.Structural.Flyweight;

// // Adapter
// var dataRetriever = new XmlDataRetriever();
// var jsonAdapter = new JsonAdapter(dataRetriever);
// var data = jsonAdapter.GetData();
// var count = new NameCounter().GetCount(data);
//
// Console.WriteLine(data);
// Console.WriteLine(count);
// // =======================
//
// // Bridge
// var tv = new Tv();
// var conditioner = new Conditioner();
//
// var tvRemote = new TvRemote(tv);
// tvRemote.Power();
//
// var conditionerRemote = new ConditionerRemote(conditioner);
// conditionerRemote.Power();
// conditionerRemote.IncreaseFanSpeed();
// // =======================

// // Composite
// var developer = new Developer();
// var analyst = new Analyst();
// var tester = new Tester();
// var someoneInBetween = new SomeoneInBetween();
// var manager = new Manager();
//
// var department = new Department();
// department.AddSomethingToCommandAround(developer);
// department.AddSomethingToCommandAround(analyst);
// department.AddSomethingToCommandAround(tester);
// department.AddSomethingToCommandAround(someoneInBetween);
// department.AddSomethingToCommandAround(manager);
//
// // Client code
// void IWanna(ISomethingToCommandAround somethingToCommandAround)
// {
//     somethingToCommandAround.DoTask();
//     Console.WriteLine("*System is buggy*");
//     somethingToCommandAround.ExplainYourself();
// }
//
// IWanna(developer);
// Console.WriteLine("=====");
// IWanna(department);
// // =======================

// Decorator
// var notifier = new EmailNotifier(); // Default notifier
// var smsNotifier = new SmsNotifier(notifier); // Sms Decorator
// var facebookNotifier = new FacebookNotifier(smsNotifier); // Facebook Decorator
//
// facebookNotifier.Send("You've got mail", "Giorgi Jondoie");
// =======================

// Facade
// var facade = new HttpFacade();
// await facade.MakeRequest(new Developer());
// =======================

// Flyweight
var summary = BenchmarkRunner.Run<Benchmark>();