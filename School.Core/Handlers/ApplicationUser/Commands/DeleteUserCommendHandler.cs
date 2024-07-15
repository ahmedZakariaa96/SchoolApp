using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using School.Application.Base.Shared;
using School.Application.Base.Shared.Resources;
using School.Domain.Entities;

namespace School.Application.Handlers.ApplicationUser.Commands
{
    public record DeleteUser(string Id) : IRequest<Result<string>>;

    public class DeleteUserCommendHandler : IRequestHandler<DeleteUser, Result<string>>
    {
        public IStringLocalizer<ResourcesLocalization> Localizer { get; }
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;

        public DeleteUserCommendHandler(UserManager<User> userManager, IMapper mapper, IStringLocalizer<ResourcesLocalization> stringLocalizer)
        {
            this.mapper = mapper;
            Localizer = stringLocalizer;
            this.userManager = userManager;

        }
        public async Task<Result<string>> Handle(DeleteUser request, CancellationToken cancellationToken)
        {
            var result = Result<string>.Info(null, StatusResult.NotExists, Localizer[ResourcesLocalizationKeys.NotExists]);

            var userFound = await this.userManager.FindByIdAsync(request.Id);


            if (userFound == null)
            {
                return result;
            }
            else
            {

                var deleteResult = await this.userManager.DeleteAsync(userFound);
                result = deleteResult.Succeeded ? Result<string>.Success(userFound.Id.ToString(), Localizer[ResourcesLocalizationKeys.Save])
                    : Result<string>.Falid(null, deleteResult.Errors.FirstOrDefault().Description.ToString());

            }
            return result;
        }
    }
}
