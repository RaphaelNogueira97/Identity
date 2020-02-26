using System;
using System.Collections.Generic;
using System.Text;

namespace MyAppCQRS.Domain.Core.Entities
{
    public class User
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

    }

    public static class Roles
    {
        public const string ROLE_MEMBER = "Member";
        public const string ROLE_ADMIN = "Admin";
    }

    public class TokenConfigurations
    {
        public string Audience { get; set; }
        public string Issuer { get; set; }
        public int Seconds { get; set; }
    }
}
