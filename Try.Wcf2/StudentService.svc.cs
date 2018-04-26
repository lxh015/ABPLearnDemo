using Abp.Dependency;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization;
using System.ServiceModel;
using System.Text;
using Try.Application.Student;
using Try.Core.Student;

namespace Try.Wcf2
{
    // 注意: 使用“重构”菜单上的“重命名”命令，可以同时更改代码、svc 和配置文件中的类名“StudentService”。
    // 注意: 为了启动 WCF 测试客户端以测试此服务，请在解决方案资源管理器中选择 StudentService.svc 或 StudentService.svc.cs，然后开始调试。
    public class StudentService : IStudentService
    {
        // private readonly IIocResolver _iocResolver;
        private readonly IStudentAppService _studentAppService;

        public StudentService(IStudentAppService studentAppService)//IStudentAppService studentAppService
        {
            _studentAppService = studentAppService;
            // _iocResolver = iocResolver;
        }

        public List<Service.Application.Dto.Students.StudentDto> GetTest()
        {
            return _studentAppService.GetStudentsByAge(null).ToList();
        }

        public long InsertTest()
        {
            return _studentAppService.InsertNew(new Student() { Age = 1, Name = "test", Sex = "男" }).Id;
        }
    }
}
