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
            //services.AddTransient<IJob>(x => new CheckChannelsJob( x.GetRequiredService<FtpProxy.Infrastructure.Configuration.IConfiguration>().ChannelSettings ));
            services.AddTransient<IJob,CheckChannelsJob>();

            services.AddHangfire(c => c.UseMemoryStorage());
            services.BuildServiceProvider();
        }


        public void Configure(IApplicationBuilder app, IHostingEnvironment env, ILoggerFactory loggerFactory)
        {
            var configuration = app.ApplicationServices.GetService<FtpProxy.Infrastructure.Configuration.IConfiguration>();
            
            var settings = configuration.ChannelSettings;

            var x = app.UseHangfireServer();
            

            app.UseHangfireDashboard();
          
            app.Run(async context => await context.Response.WriteAsync("try http://localhost:5000/hangfire"));

            RecurringJob.AddOrUpdate<CheckChannelsJob>(
                 "check-channels",
                 d => app.ApplicationServices.GetService<CheckChannelsJob>().Execute() 
                ,Cron.Minutely);
            
            RecurringJob.Trigger("check-channels");
        }
    }
}