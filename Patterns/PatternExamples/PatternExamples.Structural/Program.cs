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

// Bridge
var tvRemote = new TvRemote();
var tv = new Tv(tvRemote);
tv.AddButtonAction();