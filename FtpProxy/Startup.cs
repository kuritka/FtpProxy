using Microsoft.Extensions.DependencyInjection;
using FtpProxy.Infrastructure;
using FtpProxy.Infrastructure.Configuration;
using System;
using Microsoft.AspNetCore.Hosting;
using Microsoft.Extensions.Logging;
using Microsoft.AspNetCore.Builder;
using System.Threading.Tasks;
using Hangfire;
using Hangfire.MemoryStorage;
using FtpProxy.Infrastructure.Jobs;
using Microsoft.AspNetCore.Http;

namespace FtpProxy
{
    public class Startup
    {

        public void ConfigureServices(IServiceCollection services)
        {
            services.AddTransient<IConfigurationFactory,ConfigurationFactory>();
            services.AddSingleton<FtpProxy.Infrastructure.Configuration.IConfiguration,Infrastructure.Configuration.Configuration>();
            services.AddHangfire(c => c.UseMemoryStorage());
            services.BuildServiceProvider();
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env)
        {
            var configuration = app.ApplicationServices.GetService<FtpProxy.Infrastructure.Configuration.IConfiguration>();
            
            var settings = configuration.ChannelSettings;

            app.UseHangfireServer();

            app.UseHangfireDashboard();
          
            app.Run(async context => await context.Response.WriteAsync("try http://localhost:5000/hangfire"));

            RecurringJob.AddOrUpdate<CheckChannelsJob>("check-channels",d => d.Execute() , Cron.Minutely);
        }
    }
}