using System;
using System.Collections.Generic;
using System.IO;
using Microsoft.Extensions.Configuration;
using FtpProxy.Infrastructure.Configuration.Entities;


namespace FtpProxy.Infrastructure.Configuration
{
    public partial class Configuration : IConfiguration
    {
        private  IEnumerable<ConfigChannelSettings> _channelSettings;

        public Configuration()
        {
            BuildConfiguration();
        }

        public IEnumerable<ConfigChannelSettings> ChannelSettings => _channelSettings;

        private void BuildConfiguration()
        {
            //use the factory
            var environment = Environment.GetEnvironmentVariable("PARAGRAPH_58");
            var configurationBuilder = new ConfigurationBuilder()            
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddInMemoryCollection(_defalutValues)
            .AddJsonFile("ChannelSettings.json", optional:true)
            .AddJsonFile($"ChannelSettings.{environment}.json", optional:true, reloadOnChange:false);
            //.AddEnvironmentVariables();

            var configuration = configurationBuilder.Build();

            _channelSettings = configuration.GetSection("channelsettings").Get<IEnumerable<ConfigChannelSettings>>();//.Bind(_channelSettings);
        }

    }
}