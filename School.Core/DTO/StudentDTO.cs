using School.Domain.Entities;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations.Schema;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using School.Infrestructure.Persistence.Repositories.Base.Mappings;
using AutoMapper;

namespace School.Application.DTO
{
    public class StudentDTO:IMapFrom<Student>
    {
        public int StudId { get; set; }
        public   string? Name { get; set; }
        public   string? Phone { get; set; }
        public   string? Address { get; set; }
        public string? DepName { get; set; }

         public void Mapping(Profile profile)
         {
                profile.CreateMap<Student, StudentDTO>()
               .ForMember(des => des.DepName, opt => opt.MapFrom(src => src.Department.Name));
         }

   
    }
}
