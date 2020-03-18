using System;
using System.Collections.Generic;
using System.Text;

namespace MyAppCQRS.Domain.Core.Interfaces
{
    public interface IHashService
    {
        public string CreatePasswordHash(string password);
        public bool VerifyPasswordHash(string passwordHash, string password);
    }
}
