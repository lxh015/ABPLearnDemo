using Abp.Domain.Uow;
using Abp.EntityFramework;
using Abp.Modules;
using System.Data.Entity;
using System.Reflection;
using Try.EntityFramework;

namespace Try
{
    [DependsOn(typeof(AbpEntityFrameworkModule), typeof(TryCoreModule))]
    public class TryDataModule : AbpModule
    {
        public override void PreInitialize()
        {
            Configuration.DefaultNameOrConnectionString = "Default";
            Configuration.UnitOfWork.OverrideFilter(AbpDataFilters.MustHaveTenant, false);
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
            Database.SetInitializer<TryDbContext>(null);
        }
    }
}
