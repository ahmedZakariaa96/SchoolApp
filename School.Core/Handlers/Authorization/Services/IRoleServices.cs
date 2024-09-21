namespace School.Application.Handlers.Authorization.Services
{
    public interface IRoleServices
    {
        public Task<bool> IsNameExist(string roleName);

    }
}
