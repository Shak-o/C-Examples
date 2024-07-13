using System.Text.Json;

namespace PatternExamples.Structural.Adapter;

// Let pretend this is 3rd party library
public class NameCounter
{
    public int GetCount(string json)
    {
        var document = JsonDocument.Parse(json);
        return CountNameProperties(document.RootElement);
    }
    
    // NOTE: for presentation only.
    private int CountNameProperties(JsonElement element)
    {
        var count = 0;

        if (element.ValueKind == JsonValueKind.Object)
        {
            foreach (var property in element.EnumerateObject())
            {
                if (property.Name == "name")
                {
                    count++;
                }

                // Recursively check nested objects and arrays
                count += CountNameProperties(property.Value);
            }
        }
        else if (element.ValueKind == JsonValueKind.Array)
        {
            foreach (var item in element.EnumerateArray())
            {
                count += CountNameProperties(item);
            }
        }

        return count;
    }
}