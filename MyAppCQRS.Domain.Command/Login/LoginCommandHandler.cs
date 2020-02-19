using AutoMapper;
using MediatR;
using MyAppCQRS.Domain.Core.Entities;
using MyAppCQRS.Domain.Core.Interfaces;
using MyAppCQRS.Domain.Core.Responses;
using System.Threading;
using System.Threading.Tasks;

namespace MyAppCQRS.Domain.Command.Login
{
    public class LoginCommandHandler : IRequestHandler<LoginCommand, Response>
    {
        private readonly IUserRepository _userRepository;
        private readonly IMapper _mapper;
        private readonly IResponseService _response;

        public LoginCommandHandler(
            IUserRepository userRepository,
            IMapper mapper,
            IResponseService response)
        {
            _userRepository = userRepository;
            _mapper = mapper;
            _response = response;
        }

        public async Task<Response> Handle(LoginCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<User>(request);
            return await _userRepository.Authentication(user);
        }
    }
}
