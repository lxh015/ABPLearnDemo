using Abp.Application.Services;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Try.Application
{
    public abstract class TryAppServiceBase : ApplicationService
    {
        protected TryAppServiceBase()
        {
            LocalizationSourceName = Core.TryConsts.LocalizationSourceName;
        }
    }
}
