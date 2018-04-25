using Abp.Modules;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Reflection;
using System.ServiceModel;
using System.Text;
using System.Threading.Tasks;

namespace Try
{
    [DependsOn(typeof(TryApplicationModule), typeof(TryCoreModule), typeof(TryDataModule))]
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

            IocManager.IocContainer.Register
                (
                     Component.For<Wcf.IStudentService>()
                     .ImplementedBy<Wcf.StudentService>()
                     .Named("StudentAppService")
                     .AsWcfService(new DefaultServiceModel().AddEndpoints(WcfEndpoint.BoundTo(basicHttpBinding)).Hosted().PublishMetadata())
                );

            var factory = new WindsorServiceHostFactory<Castle.Facilities.WcfIntegration.Rest.RestServiceModel>(IocManager.IocContainer.Kernel);
        }
    }
}
