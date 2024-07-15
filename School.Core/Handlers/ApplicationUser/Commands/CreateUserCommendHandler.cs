using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.Extensions.Localization;
using School.Application.Base.Shared;
using School.Application.Base.Shared.Resources;
using School.Domain.Entities;
using School.Infrestructure.Persistence.Repositories.Base.Mappings;

namespace School.Application.Handlers.ApplicationUser.Commands
{
    public class CreateUser : IRequest<Result<string>>, IMapFrom<User>
    {
        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
        public string? PhoneNumber { get; set; }
        public string Password { get; set; }
        public string ConfirmPassword { get; set; }

        public void mapping(Profile profile)
        {
            profile.CreateMap<CreateUser, User>().ReverseMap();
        }
    }

    public class CreateUserCommendHandler : IRequestHandler<CreateUser, Result<string>>
    {
        public IStringLocalizer<ResourcesLocalization> Localizer { get; }
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;

        public CreateUserCommendHandler(IMapper mapper, IStringLocalizer<ResourcesLocalization> _Localizer, UserManager<User> userManager)
        {
            this.mapper = mapper;
            Localizer = _Localizer;
            this.userManager = userManager;
        }
        public async Task<Result<string>> Handle(CreateUser request, CancellationToken cancellationToken)
        {
            var result = Result<string>.Info(null, StatusResult.Exist, Localizer[ResourcesLocalizationKeys.Exist]);

            var userFound = await this.userManager.FindByEmailAsync(request.Email);
            if (userFound != null)
            {
                result = Result<string>.Info(null, StatusResult.Exist, "Email " + Localizer[ResourcesLocalizationKeys.Exist]);

                return result;
            }

            userFound = await this.userManager.FindByNameAsync(request.UserName);
            if (userFound != null)
            {
                result = Result<string>.Info(null, StatusResult.Exist, "UserName " + Localizer[ResourcesLocalizationKeys.Exist]);

                return result;
            }

            var identityUser = mapper.Map<User>(request);
            var createResult = await this.userManager.CreateAsync(identityUser, request.Password);

            result = createResult.Succeeded ? Result<string>.Success(identityUser.Id.ToString(), Localizer[ResourcesLocalizationKeys.Save])
                : Result<string>.Falid(null, createResult.Errors.FirstOrDefault().Description.ToString());

            return result;


        }
    }
}
