using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Caching.Distributed;
using MyAppCQRS.Domain.Core.Entities;
using MyAppCQRS.Domain.Core.Helper;
using MyAppCQRS.Domain.Core.Interfaces;
using MyAppCQRS.Domain.Core.Responses;
using MyAppCQRS.Infra.Repositories;
using MyAppCQRS.Models;
using System;
using System.Threading;
using System.Threading.Tasks;

namespace MyAppCQRS.Domain.Command.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, Response>
    {

        private readonly IMapper _mapper;
        private readonly IResponseService _response;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly ITokenService _tokenService;
        private readonly IDistributedCache _distributedCache;

        public LoginCommandHandler(
            IMapper mapper,
            IResponseService response,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ITokenService tokenService,
            IDistributedCache distributedCache)
        {
            _mapper = mapper;
            _response = response;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
            _distributedCache = distributedCache;
        }

        public async Task<Response> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);

            bool credenciaisValidas = false;
            if (user != null && !String.IsNullOrWhiteSpace(user.Email))
            {
                // Verifica a existência do usuário nas tabelas do
                // ASP.NET Core Identity
                var userIdentity = _userManager
                    .FindByEmailAsync(user.Email).Result;
                if (userIdentity != null)
                {
                    // Efetua o login com base no Id do usuário e sua senha
                    var resultadoLogin = _signInManager
                        .CheckPasswordSignInAsync(userIdentity, user.Password, false)
                        .Result;
                    if (resultadoLogin.Succeeded)
                    {
                        // Verifica se o usuário em questão possui acesso através das roles
                        credenciaisValidas = _userManager.IsInRoleAsync(
                            userIdentity, userIdentity.Role).Result;
                    }
                }           
            }

            if (credenciaisValidas)
            {
                var response = await _tokenService.CreateToken(user);

                var authResponse = response.Convert<AuthResponse>();
                await _distributedCache.SetStringAsync(authResponse.AccessToken, user.ToJson(), cancellationToken);
            }

            return _response.CreateResponse(null, false);
        }
    }
}
