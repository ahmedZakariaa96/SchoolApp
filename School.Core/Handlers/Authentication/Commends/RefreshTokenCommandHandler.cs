using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using School.Application.Base.Shared;
using School.Application.Base.Shared.Resources;
using School.Application.DTO;
using School.Application.Handlers.Authentication.Services;
using School.Domain.Entities;

namespace School.Application.Handlers.Authentication.Commends
{
    public class RefreshTokenCommand : IRequest<Result<JwtAuthResult>>
    {
        public string AcessToken { get; set; }
        public string RefreshToken { get; set; }
    }
    public class RefreshTokenCommandHandler : IRequestHandler<RefreshTokenCommand, Result<JwtAuthResult>>
    {
        private readonly IAuthenticationServiceAction authenticationServiceAction;
        private readonly UserManager<User> userManager;
        private readonly IStringLocalizer<ResourcesLocalization> stringLocalizer;

        public RefreshTokenCommandHandler(IAuthenticationServiceAction authenticationServiceAction, UserManager<User> userManager, IStringLocalizer<ResourcesLocalization> stringLocalizer)
        {
            this.authenticationServiceAction = authenticationServiceAction;
            this.userManager = userManager;
            this.stringLocalizer = stringLocalizer;
        }
        public async Task<Result<JwtAuthResult>> Handle(RefreshTokenCommand request, CancellationToken cancellationToken)
        {
            var jwtTokenResult = this.authenticationServiceAction.ReadJWTToken(request.AcessToken);
            if (jwtTokenResult.StatusResult == StatusResult.Falid)
            {
                return Result<JwtAuthResult>.Falid(null);
            }
            else
            {

                var userIdAndExpireDate = await authenticationServiceAction.ValidateDetails(jwtTokenResult.Data, request.AcessToken, request.RefreshToken);

                switch (userIdAndExpireDate)
                {

                    case ("AlgorithmIsWrong", null): return Result<JwtAuthResult>.Falid(null, "AlgorithmIsWrong");
                    case ("TokenIsNotExpired", null): return Result<JwtAuthResult>.Falid(null, "TokenIsNotExpired");
                    case ("RefreshTokenIsNotFound", null): return Result<JwtAuthResult>.Falid(null, "RefreshTokenIsNotFound");
                    case ("RefreshTokenIsExpired", null): return Result<JwtAuthResult>.Falid(null, "RefreshTokenIsExpired");
                }

                var (userId, expiredDate) = userIdAndExpireDate;
                var user = await userManager.FindByIdAsync(userId);

                if (user == null)
                {
                    return Result<JwtAuthResult>.Info(null, StatusResult.NotExists, stringLocalizer[ResourcesLocalizationKeys.NotExists]);

                }

                var result = await authenticationServiceAction.GetRefreshToken(user, jwtTokenResult.Data, expiredDate, request.RefreshToken);

                return Result<JwtAuthResult>.Success(result);
            }

        }
    }
}
