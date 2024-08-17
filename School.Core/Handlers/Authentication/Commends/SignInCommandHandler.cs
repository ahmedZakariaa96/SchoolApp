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
    public class SignInCommand : IRequest<Result<JwtAuthResult>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }

    }
    public class SignInCommandHandler : IRequestHandler<SignInCommand, Result<JwtAuthResult>>
    {
        private readonly UserManager<User> userManager;
        public IStringLocalizer<ResourcesLocalization> localizer { get; }
        public IAuthenticationServiceAction AuthenticationService { get; }

        private readonly SignInManager<User> signInManager;


        public SignInCommandHandler(UserManager<User> userManager, IStringLocalizer<ResourcesLocalization> _localizer, SignInManager<User> _signInManager, IAuthenticationServiceAction authenticationService)
        {
            this.userManager = userManager;
            this.localizer = _localizer;
            this.signInManager = _signInManager;
            AuthenticationService = authenticationService;
        }


        public async Task<Result<JwtAuthResult>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {

            var result = Result<JwtAuthResult>.Info(new JwtAuthResult(), StatusResult.NotExists, localizer[ResourcesLocalizationKeys.NotExists]);

            var user = await this.userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                return result;
            }

            var signInResult = await this.signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!signInResult.Succeeded)
            {
                result = Result<JwtAuthResult>.Falid(new JwtAuthResult(), localizer[ResourcesLocalizationKeys.SignInMessages]);
            }


            var jwtAuthResult = await AuthenticationService.GetJWTToken(user);

            return Result<JwtAuthResult>.Success(jwtAuthResult);


        }
    }
}
