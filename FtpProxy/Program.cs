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

           var serviceProvider = new Startup().ConfigureServices();

           var configuration = serviceProvider.GetService<FtpProxy.Infrastructure.Configuration.IConfiguration>();

           var settings = configuration.ChannelSettings;

           foreach (var channel in settings)
           {
                System.Console.WriteLine(string.Format("{0} -> {1}",channel.From.Path, channel.To.Path));
           }

           var file = Path.GetTempFileName();
            
           Console.WriteLine(file);
        }
    }
}

