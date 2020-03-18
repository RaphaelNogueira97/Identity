using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using MyAppCQRS.Domain.Core.Entities;
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

        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IResponseService _response;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly SignInManager<ApplicationUser> _signInManager;
        private readonly SigningConfigurations _signingConfigurations;
        private readonly TokenConfigurations _tokenConfigurations;
        private readonly ITokenService _tokenService;

        public LoginCommandHandler(
            IUserRepository userRepository,
            IMapper mapper,
            IResponseService response,
            UserManager<ApplicationUser> userManager,
            SignInManager<ApplicationUser> signInManager,
            ITokenService tokenService)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _response = response;
            _userManager = userManager;
            _signInManager = signInManager;
            _tokenService = tokenService;
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
                return await _tokenService.CreateToken(user);

            return await _response.CreateResponse(null, false);
        }
    }
}
