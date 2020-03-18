using System;
using System.ComponentModel;
using System.Text.Json;

namespace MyAppCQRS.Domain.Core.Helper
{
<<<<<<< HEAD
    public static class JsonParse
    {
        public static T Convert<T>(object obj)
=======
    public class JsonParse<T>
    {
        public static T Convert(object obj)
>>>>>>> Adjust login authentication and implements parcial cache
        {
            var jsonString = JsonSerializer.Serialize(obj);
            return JsonSerializer.Deserialize<T>(jsonString);
        }
    }
}
