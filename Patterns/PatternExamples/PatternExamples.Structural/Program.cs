// See https://aka.ms/new-console-template for more information

using PatternExamples.Structural.Adapter;

// Adapter
var dataRetriever = new XmlDataRetriever();
var jsonAdapter = new JsonAdapter(dataRetriever);
var data = jsonAdapter.GetData();
var count = new NameCounter().GetCount(data);

Console.WriteLine(data);
Console.WriteLine(count);