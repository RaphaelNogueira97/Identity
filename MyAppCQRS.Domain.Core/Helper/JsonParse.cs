using System;
using System.ComponentModel;
using System.Text.Json;

namespace MyAppCQRS.Domain.Core.Helper
{
    public class JsonParse : Object
    {
        public T Convert<T>(this object obj)
        {
            var jsonString = JsonSerializer.Serialize(obj);
            return JsonSerializer.Deserialize<T>(jsonString);
        }
    }
}
