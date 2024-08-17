using Microsoft.IdentityModel.Tokens;
using School.Application.Base.Shared.Authentication;
using School.Application.DTO;
using School.Domain.Entities;
using School.Infrestructure.Persistence.Repositories.Base.UnitOfWork;
using System.IdentityModel.Tokens.Jwt;
using System.Security.Claims;
using System.Security.Cryptography;
using System.Text;

namespace School.Application.Handlers.Authentication.Services
{
    public class AuthenticationServiceAction : IAuthenticationServiceAction
    {
        private readonly JwtSettings jwtSettings;
        private readonly IUnitOfWork unitOfWork;


        public AuthenticationServiceAction(JwtSettings _jwtSettings, IUnitOfWork _unitOfWork)
        {
            jwtSettings = _jwtSettings;
            this.unitOfWork = _unitOfWork;
        }
        public async Task<JwtAuthResult> GetJWTToken(User user)
        {
            var claims = GetClaims(user);
            var (JwtSecurity, accessToken) = await CreatToken(claims);
            var refreshToken = GetRefreshToken(user.UserName);

            JwtAuthResult jwtAuthResult = new JwtAuthResult
            {
                AcessToken = accessToken,
                RefreshToken = refreshToken
            };

            var res = await AddUserRefreshToken(jwtAuthResult, user, JwtSecurity);
            return res >= 1 ? jwtAuthResult : new JwtAuthResult();

        }

        private List<Claim> GetClaims(User user)
        {
            return new List<Claim>()
            {
                new Claim(ClaimTypes.Name,user.UserName),
                new Claim(ClaimTypes.NameIdentifier,user.UserName),
                new Claim(ClaimTypes.Email,user.Email),
                new Claim("PhoneNumber",user.PhoneNumber),
                new Claim("Id",user.Id),

            };
        }
        private async Task<(JwtSecurityToken, string)> CreatToken(List<Claim> claims)
        {
            var jwtToken = new JwtSecurityToken(
              jwtSettings.Issuer,
              jwtSettings.Audience,
              claims,
              expires: DateTime.Now.AddDays(jwtSettings.AccessTokenExpireDate),
              signingCredentials: new SigningCredentials(new SymmetricSecurityKey(Encoding.ASCII.GetBytes(jwtSettings.Secret)), SecurityAlgorithms.HmacSha256Signature));
            var accessToken = new JwtSecurityTokenHandler().WriteToken(jwtToken);
            return (jwtToken, accessToken);
        }

        private RefreshToken GetRefreshToken(string username)
        {
            var refreshToken = new RefreshToken
            {
                ExpireAt = DateTime.Now.AddDays(jwtSettings.RefreshTokenExpireDate),
                UserName = username,
                TokenString = GenerateRefreshToken()
            };
            return refreshToken;

        }
        private string GenerateRefreshToken()
        {
            var randomNumber = new byte[32];
            var randomNumberGenrate = RandomNumberGenerator.Create();
            randomNumberGenrate.GetBytes(randomNumber);
            return Convert.ToBase64String(randomNumber);

        }

        private async Task<int> AddUserRefreshToken(JwtAuthResult jwtAuthResult, User user, JwtSecurityToken jwtSecurity)
        {
            var userRefreshToken = new UserRefreshToken
            {
                AddedTime = DateTime.Now,
                ExpiryDate = DateTime.Now.AddDays(jwtSettings.RefreshTokenExpireDate),
                IsUsed = false,
                IsRevoked = false,
                JwtId = jwtSecurity.Id,
                RefreshToken = jwtAuthResult.RefreshToken.TokenString,
                Token = jwtAuthResult.AcessToken,
                UserId = user.Id
            };

            this.unitOfWork.Repository<UserRefreshToken>().Create(userRefreshToken);
            var Response = await unitOfWork.CompleteAsync();
            return Response;


        }
    }
}
