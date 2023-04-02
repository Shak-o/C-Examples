using Newtonsoft.Json.Linq;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TestingApp
{
    public static class Helpers
    {

        public static T ConvertJObject<T>(JObject jObject)
        {
            Type targetType = typeof(T);
            if (targetType == typeof(string))
            {
                return (T)(object)jObject.ToString();
            }
            else if (targetType.IsGenericType && targetType.GetGenericTypeDefinition() == typeof(Dictionary<,>))
            {
                Type[] genericArguments = targetType.GetGenericArguments();
                if (genericArguments[0] == typeof(string) && genericArguments[1] == typeof(string))
                {
                    return (T)(object)jObject.ToObject<Dictionary<string, string>>();
                }
            }
            else if (targetType.IsGenericType && targetType.GetGenericTypeDefinition() == typeof(List<>))
            {
                Type[] genericArguments = targetType.GetGenericArguments();
                if (genericArguments[0] == typeof(string))
                {
                    return (T)(object)jObject.ToObject<List<string>>();
                }
            }
            else
            {
                throw new NotSupportedException($"Type '{targetType.Name}' is not supported.");
            }

            return default;
        }
    }
}
