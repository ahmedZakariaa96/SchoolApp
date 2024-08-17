using Microsoft.AspNetCore.Mvc;
using School.API.Controllers.Base;
using School.Application.Base.Shared;
using School.Application.DTO;
using School.Application.Handlers.Authentication.Commends;

namespace School.API.Controllers.Security
{
    [Route("api/[controller]")]
    [ApiController]
    public class AuthenticationController : ApiControllerBase
    {

        [HttpPost]
        [Route("SignInCommand")]
        public async Task<ActionResult<Result<JwtAuthResult>>> SignInCommand([FromForm] SignInCommand signInCommand)
        {
            return Single(await CommandAsync(signInCommand));
        }

    }
}
