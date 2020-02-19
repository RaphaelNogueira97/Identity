using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using MyAppCQRS.Domain.Command.RegisterAccount;
using MyAppCQRS.Domain.Core.Responses;
using MyAppCQRS.Models;

namespace MyAppCQRS.Controllers
{
    [Route("api/account")]
    [ApiController]
    public class AccountController : BaseController
    {
        public AccountController(IMediator mediator) : base(mediator)
        {
        }

        [Authorize("Bearer")]
        [HttpPost]
        public async Task<ActionResult<Response>> Post(RegisterAccountCommand command)
        {
            return await Execute(command);
        }
    }
}