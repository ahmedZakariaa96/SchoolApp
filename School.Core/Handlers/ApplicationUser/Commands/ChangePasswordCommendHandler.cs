using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using School.Application.Base.Shared;
using School.Application.Base.Shared.Resources;
using School.Domain.Entities;

namespace School.Application.Handlers.ApplicationUser.Commands
{


    public class ChangePassword : IRequest<Result<string>>
    {
        public string Id { get; set; }

        public string NewPassword { get; set; }
        public string OldPaasword { get; set; }



    }

    public class ChangePasswordCommendHandler : IRequestHandler<ChangePassword, Result<string>>
    {


        public IStringLocalizer<ResourcesLocalization> Localizer { get; }
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;

        public ChangePasswordCommendHandler(UserManager<User> userManager, IStringLocalizer<ResourcesLocalization> stringLocalizer)
        {
            Localizer = stringLocalizer;
            this.userManager = userManager;

        }
        public async Task<Result<string>> Handle(ChangePassword request, CancellationToken cancellationToken)
        {
            var result = Result<string>.Info(null, StatusResult.NotExists, Localizer[ResourcesLocalizationKeys.NotExists]);
            var userFound = await this.userManager.FindByIdAsync(request.Id);
            if (userFound == null)
            {

                return result;
            }
            var updateResult = await this.userManager.ChangePasswordAsync(userFound, request.OldPaasword, request.NewPassword);
            result = updateResult.Succeeded ? Result<string>.Success(userFound.Id.ToString(), Localizer[ResourcesLocalizationKeys.Save])
                : Result<string>.Falid(null, updateResult.Errors.FirstOrDefault().Description.ToString());

            return result;
        }
    }

}
