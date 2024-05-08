using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using School.Application.Base.Shared;
using School.Application.Base.Wrapper;
using School.Application.DTO;
using School.Domain.Entities;
using School.Infrestructure.Persistence.Repositories.Base.UnitOfWork;

namespace School.Application.Handlers.StudentFeature.Queries
{
    public class GetAllStudent : IRequest<Result<PaginatedResult<StudentDTO>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }
        public OrderType? OrderBy { get; set; }

        public GetAllStudent(int pageNumber, int pageSize, OrderType? OrderBy)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
            this.OrderBy = OrderBy;
        }

    }
    public class GetAllStudentQueryHandler : IRequestHandler<GetAllStudent, Result<PaginatedResult<StudentDTO>>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;

        public GetAllStudentQueryHandler(IUnitOfWork unitOfWork, IMapper mapper)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
        }
        public async Task<Result<PaginatedResult<StudentDTO>>> Handle(GetAllStudent request, CancellationToken cancellationToken)
        {
            //this.unitOfWork.Repository<Student>().BeginTransaction();
            //this.unitOfWork.Repository<Student>().Commit();
            //this.unitOfWork.Repository<Student>().RollBack();


            //var res1 = await this.unitOfWork.Repository<Student>()
            //   .FindAll()
            //   .Include(x => x.Department)
            //   .ThenInclude(y=>y.DepartmetSubject)
            //   .ToListAsync();

            //var res2 = await this.unitOfWork.Repository<Student>()
            //  .FindByCondition(x=>x.StudId==1|| x.StudId == 2|| x.StudId == 3).ToListAsync();

            //var res3 = await this.unitOfWork.Repository<Student>()
            //.FindByConditionAsTracking(x => x.StudId == 1 || x.StudId == 2 || x.StudId == 3).ToListAsync();

            var allData = this.unitOfWork.Repository<Student>().FindAll().ProjectTo<StudentDTO>(mapper.ConfigurationProvider);
            var paginatedResult = new PaginatedResult<StudentDTO>();
            if (allData != null)
            {
                allData = allData.OrderBy(request.OrderBy);
                paginatedResult = await allData.ToPaginatedListAsync(request.PageNumber, request.PageSize);
            }
            if (request.OrderBy != null)
            {

            }


            return Result<PaginatedResult<StudentDTO>>.Success(paginatedResult);
        }



    }
}
