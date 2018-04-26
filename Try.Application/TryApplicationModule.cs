using Abp.AutoMapper;
using Abp.Modules;
using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.Text;
using System.Threading.Tasks;
using Try.Application.AutoMapperConfig;
using Try.Application.Student;

namespace Try
{
    [DependsOn(typeof(TryCoreModule), typeof(AbpAutoMapperModule))]
    public class TryApplicationModule : AbpModule
    {
        public override void PreInitialize()
        {
            base.PreInitialize();

            Configuration.Modules.AbpAutoMapper().Configurators.Add(cfg =>
            {
                cfg.AddProfile(new StudentProfile());
            });
        }

        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());
        }
    }
}
