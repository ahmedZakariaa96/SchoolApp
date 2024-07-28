using Microsoft.IdentityModel.Tokens;
using School.Application.Base.Shared.Authentication;
using School.Domain.Entities;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Text;

namespace School.Application.Handlers.Authentication.Services
{
    public class AuthenticationServiceAction : IAuthenticationServiceAction
    {
        private readonly JwtSettings jwtSettings;

        public AuthenticationServiceAction(JwtSettings _jwtSettings)
        {
            jwtSettings = _jwtSettings;
        }
        public async Task<string> GetJWTToken(User user)
        {
            var claims = new List<Claim>()
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.NameIdentifier,user.UserName),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim("PhoneNumber",user.PhoneNumber),
                new Claim("Id",user.Id),

            };
            var jwtToken = new JwtSecurityToken(
               jwtSettings.Issuer,
               jwtSettings.Audience,
               claims,
               expires: DateTime.Now.AddDays(jwtSettings.AccessTokenExpireDate),
               signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)), SecurityAlgorithms.HmacSha256Signature));
            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);

            return accessToken;
        }
    }
}
