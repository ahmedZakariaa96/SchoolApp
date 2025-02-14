﻿using Microsoft.AspNetCore.Mvc;
using School.API.Controllers.Base;
using School.Application.Base.Shared;
using School.Application.Base.Wrapper;
using School.Application.DTO;
using School.Application.Handlers.StudentFeature.Commends;
using School.Application.Handlers.StudentFeature.DatabaseObjects;
using School.Application.Handlers.StudentFeature.Queries;
using School.Domain.Entities.View;

namespace School.API.Controllers
{
    [Route("api/[controller]")]
    [ApiController]
    public class StudentController : ApiControllerBase
    {


        [HttpPost]
        [Route("GetAll")]
        public async Task<ActionResult<Result<PaginatedResult<StudentDTO>>>> GetAll(PaginatedRquest paginatedRquest)
        {
            return Single(await QueryAsync(new GetAllStudent(paginatedRquest.PageNumber, paginatedRquest.PageSize, paginatedRquest.OrderBy)));
        }
        [HttpGet]
        [Route("GetById")]
        public async Task<ActionResult<Result<StudentDTO>>> GetById(int Id)
        {
            return Single(await QueryAsync(new GetStudentById(Id)));
        }
        [HttpPost]
        [Route("Create")]
        public async Task<ActionResult<Result<string>>> AddStudent(CreateStudent createStudent)
        {
            return Single(await CommandAsync(createStudent));
        }
        [HttpPut]
        [Route("Update")]
        public async Task<ActionResult<Result<string>>> UpdateStudent(UpdateStudent updateStudent)
        {
            return Single(await CommandAsync(updateStudent));
        }
        [HttpDelete]
        [Route("Delete")]
        public async Task<ActionResult<Result<string>>> DeleteStudent(int id)
        {
            return Single(await CommandAsync(new DeleteStudent(id)));
        }
        //----------------------------------------------------------

        [HttpPost]
        [Route("GetAllStudentVW")]
        public async Task<ActionResult<Result<PaginatedResult<VW_Student>>>> GetAllStudentVW(GetAllStudentVW getAllStudentVW)
        {
            return Single(await QueryAsync(getAllStudentVW));
        }

        [HttpPost]
        [Route("GetStudentByIdPRC")]
        public async Task<ActionResult<Result<VW_Student?>>> GetStudentByIdPRC(GetStudentByIdPRC getStudentByIdPRC)
        {
            return Single(await QueryAsync(getStudentByIdPRC));
        }

        [HttpPost]
        [Route("GetStudentDataFNById")]
        public async Task<ActionResult<Result<VW_Student?>>> GetStudentDataFNById(GetStudentDataFNById getStudentDataFNById)
        {
            return Single(await QueryAsync(getStudentDataFNById));
        }
    }
}
