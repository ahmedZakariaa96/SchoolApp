using School.Domain.Entities;
using School.Infrestructure.Persistence.Repositories.Base.Mappings;
using System;
using System.Collections.Generic;
using System.ComponentModel.DataAnnotations;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace School.Application.DTO
{
    public class DepartmentDTO:IMapFrom<Department>
    {
         public int DepId { get; set; }
         public   string? Name { get; set; }

    }
}
