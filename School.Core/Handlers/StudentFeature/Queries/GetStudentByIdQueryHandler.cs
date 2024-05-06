using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.EntityFrameworkCore;
using School.Application.Base.Shared;
using School.Application.DTO;
using School.Domain.Entities;
using School.Infrestructure.Persistence.Repositories.Base.UnitOfWork;

namespace School.Application.Handlers.StudentFeature.Queries
{

    public record GetStudentById(int Id) : IRequest<Result<StudentDTO>>;
    public class GetStudentByIdQueryHandler : IRequestHandler<GetStudentById, Result<StudentDTO>>
    {
        private readonly IUnitOfWork unitOfWork;
        public IMapper mapper { get; }

        public GetStudentByIdQueryHandler(IUnitOfWork _unitOfWork, IMapper _mapper)
        {
            this.unitOfWork = _unitOfWork;
            this.mapper = _mapper;
        }


        public async Task<Result<StudentDTO>> Handle(GetStudentById request, CancellationToken cancellationToken)

        {


            //var res = await this.unitOfWork.Repository<Student>().GetByIdAsync(request.Id);
            //var studentData = mapper.Map<StudentDTO>(res);

            var studentData = await this.unitOfWork.Repository<Student>()
                .FindByCondition(x => x.StudId == request.Id)
                .ProjectTo<StudentDTO>(mapper.ConfigurationProvider)
                .FirstOrDefaultAsync();

            return Result<StudentDTO>.Success(studentData);



        }
    }
}
