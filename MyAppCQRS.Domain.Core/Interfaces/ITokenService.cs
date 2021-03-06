﻿using MyAppCQRS.Domain.Core.Entities;
using MyAppCQRS.Domain.Core.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyAppCQRS.Domain.Core.Interfaces
{
    public interface ITokenService
    {
        Task<Response> CreateToken(User use);
    }
}
