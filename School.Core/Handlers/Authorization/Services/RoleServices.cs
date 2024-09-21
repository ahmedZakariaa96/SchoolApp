
using Microsoft.AspNetCore.Identity;
using School.Domain.Entities.IdentityServer;

namespace School.Application.Handlers.Authorization.Services
{
    public class RoleServices : IRoleServices
    {
        private readonly RoleManager<Role> roleManager;

        public RoleServices(RoleManager<Role> roleManager)
        {
            this.roleManager = roleManager;
        }


        public Task<bool> IsNameExist(string roleName)
        {
            return roleManager.RoleExistsAsync(roleName);
        }
    }
}
