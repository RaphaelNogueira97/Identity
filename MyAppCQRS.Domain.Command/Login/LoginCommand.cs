using MediatR;
using MyAppCQRS.Domain.Core.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyAppCQRS.Domain.Command.Login
{
    public class LoginCommand : IRequest<Response>
    {
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
