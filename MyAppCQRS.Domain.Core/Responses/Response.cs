using MyAppCQRS.Domain.Core.Helper;
using Newtonsoft.Json;

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
    }
}
