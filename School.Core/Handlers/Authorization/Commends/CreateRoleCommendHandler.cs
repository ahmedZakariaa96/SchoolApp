using MediatR;
using Microsoft.AspNetCore.Identity;
using School.Application.Base.Shared;
using School.Domain.Entities.IdentityServer;

namespace School.Application.Handlers.Authorization.Commends
{
    public record CreateRole(string roleName) : IRequest<Result<string>>;

    public class CreateRoleCommendHandler : IRequestHandler<CreateRole, Result<string>>
    {
        private readonly RoleManager<Role> roleManager;

        public CreateRoleCommendHandler(RoleManager<Role> _roleManager)
        {
            roleManager = _roleManager;
        }


        public async Task<Result<string>> Handle(CreateRole request, CancellationToken cancellationToken)
        {
            Role role = new Role();
            role.Name = request.roleName;
            var res = await roleManager.CreateAsync(role);

            if (res.Succeeded)
            {
                return Result<string>.Success(role.Id);
            }
            else
            {
                return Result<string>.Falid(role.Name);

            }
        }
    }
}
