using Microsoft.EntityFrameworkCore;
using School.Domain.Entities;
using School.Infrestructure.Persistence.Repositories.Base.UnitOfWork;

namespace School.Application.Handlers.StudentFeature.Services
{
    public class StudentService : IStudentService
    {
        private readonly IUnitOfWork unitOfWork;

        public StudentService(IUnitOfWork unitOfWork)
        {
            this.unitOfWork = unitOfWork;
        }
        public async Task<bool> IsNameExist(string stdName)
        {
            var haveRecord = await this.unitOfWork.Repository<Student>().FindByCondition(x => x.Name == stdName).AnyAsync();
            return haveRecord;
        }
        public async Task<bool> IsNameExist(string stdName, int StudId)
        {
            var haveRecord = await this.unitOfWork.Repository<Student>().FindByCondition(x => x.Name == stdName && x.StudId != StudId).AnyAsync();
            return haveRecord;
        }
    }
}
