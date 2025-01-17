using Microsoft.AspNetCore.Mvc;
using School.API.Controllers.Base;
using School.Application.Base.Shared;
using School.Application.Handlers.Email.Commends;

namespace School.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class EmailController : ApiControllerBase
    {

        [HttpPost]
        [Route("SendEmail")]
        public async Task<ActionResult<Result<string>>> SendEmail([FromForm] SendEmail sendEmail)
        {
            return Single(await CommandAsync(sendEmail));
        }
    }
}
