using System;
using System.ComponentModel;
using System.Text.Json;

namespace MyAppCQRS.Domain.Core.Helper
{
    public class JsonParse<T>
    {
        public static T Convert(object obj)
        {
            var jsonString = JsonSerializer.Serialize(obj);
            return JsonSerializer.Deserialize<T>(jsonString);
        }
    }
}
