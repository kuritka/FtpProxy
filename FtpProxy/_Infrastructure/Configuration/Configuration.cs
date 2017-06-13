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

        private IConfigurationFactory _configurationFactory;

        public Configuration()
        {
            _configurationFactory = new ConfigurationFactory();
            BuildConfiguration();            
        }

        public IEnumerable<ConfigChannelSettings> ChannelSettings => _channelSettings;

        private void BuildConfiguration()
        {
            //use the factory
            var configFileName = _configurationFactory.GetConfigFileName();
            var configurationBuilder = new ConfigurationBuilder()            
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddInMemoryCollection(_defalutValues)
            .AddJsonFile($"{configFileName}", optional:false);
            //.AddEnvironmentVariables();

            var configuration = configurationBuilder.Build();

            _channelSettings = configuration.GetSection("channelsettings").Get<IEnumerable<ConfigChannelSettings>>();//.Bind(_channelSettings);
        }

    }
}