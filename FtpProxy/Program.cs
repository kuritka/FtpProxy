using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.DependencyInjection;


namespace FtpProxy
{
    class Program
    {

        static void Main(string[] args)
        {

           var serviceProvider = new Startup().SetupServiceProvider();

           var configuration = serviceProvider.GetService<FtpProxy.Infrastructure.Configuration.IConfiguration>();

           var settings = configuration.ChannelSettings;

           var file = Path.GetTempFileName();
            
           Console.WriteLine(file);
        }
    }
}

