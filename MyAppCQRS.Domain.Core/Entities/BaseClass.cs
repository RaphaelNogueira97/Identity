using System;
using System.Text.Json;

namespace MyAppCQRS.Domain.Core.Entities
{
    public class BaseClass<T>
    {
        public virtual string ToJson()
        {
            return JsonSerializer.Serialize("");
        }
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> adjust and implementation generic classes, but is broken application

        public virtual T ParseJson()
        {
            var jsonString = JsonSerializer.Serialize(this);
            return JsonSerializer.Deserialize<T>(jsonString);
        }
<<<<<<< HEAD
=======
>>>>>>> Adjust login authentication and implements parcial cache
=======
>>>>>>> adjust and implementation generic classes, but is broken application
    }
}