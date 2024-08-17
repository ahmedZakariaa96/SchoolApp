using School.Application.DTO;
using School.Domain.Entities;

namespace School.Application.Handlers.Authentication.Services
{
    public interface IAuthenticationServiceAction
    {
        public Task<JwtAuthResult> GetJWTToken(User user);
    }
}
