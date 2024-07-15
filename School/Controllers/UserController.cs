using Microsoft.AspNetCore.Mvc;
using School.API.Controllers.Base;
using School.Application.Base.Shared;
using School.Application.Base.Wrapper;
using School.Application.DTO;
using School.Application.Handlers.ApplicationUser.Commands;
using School.Application.Handlers.ApplicationUser.Queries;

namespace School.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class UserController : ApiControllerBase
    {
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<Result<string>>> AddStudent(CreateUser createUser)
        {
            return Single(await CommandAsync(createUser));
        }

        [HttpPost]
        [Route("GetAll")]
        public async Task<ActionResult<Result<PaginatedResult<UserDTO>>>> GetAll(PaginatedRquest paginatedRquest)
        {
            return Single(await QueryAsync(new GetAllUser(paginatedRquest.PageNumber, paginatedRquest.PageSize)));
        }

        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult<Result<UserDTO>>> GetById(string Id)
        {
            return Single(await QueryAsync(new GetUserById(Id)));
        }
        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult<Result<string>>> UpdateUser(UpdateUser updateUser)
        {
            return Single(await CommandAsync(updateUser));
        }

        [HttpPut]
        [Route("ChangePassword")]
        public async Task<ActionResult<Result<string>>> ChangePassword(ChangePassword changePassword)
        {
            return Single(await CommandAsync(changePassword));
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult<Result<string>>> DeleteUser(string id)
        {
            return Single(await CommandAsync(new DeleteUser(id)));
        }

    }
}
