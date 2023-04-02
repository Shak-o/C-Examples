// See https://aka.ms/new-console-template for more information
using Newtonsoft.Json;
using Newtonsoft.Json.Linq;
using System.Reflection;
using TestingApp;

var ff = new Dictionary<string, string>(new List<KeyValuePair<string, string>>()
{
    new KeyValuePair<string, string>("test", "mf")
}
);

var maTest = new TestObject();

var serialized = JsonConvert.SerializeObject(ff);

dynamic convertedBack = JsonConvert.DeserializeObject(serialized);

var type = maTest.GetType();
var prop = type.GetProperty("DictionaryOfStrings");

object propertyValue = typeof(Helpers).GetMethod("ConvertJObject", BindingFlags.Static | BindingFlags.Public)!
    .MakeGenericMethod(prop.PropertyType)!
    .Invoke(null, new object[] { convertedBack })!;

// Set the property value using reflection:
prop.SetValue(maTest, propertyValue);

Console.WriteLine(serialized);





