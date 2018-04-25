using Abp.Domain.Entities;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Try.Core.Student
{
    public class Student :Entity<long>
    {
        public string Name { get; set; }

        public int Age { get; set; }

        public string Sex { get; set; }

  
    }
}
