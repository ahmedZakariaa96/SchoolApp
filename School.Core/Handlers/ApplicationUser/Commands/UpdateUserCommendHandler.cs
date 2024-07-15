using AutoMapper;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using School.Application.Base.Shared;
using School.Application.Base.Shared.Resources;
using School.Domain.Entities;
using School.Infrestructure.Persistence.Repositories.Base.Mappings;

namespace School.Application.Handlers.ApplicationUser.Commands
{
    public class UpdateUser : IRequest<Result<string>>, IMapFrom<User>
    {
        public string Id { get; set; }

        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
        public string? PhoneNumber { get; set; }


        public void mapping(Profile profile)
        {
            profile.CreateMap<UpdateUser, User>().ReverseMap();
        }
    }

    public class UpdateUserCommendHandler : IRequestHandler<UpdateUser, Result<string>>
    {


        public IStringLocalizer<ResourcesLocalization> Localizer { get; }
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;

        public UpdateUserCommendHandler(UserManager<User> userManager, IMapper mapper, IStringLocalizer<ResourcesLocalization> stringLocalizer)
        {
            this.mapper = mapper;
            Localizer = stringLocalizer;
            this.userManager = userManager;

        }
        public async Task<Result<string>> Handle(UpdateUser request, CancellationToken cancellationToken)
        {
            var result = Result<string>.Info(null, StatusResult.NotExists, Localizer[ResourcesLocalizationKeys.NotExists]);

            var userFound = await this.userManager.Users.Where(r => r.Email == request.Email.ToString() && r.Id != request.Id).FirstOrDefaultAsync();

            if (userFound != null)
            {
                result = Result<string>.Info(null, StatusResult.Exist, Localizer[ResourcesLocalizationKeys.Exist]);
                return result;
            }

            userFound = await this.userManager.Users.Where(r => r.UserName == request.UserName.ToString() && r.Id != request.Id).FirstOrDefaultAsync();
            if (userFound != null)
            {
                result = Result<string>.Info(null, StatusResult.Exist, "UserName " + Localizer[ResourcesLocalizationKeys.Exist]);
                return result;
            }

            userFound = await this.userManager.FindByIdAsync(request.Id);

            if (userFound == null)
            {
                result = Result<string>.Info(null, StatusResult.Exist, Localizer[ResourcesLocalizationKeys.NotExists]);
                return result;
            }
            var identityUser = mapper.Map(request, userFound);
            var updateResult = await this.userManager.UpdateAsync(identityUser);
            result = updateResult.Succeeded ? Result<string>.Success(identityUser.Id.ToString(), Localizer[ResourcesLocalizationKeys.Save])
                : Result<string>.Falid(null, updateResult.Errors.FirstOrDefault().Description.ToString());

            return result;
            throw new NotImplementedException();
        }
    }
}
