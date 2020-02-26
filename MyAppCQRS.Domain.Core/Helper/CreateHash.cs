using Microsoft.AspNet.Identity;
using MyAppCQRS.Domain.Core.Interfaces;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyAppCQRS.Domain.Core.Helper
{
    public class HashService : IHashService
    {
        public string CreatePasswordHash(string password)
        {
            return new PasswordHasher().HashPassword(password);
        }

        public bool VerifyPasswordHash(string passwordHash, string password)
        {
            return new PasswordHasher().VerifyHashedPassword(passwordHash, password).Equals(PasswordVerificationResult.Success) ? true : false;
        }
    }
}
