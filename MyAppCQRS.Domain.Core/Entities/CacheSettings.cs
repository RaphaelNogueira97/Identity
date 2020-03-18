using MyAppCQRS.Domain.Core.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyAppCQRS.Domain.Core.Entities
{
    public class CacheSettings
    {
        public string Host { get; set; }
        public string Port { get; set; }
        public string Password { get; set; }
        public string InstanceName { get; set; }
        public string AbsoluteExpirationInMinutes { get; set; }
        public string ConnectionString { get
            {
                var connectionString = $"{Host}:{Port}";

                if (!string.IsNullOrEmpty(Password))
                {
                    connectionString += $",password={Password}";
                }

                return connectionString;
            }
        }
    }
}
