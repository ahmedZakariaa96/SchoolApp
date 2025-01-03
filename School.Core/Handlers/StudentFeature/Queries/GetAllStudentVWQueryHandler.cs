using AutoMapper;
using MediatR;
using School.Application.Base.Shared;
using School.Application.Base.Wrapper;
using School.Domain.Entities.View;
using School.Infrestructure.Persistence.Repositories.Base.UnitOfWork;

namespace School.Application.Handlers.StudentFeature.Queries
{
    public class GetAllStudentVW : IRequest<Result<PaginatedResult<VW_Student>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetAllStudentVW(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
        }

    }
    public class GetAllStudentVWQueryHandler : IRequestHandler<GetAllStudentVW, Result<PaginatedResult<VW_Student>>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllStudentVWQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<Result<PaginatedResult<VW_Student>>> Handle(GetAllStudentVW request, CancellationToken cancellationToken)
        {


            var studentData = await this.unitOfWork.Repository<VW_Student>().FindAll().ToPaginatedListAsync(request.PageNumber, request.PageSize);

            return Result<PaginatedResult<VW_Student>>.Success(studentData);



        }



    }
}
