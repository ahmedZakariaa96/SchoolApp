namespace School.Application.Handlers.StudentFeature.Services
{
    public interface IStudentService
    {
        public Task<bool> IsNameExist(string stdName);
        public Task<bool> IsNameExist(string stdName, int StudId);

    }
}
