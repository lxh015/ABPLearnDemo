using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Try.Application.Student
{
    public interface IStudentAppService: IApplicationService
    {
        IList<Service.Application.Dto.Students.StudentDto> GetStudentsByAge(int? age);

        Service.Application.Dto.Students.StudentDto InsertNew(Core.Student.Student student);
    }
}
