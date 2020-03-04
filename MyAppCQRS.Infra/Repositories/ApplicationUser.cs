using Microsoft.AspNetCore.Identity;
using MyAppCQRS.Domain.Core.Entities;
using System.Text.Json;

namespace MyAppCQRS.Infra.Repositories
{
    public class ApplicationUser : IdentityUser
    {
        public string Role { get; set; }

        public void InitializeUser()
        {
            Role = Roles.ROLE_MEMBER;
            EmailConfirmed = false;
            NormalizedUserName = UserName.ToUpperInvariant();
            NormalizedEmail = Email.ToUpperInvariant();
            PhoneNumberConfirmed = PhoneNumber != null ? true : false;
        }

        public string ToJson()
        {
            return JsonSerializer.Serialize(this);
        }
    }
}
