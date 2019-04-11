using Core.Common;
using Core.Common.Contracts;
using Microsoft.Extensions.DependencyInjection;
using System;
using System.Collections.Generic;
using System.Text;

namespace LibraryGBH.Business
{
    public class BusinessEngineFactory : IBusinessEngineFactory
    {
        private readonly IServiceProvider services;

        public BusinessEngineFactory(IServiceProvider services)
        {
            this.services = services;
        }

        public T GetBusinessEngine<T>() where T : IBusinessEngine
        {
            //Import instance of T from the DI container
            return services.GetService<T>();
        }
    }
}
