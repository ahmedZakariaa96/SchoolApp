using Microsoft.AspNetCore.Authorization;
using Microsoft.AspNetCore.Mvc;
using School.API.Controllers.Base;
using School.Application.Base.Shared;
using School.Application.Handlers.Authorization.Commends;

namespace School.API.Controllers.Security
{
    [Route("api/[controller]")]
    [ApiController]
    //[Authorize(Roles = "Admin,User")]
    [Authorize]

    public class AuthorizationController : ApiControllerBase
    {
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<Result<string>>> CreateRole(string roleName)
        {
            return Single(await CommandAsync(new CreateRole(roleName)));
        }




    }
}
