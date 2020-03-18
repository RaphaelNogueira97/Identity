using System.Threading.Tasks;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using MyAppCQRS.Domain.Command.RegisterAccount;
using MyAppCQRS.Domain.Core.Responses;
using MyAppCQRS.Infra.Repositories;
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

        [AllowAnonymous]
        [HttpPost]
        public async Task<ActionResult<Response>> Post(RegisterAccountCommand command,
            [FromServices] ApplicationDbContext context,
            [FromServices] UserManager<ApplicationUser> userManager,
            [FromServices] RoleManager<IdentityRole> roleManager)
        {
            return await Execute(command);
        }
    }
}