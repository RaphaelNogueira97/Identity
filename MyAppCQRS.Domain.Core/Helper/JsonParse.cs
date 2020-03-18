using System;
using System.ComponentModel;
using System.Text.Json;

namespace MyAppCQRS.Domain.Core.Helper
{ 
    public static class JsonParse : Object
    {
        public static T Convert<T>(this object obj)
        {
            var jsonString = JsonSerializer.Serialize(obj);
            return JsonSerializer.Deserialize<T>(jsonString);
        }
    }
}
