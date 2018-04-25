using Abp.Domain.Entities;
using Abp.EntityFramework;
using Abp.EntityFramework.Repositories;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Try.EntityFramework.EntityFramework.Repositories
{
    public abstract class TryRepositoryBase<TEntity,TPrimaryKey> : EfRepositoryBase<TryDbContext, TEntity, TPrimaryKey>
        where TEntity : class, IEntity<TPrimaryKey>
    {
        protected TryRepositoryBase(IDbContextProvider<TryDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }

    public abstract class TryRepositoryBase<TEntity> : EfRepositoryBase<TryDbContext, TEntity, int>
    where TEntity : class, IEntity<int>
    {
        protected TryRepositoryBase(IDbContextProvider<TryDbContext> dbContextProvider)
            : base(dbContextProvider)
        {

        }

        //add common methods for all repositories
    }
}
