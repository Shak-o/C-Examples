// See https://aka.ms/new-console-template for more information

using PatternExamples.Structural.Adapter;
using PatternExamples.Structural.Bridge;

// Adapter
var dataRetriever = new XmlDataRetriever();
var jsonAdapter = new JsonAdapter(dataRetriever);
var data = jsonAdapter.GetData();
var count = new NameCounter().GetCount(data);

Console.WriteLine(data);
Console.WriteLine(count);
// =======================

// Bridge
// Client code
var tv = new Tv();
var conditioner = new Conditioner();

var tvRemote = new TvRemote(tv);
tvRemote.Power();

var conditionerRemote = new ConditionerRemote(conditioner);
conditionerRemote.Power();
conditionerRemote.IncreaseFanSpeed();
// =======================