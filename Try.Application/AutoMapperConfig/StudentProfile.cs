using AutoMapper;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Try.Application.AutoMapperConfig
{
    public class StudentProfile : Profile
    {
        public StudentProfile()
        {
            this.CreateMap<Core.Student.Student, Service.Application.Dto.Students.StudentDto>();
        }
    }
}
