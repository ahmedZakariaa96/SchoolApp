using AutoMapper;
using School.Domain.Entities;
using School.Infrestructure.Persistence.Repositories.Base.Mappings;

namespace School.Application.DTO
{
    public class StudentDTO : IMapFrom<Student>
    {
        public int StudId { get; set; }
        public string? Name { get; set; }
        public string? Phone { get; set; }
        public string? Address { get; set; }
        public string? DepName { get; set; }

        public void Mapping(Profile profile)
        {
            profile.CreateMap<Student, StudentDTO>()
           .ForMember(des => des.DepName, opt => opt.MapFrom(src => src.Department.Name))
           .ForMember(des => des.Name, opt => opt.MapFrom(src => src.Localizable(src.NameEn, src.NameAr)));

        }


    }
}
