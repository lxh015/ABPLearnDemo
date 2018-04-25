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
        IList<Core.Student.Student> GetStudentsByAge(int? age);

        Core.Student.Student InsertNew(Core.Student.Student student);
    }
}
