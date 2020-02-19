using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAppCQRS.Domain.Core.Responses;
using System.Threading.Tasks;

namespace MyAppCQRS.Models
{
    public abstract class BaseController : ControllerBase
    {
        private readonly IMediator _mediator;
        public BaseController(IMediator mediator)
        {
            _mediator = mediator;
        }

        protected async Task<ActionResult<Response>> Execute(IRequest<Response> request)
        {
            return await _mediator.Send(request);
        }
    }
}
