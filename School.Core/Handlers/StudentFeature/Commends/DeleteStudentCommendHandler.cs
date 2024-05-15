using AutoMapper;
using MediatR;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using School.Application.Base.Shared;
using School.Application.Base.Shared.Resources;
using School.Domain.Entities;
using School.Infrestructure.Persistence.Repositories.Base.UnitOfWork;

namespace School.Application.Handlers.StudentFeature.Commends
{
    public record DeleteStudent(int Id) : IRequest<Result<string>>;

    internal class DeleteStudentCommendHandler : IRequestHandler<DeleteStudent, Result<string>>
    {
        private readonly IUnitOfWork unitOfWork;


        public IStringLocalizer<ResourcesLocalization> Localizer { get; }

        private readonly IMapper mapper;

        public DeleteStudentCommendHandler(IUnitOfWork unitOfWork, IMapper mapper, IStringLocalizer<ResourcesLocalization> _localizer)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            Localizer = _localizer;

        }
        public async Task<Result<string>> Handle(DeleteStudent request, CancellationToken cancellationToken)
        {
            using (var trans = this.unitOfWork.Repository<Student>().BeginTransaction())
            {

                try
                {
                    var result = Result<string>.Info(null, StatusResult.Exist, Localizer[ResourcesLocalizationKeys.Exist]);

                    var cureentStudent = await this.unitOfWork.Repository<Student>().FindByCondition(x => x.StudId == request.Id).FirstOrDefaultAsync();
                    if (cureentStudent == null)
                    {
                        return Result<string>.Info(request.Id.ToString(), StatusResult.NotExists, Localizer[ResourcesLocalizationKeys.NotExists]);
                    }
                    else
                    {
                        this.unitOfWork.Repository<Student>().Delete(cureentStudent);
                        result = await unitOfWork.CompleteAsync(cancellationToken) >= (int)StatusResult.Success ?
                                   Result<string>.Success(cureentStudent.StudId.ToString(), Localizer[ResourcesLocalizationKeys.Save])
                                   : Result<string>.Falid(null, Localizer[ResourcesLocalizationKeys.Falid]);

                    }
                    return result;
                }
                catch (Exception ex)
                {

                    trans.Rollback();
                    return Result<string>.Falid(ex.Message.ToString());
                }
            }


        }
    }
}
