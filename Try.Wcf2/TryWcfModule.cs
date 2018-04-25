using Abp.Modules;
using Abp.WebApi;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;
using Try.Wcf2;

namespace Try
{
    [DependsOn(typeof(TryApplicationModule), typeof(TryCoreModule), typeof(TryDataModule),typeof(AbpWebApiModule))]
    public class TryWcfModule : AbpModule
    {
        public override void Initialize()
        {
            IocManager.RegisterAssemblyByConvention(Assembly.GetExecutingAssembly());

            InitServices();
        }

        /// <summary>
        /// 注册WCF服务
        /// </summary>
        private void InitServices()
        {
            var basicHttpBinding = new BasicHttpBinding()
            {
                MaxBufferPoolSize = 2147483647,
                MaxBufferSize = 2147483647,
                MaxReceivedMessageSize = 2147483647,
            };

            var webHttpBinding = new WebHttpBinding()
            {
                MaxBufferPoolSize = 2147483647,
                MaxBufferSize = 2147483647,
                MaxReceivedMessageSize = 2147483647,
            };

            //IocManager.IocContainer.Register
            //    (
            //         Component.For<IStudentService>()
            //         .ImplementedBy<StudentService>()
            //         .Named("StudentService")
            //         .AsWcfService(new DefaultServiceModel().AddEndpoints(WcfEndpoint.BoundTo(basicHttpBinding)).Hosted().PublishMetadata())
            //    );

            var factory = new WindsorServiceHostFactory<Castle.Facilities.WcfIntegration.Rest.RestServiceModel>(IocManager.IocContainer.Kernel);
        }
    }
}
