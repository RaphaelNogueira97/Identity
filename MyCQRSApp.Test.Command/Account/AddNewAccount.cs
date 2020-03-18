using AutoMapper;
using MyAppCQRS.Domain.Core.Interfaces;
using MyAppCQRS.Infra.Repositories;
using NSubstitute;
using NUnit.Framework;
using Microsoft.AspNetCore.Identity;
using MyAppCQRS.Domain.Command.RegisterAccount;
using System;
using MediatR;
using System.Threading.Tasks;
using FluentAssertions;
using Microsoft.Extensions.Configuration;
using Moq;
using System.Threading;

namespace MyCQRSApp.Test.Command.Account
{
    public class Tests
    {
        //private readonly UserManager<ApplicationUser> _userManager;
        private readonly IResponseService _responseService;
        private readonly IMapper _mapper;
        private readonly IHashService _hashService;
        private readonly Mock<IMediator> _mediator;

        public Tests()
        {
            _responseService = Substitute.For<IResponseService>();
            _mapper = Substitute.For<IMapper>();
            _hashService = Substitute.For<IHashService>();
            _mediator = new Mock<IMediator>();
        }


        [SetUp]
        public void Setup()
        {
        }

        [Test]
        public async Task MustCreateValidAccount()
        {
            var account = GetInstance<RegisterAccountCommand>();
            account.Email = "TEste@teste.com";
            account.Name = "teste";
            account.Password = "12345678";

            await Task.CompletedTask;
        }


        public T GetInstance<T>()
        {
            return (T)Activator.CreateInstance(typeof(T));
        }
    }
}