using System;
using System.Collections.Generic;
using System.Linq;
using System.Runtime.Serialization.Json;
using System.ServiceModel;
using System.ServiceModel.Description;
using System.Web;
using System.Web.Security;
using System.Web.SessionState;
using Abp.Castle.Logging.Log4Net;
using Abp.Web;
using Castle.Facilities.Logging;
using Castle.Facilities.WcfIntegration;
using Castle.MicroKernel.Registration;


namespace Triage.Server
{
    public class Global : AbpWebApplication<Try.TryWcfModule>
    {

        protected override void Application_Start(object sender, EventArgs e)
        {
            AbpBootstrapper.IocManager.IocContainer.AddFacility<LoggingFacility>(
             f => f.UseAbpLog4Net().WithConfig("log4net.config")
            );

            IServiceBehavior debugBehavior = new ServiceDebugBehavior { IncludeExceptionDetailInFaults = true  };

            AbpBootstrapper.IocManager.IocContainer.AddFacility<WcfFacility>()
                .Register(
                    Component.For<ErrorHandlerBehavior>().Attribute("scope").Eq(WcfExtensionScope.Services)
                );

            base.Application_Start(sender, e);
        }
    }
}