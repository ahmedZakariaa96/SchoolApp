using AutoMapper;
using Dapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Base.Shared;
using School.Domain.Entities.View;
using School.Infrestructure.Persistence;
using School.Infrestructure.Persistence.Repositories.Base.UnitOfWork;
using System.Data;

namespace School.Application.Handlers.StudentFeature.DatabaseObjects
{
    public class GetStudentDataFNById : IRequest<Result<VW_Student?>>
    {
        public int StudId { get; set; }
    }
    public class GetStudentDataFNByIdQueryHandler : IRequestHandler<GetStudentDataFNById, Result<VW_Student?>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ApplicationDbContext _applicationDbContext;


        public GetStudentDataFNByIdQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ApplicationDbContext applicationDbContext)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this._applicationDbContext = applicationDbContext;
        }
        public async Task<Result<VW_Student?>> Handle(GetStudentDataFNById request, CancellationToken cancellationToken)
        {


            IDbConnection applicationConnection = _applicationDbContext.Database.GetDbConnection();
            applicationConnection.Open();
            var functionName = "GetStudentDataFN";
            var functionValues = new { StudId = request.StudId };

            using (var transaction = applicationConnection.BeginTransaction())
            {
                try
                {
                    var proceureData = (await applicationConnection.QueryAsync<VW_Student>(
                       $"SELECT * FROM {functionName}(@StudId)",
                       functionValues,
                       transaction

                   ));


                    return Result<VW_Student?>.Success(proceureData.FirstOrDefault());


                }
                catch (Exception ex)
                {

                    return Result<VW_Student?>.Success(null);
                }
            }



        }

        public async Task<Result<VW_Student?>> Handle2(GetStudentDataFNById request, CancellationToken cancellationToken)
        {
            try
            {
                //Execute the  function using EF Core

                var studentData = await _applicationDbContext.VW_Students
                    .FromSqlInterpolated($"SELECT * FROM GetStudentDataFN ({request.StudId})")
                    .ToListAsync(cancellationToken);


                return Result<VW_Student?>.Success(studentData.FirstOrDefault());
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return Result<VW_Student?>.Success(null);
            }
        }
        //----------------------------------------------------------------------------------------------------------------



    }
}
