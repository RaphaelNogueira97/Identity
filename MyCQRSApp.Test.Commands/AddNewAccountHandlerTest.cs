using AutoMapper;
using MyAppCQRS.Domain.Core.Interfaces;
using MyAppCQRS.Infra.Repositories;
using NSubstitute;
using NUnit.Framework;
using MyAppCQRS.Domain.Command.RegisterAccount;
using MediatR;
using System.Threading.Tasks;
using FluentAssertions;
using System.Threading;
using MyAppCQRS.Domain.Core.Responses;
using AutoFixture;

namespace MyCQRSApp.Test.Command.Account
{
    public class AddNewAccountHandlerTest : IRequestHandler<RegisterAccountCommand, Response>
    {
        private readonly IResponseService _responseService;
        private readonly IMapper _mapper;
        private readonly IHashService _hashService;
        protected static Fixture GetFixture = new Fixture();
        private IMediator _mediator;

        public AddNewAccountHandlerTest()
        {
            _responseService = Substitute.For<IResponseService>();
            _mapper = Substitute.For<IMapper>();
            _hashService = Substitute.For<IHashService>();
        }

        [SetUp]
        public void Setup()
        {
            _mediator = Substitute.For<IMediator>();
        }

        public T GetInstance<T>()
        {
            return GetFixture.Create<T>();
        }

        public async Task<Response> Handle(RegisterAccountCommand request, CancellationToken cancellationToken)
        {
            var user = _mapper.Map<ApplicationUser>(request);
            user.PasswordHash = _hashService.CreatePasswordHash(request.Password);
            user.InitializeUser();

            await Task.Delay(2);

            return _responseService.CreateResponse(user, true);
        }

        [Test]
        public async Task ShouldAddNewAccountFromCommand()
        {
            var accountCommand = GetInstance<RegisterAccountCommand>();
            var account = GetInstance<ApplicationUser>();

            _mapper.Map<ApplicationUser>(accountCommand).Returns(account);

            _responseService.CreateResponse(new { }, true).Returns(_responseService.CreateResponse(account));

            (await _mediator.Send(accountCommand, CancellationToken.None)).Returns(new Response(account, true));

            var resp = await Handle(accountCommand, CancellationToken.None);

            resp.IsValid.Should().BeTrue();
        }
    }
}