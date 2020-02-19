using MediatR;
using MyAppCQRS.Domain.Core.Responses;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyAppCQRS.Domain.Command.RegisterAccount
{
    public class RegisterAccountCommand : IRequest<Response>
    {
        public string Name { get; set; }
        public string Email { get; set; }
        public string Password { get; set; }
    }
}
