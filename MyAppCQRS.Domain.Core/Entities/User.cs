using System;
using System.Collections.Generic;
using System.Text;
using System.Text.Json;

namespace MyAppCQRS.Domain.Core.Entities
{
    public class User : BaseClass<User>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }

        public override string ToJson()
        {
            return JsonSerializer.Serialize(GetUser());
        }

        private User GetUser()
        {
            return new User { Name = Name, Email = Email, Password = Password };
        }
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
