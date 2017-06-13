using Microsoft.Extensions.DependencyInjection;
using FtpProxy.Infrastructure;
using FtpProxy.Infrastructure.Configuration;
using System;

namespace FtpProxy
{
    public class Startup
    {
        private  IServiceCollection _services;

        public Startup()
        {
            _services = new ServiceCollection();
        }

        public IServiceProvider SetupServiceProvider()
        {
            _services.AddTransient<IConfigurationFactory,ConfigurationFactory>();
            _services.AddSingleton<FtpProxy.Infrastructure.Configuration.IConfiguration,Infrastructure.Configuration.Configuration>();
            var serviceProvider = _services.BuildServiceProvider();
            return serviceProvider;
        }

        
    }
}