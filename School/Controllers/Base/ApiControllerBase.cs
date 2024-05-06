using MediatR;
using Microsoft.AspNetCore.Http;
using Microsoft.AspNetCore.Mvc;

namespace School.API.Controllers.Base
{
    [Route("api/[controller]")]
    [ApiController]
    public class ApiControllerBase : ControllerBase
    {
        private ISender _mediator = null!;
        protected ISender Mediator => _mediator ??= HttpContext.RequestServices.GetRequiredService<ISender>();
        protected async Task<TResult> QueryAsync<TResult>(IRequest<TResult> query)
        {
            return await Mediator.Send(query);
        }

        protected async Task<TResult> CommandAsync<TResult>(IRequest<TResult> command)
        {
            return await Mediator.Send(command);
        }
        protected ActionResult<T> Single<T>(T data)
        {
            if (data == null)
            return NotFound();

            return Ok(data);
        }
    }
}
