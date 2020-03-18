using MediatR;
using Microsoft.Extensions.Caching.Distributed;
using MyAppCQRS.Domain.Core.Interfaces;
using MyAppCQRS.Domain.Core.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace MyAppCQRS.Domain.Command.Logout
{
    public class LogoutCommandHandler : IRequestHandler<LogoutCommand, Response>
    {
        private IResponseService _responseService;
        private IDistributedCache _distributedCache;

        public LogoutCommandHandler(
            IResponseService responseService,
            IDistributedCache distributedCache)
        {
            _responseService = responseService;
            _distributedCache = distributedCache;
        }

        public async Task<Response> Handle(LogoutCommand request, CancellationToken cancellationToken)
        {
            await _distributedCache.RemoveAsync(request.Token, cancellationToken);

            return _responseService.CreateResponse();
        }
    }
}
