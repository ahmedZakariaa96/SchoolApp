using School.Application.Base.Shared;
using School.Application.DTO;
using School.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;

namespace School.Application.Handlers.Authentication.Services
{
    public interface IAuthenticationServiceAction
    {
        public Task<JwtAuthResult> GetJWTToken(User user, List<string> roles);
        public Result<JwtSecurityToken> ReadJWTToken(string AcessToken);
        public Task<(string, DateTime?)> ValidateDetails(JwtSecurityToken jwtToken, string AccessToken, string RefreshToken);
        public Task<JwtAuthResult> GetRefreshToken(User user, JwtSecurityToken jwtToken, DateTime? expiryDate, string refreshToken, List<string> roles);

    }
}
