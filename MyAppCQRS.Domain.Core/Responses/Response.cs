<<<<<<< HEAD
﻿using MyAppCQRS.Domain.Core.Helper;
using Newtonsoft.Json;
=======
﻿using Newtonsoft.Json;
>>>>>>> Adjust login authentication and implements parcial cache

namespace MyAppCQRS.Domain.Core.Responses
{
    public class Response
    {
        public Response(object response, bool isValid = true)
        {
            Data = response;
            IsValid = isValid;
        }

        public object Data { get; private set; }
        public bool IsValid { get; private set; }

        public T Convert<T>()
        {
            var jsonString = JsonConvert.SerializeObject(Data, Formatting.Indented);
            return JsonConvert.DeserializeObject<T>(jsonString);
        }
    }
}
