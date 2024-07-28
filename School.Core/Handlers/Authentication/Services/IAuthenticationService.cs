using School.Domain.Entities;

namespace School.Application.Handlers.Authentication.Services
{
    public interface IAuthenticationServiceAction
    {
        public Task<string> GetJWTToken(User user);
    }
}
