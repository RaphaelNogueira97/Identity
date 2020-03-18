using MediatR;
using Microsoft.AspNetCore.Mvc;
using MyAppCQRS.Domain.Command.Logout;
using MyAppCQRS.Domain.Core.Interfaces;
using MyAppCQRS.Domain.Core.Responses;
using MyAppCQRS.Models;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Threading.Tasks;

namespace MyAppCQRS.Controllers
{
    public class LogoutController : BaseController
    {
        private readonly IResponseService _response;
        public LogoutController(
            IMediator mediator,
            IResponseService response) : base(mediator)
        {
            _response = response;
        }

        [HttpPost]
        public async Task<ActionResult<Response>> Post(LogoutCommand command)
        {
            return await Execute(command);
        }
    }
}
