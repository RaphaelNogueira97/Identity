using MediatR;
using MyAppCQRS.Domain.Core.Responses;

namespace MyAppCQRS.Domain.Command.Logout
{
    public class LogoutCommand : IRequest<Response>
    {
        public string Token { get; set; }
    }
}
