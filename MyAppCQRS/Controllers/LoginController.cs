using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.AspNetCore.Mvc;
using Microsoft.IdentityModel.Tokens;
using MyAppCQRS.Domain.Command.Login;
using MyAppCQRS.Domain.Core.Entities;
using MyAppCQRS.Domain.Core.Interfaces;
using MyAppCQRS.Domain.Core.Responses;
using MyAppCQRS.Infra.Repositories;
using MyAppCQRS.Models;
using System;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Threading.Tasks;

namespace MyAppCQRS.Controllers
{
    [Route("api/login")]
    [ApiController]
    public class LoginController : BaseController
    {
        private readonly IResponseService _response;
        public LoginController(IMediator mediator, IResponseService response) : base(mediator)
        {
            _response = response;
        }

        [HttpPost]
        public async Task<ActionResult<Response>> Post([FromBody]LoginCommand command)
        {
            return await Execute(command);

        }
    }
}