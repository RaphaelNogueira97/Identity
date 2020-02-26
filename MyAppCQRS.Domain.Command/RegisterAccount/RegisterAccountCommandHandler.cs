using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MyAppCQRS.Domain.Core.Interfaces;
using MyAppCQRS.Domain.Core.Responses;
using MyAppCQRS.Infra.Repositories;
using System.Threading;
using System.Threading.Tasks;

namespace MyAppCQRS.Domain.Command.RegisterAccount
{
    public class RegisterAccountCommandHandler : IRequestHandler<RegisterAccountCommand, Response>
    {
        private readonly IResponseService _responseService;
        private readonly ApplicationDbContext _context;
        private readonly Microsoft.AspNetCore.Identity.UserManager<ApplicationUser> _userManager;
        private readonly Microsoft.AspNetCore.Identity.RoleManager<IdentityRole> _roleManager;
        private readonly IMapper _mapper;
        private readonly IHashService _hashService;

        public RegisterAccountCommandHandler(IResponseService responseService,
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager,
            IMapper mapper,
            IHashService hashService)
        {
            _responseService = responseService;
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
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

            if (result.Succeeded)
                return await _responseService.CreateResponse(user, true);

            return await _responseService.CreateResponse(result.Errors, false);
        }
    }
}
