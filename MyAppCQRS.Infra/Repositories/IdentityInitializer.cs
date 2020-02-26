using Microsoft.AspNetCore.Identity;
using MyAppCQRS.Domain.Core.Entities;
using System;
using System.Collections.Generic;
using System.Text;

namespace MyAppCQRS.Infra.Repositories
{
    public class IdentityInitializer
    {
        private readonly ApplicationDbContext _context;
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;


        public IdentityInitializer(
            ApplicationDbContext context,
            UserManager<ApplicationUser> userManager,
            RoleManager<IdentityRole> roleManager)
        {
            _context = context;
            _userManager = userManager;
            _roleManager = roleManager;
        }

        public void Initialize()
        {
            if (_context.Database.EnsureCreated())
            {
                if (!_roleManager.RoleExistsAsync(Roles.ROLE_ADMIN).Result)
                {
                    var resultado = _roleManager.CreateAsync(
                        new IdentityRole(Roles.ROLE_ADMIN)).Result;
                    if (!resultado.Succeeded)
                    {
                        throw new Exception(
                            $"Erro durante a criação da role {Roles.ROLE_ADMIN}.");
                    }
                }
                if (!_roleManager.RoleExistsAsync(Roles.ROLE_MEMBER).Result)
                {
                    var resultado = _roleManager.CreateAsync(
                        new IdentityRole(Roles.ROLE_MEMBER)).Result;
                    if (!resultado.Succeeded)
                    {
                        throw new Exception(
                            $"Erro durante a criação da role {Roles.ROLE_MEMBER}.");
                    }
                }

                CreateUser(
                    new ApplicationUser()
                    {
                        UserName = "Raphael",
                        Email = "r.nogueira@hotmail.com.br",
                        EmailConfirmed = true,
                        Role = Roles.ROLE_ADMIN
                    }, "12345678", Roles.ROLE_ADMIN);

            }
        }

        private void CreateUser(
            ApplicationUser user,
            string password,
            string initialRole = null)
        {
            if (_userManager.FindByNameAsync(user.UserName).Result == null)
            {
                var resultado = _userManager
                    .CreateAsync(user, password).Result;

                if (resultado.Succeeded &&
                    !String.IsNullOrWhiteSpace(initialRole))
                {
                    _userManager.AddToRoleAsync(user, initialRole).Wait();
                }
            }
        }
    }
}
