using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using Microsoft.EntityFrameworkCore;
using Microsoft.Extensions.Localization;
using School.Application.Base.Shared;
using School.Application.Base.Shared.Resources;
using School.Application.DTO;
using School.Domain.Entities;
using School.Infrestructure.Persistence.Repositories.Base.UnitOfWork;

namespace School.Application.Handlers.ApplicationUser.Queries
{

    public record GetUserById(string Id) : IRequest<Result<UserDTO>>;
    public class GetUserByIdQueryHandler : IRequestHandler<GetUserById, Result<UserDTO>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly UserManager<User> userManager;
        private readonly IStringLocalizer<ResourcesLocalization> localizer;

        public IMapper mapper { get; }

        public GetUserByIdQueryHandler(IUnitOfWork _unitOfWork, IMapper _mapper, UserManager<User> userManager, IStringLocalizer<ResourcesLocalization> _Localizer)
        {
            this.unitOfWork = _unitOfWork;
            this.mapper = _mapper;
            this.userManager = userManager;
            localizer = _Localizer;
        }


        public async Task<Result<UserDTO>> Handle(GetUserById request, CancellationToken cancellationToken)

        {

            var UserData = await this.userManager.Users.ProjectTo<UserDTO>(mapper.ConfigurationProvider).FirstOrDefaultAsync(x => x.Id == request.Id);

            //var UserData = await this.unitOfWork.Repository<User>()
            //    .FindByCondition(x => x.Id == request.Id)
            //    .ProjectTo<UserDTO>(mapper.ConfigurationProvider)
            //    .FirstOrDefaultAsync();

            if (UserData == null)
            {
                return Result<UserDTO>.Info(UserData, StatusResult.NotExists, localizer[ResourcesLocalizationKeys.NotExists]);

            }

            return Result<UserDTO>.Success(UserData);



        }
    }
}
