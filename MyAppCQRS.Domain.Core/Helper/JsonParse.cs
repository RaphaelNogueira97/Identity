using System;
using System.ComponentModel;
using System.Text.Json;

namespace MyAppCQRS.Domain.Core.Helper
{
<<<<<<< HEAD
<<<<<<< HEAD
    public static class JsonParse
    {
        public static T Convert<T>(object obj)
=======
    public class JsonParse<T>
    {
        public static T Convert(object obj)
>>>>>>> Adjust login authentication and implements parcial cache
=======
    public class JsonParse : Object
    {
        public T Convert<T>(this object obj)
>>>>>>> adjust and implementation generic classes, but is broken application
        {
            var jsonString = JsonSerializer.Serialize(obj);
            return JsonSerializer.Deserialize<T>(jsonString);
        }
    }
}
