using System;
using System.Collections.Generic;
using System.Text;

namespace MyAppCQRS.Domain.Core.Responses
{
    public class Response
    {
        public Response(object response, bool isValid)
        {
            Data = response;
            IsValid = isValid;
        }

        public object Data { get; private set; }
        public bool IsValid { get; private set; }
    }
}
