using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Try.Application.Student;
using Try.Core.Student;

namespace Try.Wcf
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码和配置文件中的类名“StudentService”。
    public class StudentService : IStudentService
    {
        private readonly IStudentAppService _studentAppService;

        public StudentService(IStudentAppService studentAppService)
        {
            _studentAppService = studentAppService;
        }

        public List<Student> GetTest()
        {
            throw new NotImplementedException();
        }

        public int InsertTest()
        {
            throw new NotImplementedException();
        }
    }
}
