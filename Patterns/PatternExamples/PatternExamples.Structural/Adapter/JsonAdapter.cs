using System.Xml;
using Newtonsoft.Json;

namespace PatternExamples.Structural.Adapter;

public class JsonAdapter(XmlDataRetriever xmlDataRetriever) : IDataRetriever
{
    private static string ConvertXmlToJson(string xmlString)
    {
        var doc = new XmlDocument();
        doc.LoadXml(xmlString);
        var jsonText = JsonConvert.SerializeXmlNode(doc);
        return jsonText;
    }

    public string GetData()
    {
        var xmlData = xmlDataRetriever.GetData();
        return ConvertXmlToJson(xmlData);
    }
}