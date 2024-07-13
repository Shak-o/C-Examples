namespace PatternExamples.Structural.Adapter;

public class XmlDataRetriever : IDataRetriever
{
    public string GetData()
    {
        return """
               <?xml version="1.0" encoding="UTF-8"?>
               <root>
                  <lastname>test last</lastname>
                  <name>test</name>
               </root>
               """;
    }
}