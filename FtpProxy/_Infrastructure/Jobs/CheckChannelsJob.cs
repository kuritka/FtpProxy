using System;
using System.Collections.Generic;
using System.Linq;
using FtpProxy.Infrastructure;
using FtpProxy.Infrastructure.Configuration;
using FtpProxy.Infrastructure.Configuration.Entities;

namespace FtpProxy.Infrastructure.Jobs
{

    public class CheckChannelsJob : IJob
    {
        private readonly IEnumerable<ConfigChannelSettings> _channelSettings;

        public CheckChannelsJob(IConfiguration configuration)
        {
            if(configuration == null)  throw new ArgumentNullException($"{configuration}");
            _channelSettings =  configuration.ChannelSettings;
        }

        public void Execute()
        {
            System.Console.ForegroundColor = ConsoleColor.Cyan;
            System.Console.WriteLine("\n\n\n\nrunning....\n");
            if(!_channelSettings.Any()  ){
                throw new ArgumentException("FOOO!!!");
            }
            foreach(var channel in _channelSettings )
            {
                System.Console.WriteLine("FROM:{0}\nTO:{1}", channel.From.Name, channel.To.Name);
            }
            System.Console.WriteLine("\n\n\n\n");
            System.Console.ResetColor();
        }
    }

}