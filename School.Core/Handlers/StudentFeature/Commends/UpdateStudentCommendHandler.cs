using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using School.Application.Base.Shared;
using School.Application.Base.Shared.Resources;
using School.Domain.Entities;
using School.Infrestructure.Persistence.Repositories.Base.Mappings;
using School.Infrestructure.Persistence.Repositories.Base.UnitOfWork;

namespace School.Application.Handlers.StudentFeature.Commends
{
    public class UpdateStudent : IRequest<Result<string>>, IMapFrom<Student>
    {
        public int Id { get; set; }

        public string NameEn { get; set; }
        public string? NameAr { get; set; }
        public string Phone { get; set; }

        public string Address { get; set; }
        public int? DepartmentId { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Student, UpdateStudent>()
                .ForMember(des => des.DepartmentId, opt => opt.MapFrom(src => src.DepId))
                .ForMember(des => des.Id, opt => opt.MapFrom(src => src.StudId))
                .ReverseMap();
        }
    }
    internal class UpdateStudentCommendHandler : IRequestHandler<UpdateStudent, Result<string>>
    {
        private readonly IUnitOfWork unitOfWork;



        private readonly IMapper mapper;

        public UpdateStudentCommendHandler(IUnitOfWork unitOfWork, IMapper mapper, IStringLocalizer<ResourcesLocalization> stringLocalizer)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            Localizer = stringLocalizer;
        }

        public IStringLocalizer<ResourcesLocalization> Localizer { get; }

        public async Task<Result<string>> Handle(UpdateStudent request, CancellationToken cancellationToken)
        {
            var result = Result<string>.Info(null, StatusResult.Exist, Localizer[ResourcesLocalizationKeys.Exist]);

            var checkStudent = await this.unitOfWork.Repository<Student>().FindByCondition(x => x.StudId == request.Id).AnyAsync();
            if (checkStudent == false)
            {
                return Result<string>.Info(request.Id.ToString(), StatusResult.NotExists, Localizer[ResourcesLocalizationKeys.NotExists]);
            }
            else
            {
                var currentStudent = mapper.Map<Student>(request);
                this.unitOfWork.Repository<Student>().Update(currentStudent);
                result = await unitOfWork.CompleteAsync(cancellationToken) >= (int)StatusResult.Success ?
         Result<string>.Success(currentStudent.StudId.ToString(), Localizer[ResourcesLocalizationKeys.Save])
         : Result<string>.Falid(null, Localizer[ResourcesLocalizationKeys.Falid]);
            }
            return result;

        }
    }
}
