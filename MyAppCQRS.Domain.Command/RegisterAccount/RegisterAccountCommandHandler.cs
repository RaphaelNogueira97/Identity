using MediatR;
using MyAppCQRS.Domain.Core.Interfaces;
using MyAppCQRS.Domain.Core.Responses;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyAppCQRS.Domain.Command.RegisterAccount
{
    public class RegisterAccountCommandHandler : IRequestHandler<RegisterAccountCommand, Response>
    {
        private readonly IResponseService _responseService;

        public RegisterAccountCommandHandler(IResponseService responseService)
        {
            _responseService = responseService;
        }

        public async Task<Response> Handle(RegisterAccountCommand request, CancellationToken cancellationToken)
        {
            var teste = await Task.FromResult<string>(DateTime.Now.DayOfWeek.ToString());
            return await _responseService.CreateResponse(teste, true);
        }
    }
}
