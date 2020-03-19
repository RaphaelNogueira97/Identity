using AutoMapper;
using MyAppCQRS.Domain.Core.Interfaces;
using MyAppCQRS.Infra.Repositories;
using NSubstitute;
using NSubstitute.Extensions;
using NUnit.Framework;
using MyAppCQRS.Domain.Command.RegisterAccount;
using MediatR;
using System.Threading.Tasks;
using FluentAssertions;
using System.Threading;
using MyAppCQRS.Domain.Core.Responses;
using AutoFixture;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Options;
using Microsoft.Extensions.Logging;
using System;
using System.Collections.Generic;

namespace MyCQRSApp.Test.Command.Account
{
    public class AddNewAccountHandlerTest
    {
        private readonly IResponseService _responseService;
        private readonly IMapper _mapper;
        private readonly IHashService _hashService;
        protected static Fixture GetFixture = new Fixture();
        private readonly IMediator _mediator;
        private RegisterAccountCommandHandler _registeAccountHandler;
        private UserManager<ApplicationUser> _userManager;
        private readonly IOptions<IdentityOptions> _optionsAccessor;
        private readonly IPasswordHasher<ApplicationUser> _passwordHasher;
        private readonly IEnumerable<IUserValidator<ApplicationUser>> _userValidators;
        private readonly IEnumerable<IPasswordValidator<ApplicationUser>> _passwordValidators;
        private readonly ILookupNormalizer _keyNormalizer;
        private readonly IServiceProvider _services;
        private readonly ILogger<UserManager<ApplicationUser>> _logger;
        private readonly IUserRoleStore<ApplicationUser> _roleUser;

        public AddNewAccountHandlerTest()
        {
            _responseService = Substitute.For<IResponseService>();
            _mapper = Substitute.For<IMapper>();
            _hashService = Substitute.For<IHashService>();
            _mediator = Substitute.For<IMediator>();
            _optionsAccessor = Substitute.For<IOptions<IdentityOptions>>();
            _passwordHasher = Substitute.For<IPasswordHasher<ApplicationUser>>();
            _userValidators = Substitute.For<IEnumerable<IUserValidator<ApplicationUser>>>();
            _passwordValidators = Substitute.For<IEnumerable<IPasswordValidator<ApplicationUser>>>();
            _keyNormalizer = Substitute.For<ILookupNormalizer>();
            _services = Substitute.For<IServiceProvider>();
            _logger = Substitute.For<ILogger<UserManager<ApplicationUser>>>();
            _roleUser = Substitute.For<IUserRoleStore<ApplicationUser>>();
        }

        [SetUp]
        public void Setup()
        {
            _userManager = new UserManager<ApplicationUser>(_roleUser, _optionsAccessor, _passwordHasher, _userValidators, _passwordValidators, _keyNormalizer, new IdentityErrorDescriber(), _services, _logger);
            _registeAccountHandler = new RegisterAccountCommandHandler(_responseService, _userManager, _mapper, _hashService);
        }

        public T GetInstance<T>()
        {
            return GetFixture.Create<T>();
        }

        [Test]
        public async Task ShouldAddNewAccountFromCommand()
        {
            var accountCommand = GetInstance<RegisterAccountCommand>();
            var account = GetInstance<ApplicationUser>();
            var response = GetInstance<Response>();
            var identityResult = GetInstance<IdentityResult>();
 
            _mapper.Map<ApplicationUser>(accountCommand).Returns(account);

            _userManager.CreateAsync(account).Returns(identityResult);

            await _userManager.AddToRoleAsync(account, account.Role);

            _responseService.CreateResponse(account, true).Returns(response);

            _mediator.Configure().Send(accountCommand).Returns(response);

            var r = await _registeAccountHandler.Handle(accountCommand, CancellationToken.None);

            r.IsValid.Should().BeTrue();
        }
    }
}