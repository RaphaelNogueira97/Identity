using AutoMapper;
using MyAppCQRS.Domain.Command.Login;
using MyAppCQRS.Domain.Core.Entities;
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
        }
    }
}
