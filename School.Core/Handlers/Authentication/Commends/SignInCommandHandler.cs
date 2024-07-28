using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using School.Application.Base.Shared;
using School.Application.Base.Shared.Resources;
using School.Application.Handlers.Authentication.Services;
using School.Domain.Entities;

namespace School.Application.Handlers.Authentication.Commends
{
    public class SignInCommand : IRequest<Result<string>>
    {
        public string UserName { get; set; }
        public string Password { get; set; }

    }
    public class SignInCommandHandler : IRequestHandler<SignInCommand, Result<string>>
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


        public async Task<Result<string>> Handle(SignInCommand request, CancellationToken cancellationToken)
        {
            var result = Result<string>.Info(request.UserName, StatusResult.NotExists, localizer[ResourcesLocalizationKeys.NotExists]);

            var user = await this.userManager.FindByNameAsync(request.UserName);
            if (user == null)
            {
                return result;
            }

            var signInResult = await this.signInManager.CheckPasswordSignInAsync(user, request.Password, false);
            if (!signInResult.Succeeded)
            {
                result = Result<string>.Falid(request.UserName, localizer[ResourcesLocalizationKeys.SignInMessages]);
            }


            var AccessToken = await AuthenticationService.GetJWTToken(user);

            return Result<string>.Success(AccessToken);


        }
    }
}
