using AutoMapper;
using AutoMapper.QueryableExtensions;
using MediatR;
using Microsoft.AspNetCore.Identity;
using School.Application.Base.Shared;
using School.Application.Base.Wrapper;
using School.Application.DTO;
using School.Domain.Entities;
using School.Infrestructure.Persistence.Repositories.Base.UnitOfWork;

namespace School.Application.Handlers.ApplicationUser.Queries
{
    public class GetAllUser : IRequest<Result<PaginatedResult<UserDTO>>>
    {
        public int PageNumber { get; set; }
        public int PageSize { get; set; }

        public GetAllUser(int pageNumber, int pageSize)
        {
            this.PageNumber = pageNumber;
            this.PageSize = pageSize;
        }

    }
    public class GetAllUserQueryHandler : IRequestHandler<GetAllUser, Result<PaginatedResult<UserDTO>>>
    {
        private readonly IUnitOfWork unitOfWork;
        private readonly IMapper mapper;
        private readonly UserManager<User> userManager;

        public GetAllUserQueryHandler(IUnitOfWork unitOfWork, IMapper mapper, UserManager<User> userManager)
        {
            this.unitOfWork = unitOfWork;
            this.mapper = mapper;
            this.userManager = userManager;
        }
        public async Task<Result<PaginatedResult<UserDTO>>> Handle(GetAllUser request, CancellationToken cancellationToken)
        {


            // var allData = this.unitOfWork.Repository<User>().FindAll().ProjectTo<UserDTO>(mapper.ConfigurationProvider);
            var allData = this.userManager.Users.ProjectTo<UserDTO>(mapper.ConfigurationProvider);

            var paginatedResult = new PaginatedResult<UserDTO>();
            if (allData != null)
            {

                paginatedResult = await allData.ToPaginatedListAsync(request.PageNumber, request.PageSize);
            }
            return Result<PaginatedResult<UserDTO>>.Success(paginatedResult);


        }



    }
}
