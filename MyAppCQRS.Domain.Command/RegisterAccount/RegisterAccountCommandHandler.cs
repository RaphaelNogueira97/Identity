using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MyAppCQRS.Domain.Core.Interfaces;
using MyAppCQRS.Domain.Core.Responses;
using MyAppCQRS.Infra.Repositories;
using System.Linq;
using System.Threading;
using System.Threading.Tasks;

namespace MyAppCQRS.Domain.Command.RegisterAccount
{
    public class RegisterAccountCommandHandler : IRequestHandler<RegisterAccountCommand, Response>
    {
        private readonly IResponseService _responseService;
        private readonly Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> _userManager;
        private readonly IMapper _mapper;
        private readonly IHashService _hashService;

        public RegisterAccountCommandHandler(IResponseService responseService,
            UserManager<ApplicationUser> userManager,
            IMapper mapper,
            IHashService hashService)
        {
            _responseService = responseService;
            _userManager = userManager;
            _mapper = mapper;
            _hashService = hashService;
        }

        public async Task<Response> Handle(RegisterAccountCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<ApplicationUser>(request);
            user.PasswordHash = _hashService.CreatePasswordHash(request.Password);
            user.InitializeUser();
            var result = await _userManager.CreateAsync(user);
            _userManager.AddToRoleAsync(user, user.Role).Wait();

            if (!result.Errors.Any())
                return _responseService.CreateResponse(user, true);

            return _responseService.CreateResponse(result.Errors, false);
        }
    }
}
