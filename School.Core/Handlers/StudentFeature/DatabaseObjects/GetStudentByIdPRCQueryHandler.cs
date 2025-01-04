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
    public class GetStudentByIdPRC : IRequest<Result<VW_Student?>>
    {
        public int StudId { get; set; }
    }
    public class GetStudentByIdPRCQueryHandler : IRequestHandler<GetStudentByIdPRC, Result<VW_Student?>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly ApplicationDbContext _applicationDbContext;


        public GetStudentByIdPRCQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, ApplicationDbContext applicationDbContext)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this._applicationDbContext = applicationDbContext;
        }
        public async Task<Result<VW_Student?>> Handle2(GetStudentByIdPRC request, CancellationToken cancellationToken)
        {


            IDbConnection applicationConnection = _applicationDbContext.Database.GetDbConnection();
            applicationConnection.Open();
            var procedureName = "GetStudentDataPRC";
            var procedureValues = new { StudId = request.StudId };

            using (var transaction = applicationConnection.BeginTransaction())
            {
                try
                {
                    var proceureData = (await applicationConnection.QueryAsync<VW_Student>(
                       procedureName,
                       procedureValues,
                       transaction,
                       null,
                       CommandType.StoredProcedure
                   ));


                    return Result<VW_Student?>.Success(proceureData.FirstOrDefault());


                }
                catch (Exception ex)
                {

                    return Result<VW_Student?>.Success(null);
                }
            }



        }

        public async Task<Result<VW_Student?>> Handle(GetStudentByIdPRC request, CancellationToken cancellationToken)
        {
            try
            {
                //Execute the stored procedure using EF Core

                var studentData = await _applicationDbContext.VW_Students
                    .FromSqlInterpolated($"EXEC GetStudentDataPRC @StudId = {request.StudId}")
                    .ToListAsync(cancellationToken);


                return Result<VW_Student?>.Success(studentData.FirstOrDefault());
            }
            catch (Exception ex)
            {
                // Log the exception if needed
                return Result<VW_Student?>.Success(null);
            }
        }


    }
}
