using AutoMapper;
using MyAppCQRS.Domain.Command.Login;
using MyAppCQRS.Domain.Command.RegisterAccount;
using MyAppCQRS.Domain.Core.Entities;
using MyAppCQRS.Infra.Repositories;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyAppCQRS.Domain.Command.Profiles
{
    public class UserProfile : Profile
    {
        public UserProfile()
        {
            CreateMap<LoginCommand, User>();

            CreateMap<RegisterAccountCommand, ApplicationUser>()
                .ForMember(dest => dest.UserName, x => x.MapFrom(y => y.Name));
        }
    }
}
