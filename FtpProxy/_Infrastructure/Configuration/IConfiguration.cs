using System;

namespace FtpProxy.Infrastructure.Configuration
{
    public interface IConfiguration
    {
        ChannelSettings ChannelSettings{ get;  }
    }
}