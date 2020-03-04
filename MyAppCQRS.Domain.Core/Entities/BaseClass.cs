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
    }
}