using MyAppCQRS.Domain.Core.Helper;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyAppCQRS.Domain.Core.Entities
{
<<<<<<< HEAD
    public class CacheSettings
=======
    public class CacheSettings : JsonParse<CacheSettings>
>>>>>>> Adjust login authentication and implements parcial cache
    {
        public string Host { get; set; }
        public string Port { get; set; }
        public string Password { get; set; }
        public string InstanceName { get; set; }
        public string AbsoluteExpirationInMinutes { get; set; }
<<<<<<< HEAD
<<<<<<< HEAD
=======
>>>>>>> adjust and implementation generic classes, but is broken application
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
<<<<<<< HEAD
=======
        public string ConnectionString { get; }
>>>>>>> Adjust login authentication and implements parcial cache
=======
>>>>>>> adjust and implementation generic classes, but is broken application
    }
}
