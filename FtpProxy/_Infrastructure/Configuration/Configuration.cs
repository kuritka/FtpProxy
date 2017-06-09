using System;
using System.IO;
using Microsoft.Extensions.Configuration;


namespace FtpProxy.Infrastructure.Configuration
{
    public partial class Configuration : IConfiguration
    {
        private readonly ChannelSettings _channelSettings;

        public Configuration()
        {
            _channelSettings = new ChannelSettings();
            BuildConfiguration();
        }

        public ChannelSettings ChannelSettings => _channelSettings;

        private void BuildConfiguration()
        {
            var configurationBuilder = new ConfigurationBuilder()            
            .SetBasePath(Directory.GetCurrentDirectory())
            .AddInMemoryCollection(_defalutValues)
            .AddJsonFile("ChannelSettings.json",true);

            var configuration = configurationBuilder.Build();

            configuration.GetSection("channelsettings").Bind(_channelSettings);
        }

    }
}