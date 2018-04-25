using Abp.EntityFramework;
using System.Data.Common;
using System.Data.Entity;

namespace Try.EntityFramework
{
    public class TryDbContext : AbpDbContext
    {
        public TryDbContext()
            : base("Default")
        {

        }

        public TryDbContext(string nameOrConnectionString)
            : base(nameOrConnectionString)
        {

        }

        //This constructor is used in tests
        public TryDbContext(DbConnection existingConnection)
            : base(existingConnection, false)
        {

        }

        public TryDbContext(DbConnection existingConnection, bool contextOwnsConnection)
            : base(existingConnection, contextOwnsConnection)
        {

        }

        public virtual IDbSet<Core.Student.Student> Students { get; set; }
    }
}