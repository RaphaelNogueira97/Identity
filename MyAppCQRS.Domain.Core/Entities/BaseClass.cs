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

        public virtual T ParseJson()
        {
            var jsonString = JsonSerializer.Serialize(this);
            return JsonSerializer.Deserialize<T>(jsonString);
        }
=======
>>>>>>> Adjust login authentication and implements parcial cache
    }
}