using CleanArchitecture.Domain.Account;
using Microsoft.AspNetCore.Identity;
using System;

namespace CleanArchitecture.Infra.Data.Identity
{
    public class SeedUserRoleInitial : ISeedUserRoleInitial
    {
        private readonly UserManager<ApplicationUser> _userManager;
        private readonly RoleManager<IdentityRole> _roleManager;
        public SeedUserRoleInitial(UserManager<ApplicationUser> userManager, RoleManager<IdentityRole> roleManager)
        {
            _userManager = userManager;
            _roleManager = roleManager;
        }
        public void SeedRoles()
        {
            throw new NotImplementedException();
        }

        public void SeedUsers()
        {
            throw new NotImplementedException();
        }
    }
}
