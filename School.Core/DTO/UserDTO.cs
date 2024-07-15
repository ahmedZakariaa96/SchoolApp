using AutoMapper;
using School.Domain.Entities;
using School.Infrestructure.Persistence.Repositories.Base.Mappings;

namespace School.Application.DTO
{
    public class UserDTO : IMapFrom<User>
    {
        public string Id { get; set; }

        public string FullName { get; set; }
        public string UserName { get; set; }
        public string Email { get; set; }
        public string? Address { get; set; }
        public string? Country { get; set; }
        public void mapping(Profile profile)
        {
            profile.CreateMap<User, UserDTO>()
            .ForMember(des => des.FullName, opt => opt.MapFrom(src => src.UserName)).ReverseMap();


        }
    }
}
