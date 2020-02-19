using MyAppCQRS.Domain.Core.Entities;
using MyAppCQRS.Domain.Core.Interfaces;
using MyAppCQRS.Domain.Core.Responses;
using System;
using System.Collections.Generic;
using System.Text;
using System.Threading.Tasks;

namespace MyAppCQRS.Infra.Repositories
{
    public class UserRepository : IUserRepository
    {
        private readonly ITokenService _tokenService;
        private readonly IResponseService _responseService;

        public UserRepository(
            ITokenService tokenService,
            IResponseService responseService)
        {
            _tokenService = tokenService;
            _responseService = responseService;
        }

        public async Task<Response> Authentication(User user)
        {
            return await _tokenService.CreateToken(user);
        }
    }
}
