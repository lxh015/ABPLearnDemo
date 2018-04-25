using Abp.Application.Services;
using Abp.Domain.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Try.Core.Student;

namespace Try.Application.Student
{
    public class StudentAppService : ApplicationService, IStudentAppService //,IApplicationService
    {
        private readonly IRepository<Core.Student.Student, long> _studentRepository;

        public StudentAppService(IRepository<Core.Student.Student, long> studentRepository)
        {
            _studentRepository = studentRepository;
        }

        public IList<Core.Student.Student> GetStudentsByAge(int? age)
        {
            var tmp = age.HasValue ?
                  _studentRepository.GetAll().Where(p => p.Age == age.Value).ToList()
                  : _studentRepository.GetAll().ToList();

            Console.WriteLine(tmp.Count);
            return tmp;
        }

        public Core.Student.Student InsertNew(Core.Student.Student student)
        {
            return _studentRepository.Insert(student);
        }
    }
}
