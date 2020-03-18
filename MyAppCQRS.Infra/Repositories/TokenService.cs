using Microsoft.IdentityModel.Tokens;
using MyAppCQRS.Domain.Core.Entities;
using MyAppCQRS.Domain.Core.Interfaces;
using MyAppCQRS.Domain.Core.Responses;
using MyAppCQRS.Models;
using System;
using System.Collections.Generic;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Principal;
using System.Text;
using System.Threading.Tasks;

namespace MyAppCQRS.Infra.Repositories
{
    public class TokenService : ITokenService
    {
        private IResponseService _responseService;
        private readonly SigningConfigurations _signingConfigurations;
        private readonly TokenConfigurations _tokenConfigurations;
        private readonly IResponseService _response;

        public TokenService(
            IResponseService responseService,
            SigningConfigurations signingConfigurations,
            TokenConfigurations tokenConfigurations,
            IResponseService response)
        {
            _responseService = responseService;
            _signingConfigurations = signingConfigurations;
            _tokenConfigurations = tokenConfigurations;
            _response = response;
        }

        public async Task<Response> CreateToken(User user)
        {
            ClaimsIdentity identity = new ClaimsIdentity(
                    new GenericIdentity(user.Email, "Login"),
                    new[] {
                        new Claim(JwtRegisteredClaimNames.Jti, Guid.NewGuid().ToString("N")),
                        new Claim(JwtRegisteredClaimNames.Email, user.Email)
                    }
                );

            DateTime dataCriacao = DateTime.Now;
            DateTime dataExpiracao = dataCriacao +
                TimeSpan.FromSeconds(_tokenConfigurations.Seconds);

            var handler = new JwtSecurityTokenHandler();
            var securityToken = handler.CreateToken(new SecurityTokenDescriptor
            {
                Issuer = _tokenConfigurations.Issuer,
                Audience = _tokenConfigurations.Audience,
                SigningCredentials = _signingConfigurations.SigningCredentials,
                Subject = identity,
                NotBefore = dataCriacao,
                Expires = dataExpiracao
            });
            var token = handler.WriteToken(securityToken);

            return await _response.CreateResponse(new
            {
                authenticated = true,
                created = dataCriacao.ToString("yyyy-MM-dd HH:mm:ss"),
                expiration = dataExpiracao.ToString("yyyy-MM-dd HH:mm:ss"),
                accessToken = token,
                message = "OK"
            }, true);
        }
    }
}
