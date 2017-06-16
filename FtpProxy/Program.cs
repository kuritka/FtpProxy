using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using FtpProxy.Infrastructure.Jobs;
using Hangfire;
using Microsoft.AspNetCore;
using Microsoft.AspNetCore.Hosting;
using Microsoft.AspNetCore.Hosting.Internal;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace FtpProxy
{
    class Program
    {

        static void Main(string[] args)
        {
             BuildWebHost(args).Run();
             
             Console.WriteLine("Ftp Proxy started....");
        }

        public static IWebHost BuildWebHost(string[] args) => 
            WebHost.CreateDefaultBuilder(args).UseLoggerFactory(Logs.Factory).UseStartup<Startup>().Build();

    }



    public static class WebHostExtensions
    {
            public static void RunJobs(this IWebHost webhost){
                RecurringJob.AddOrUpdate(() => System.Console.WriteLine("Simple!"), Cron.Minutely);       
            }
    }
}

