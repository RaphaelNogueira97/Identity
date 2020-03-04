using MyAppCQRS.Domain.Core.Fixed;
using Newtonsoft.Json;
using System;
using System.Collections.Generic;
using System.Runtime.Serialization;
using System.Text;

namespace MyAppCQRS.Domain.Core.Responses
{
    public class AuthResponse
    {
        public bool Authenticated { get; set; }
        public DateTime Created { get; set; }
        public DateTime Expiration { get; set; }
        public string AccessToken { get; set; }
        public ResponseType Message { get; set; }
    }
}
