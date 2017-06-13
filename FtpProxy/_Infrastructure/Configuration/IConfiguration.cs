using System;
using System.Collections.Generic;
using FtpProxy.Infrastructure.Configuration.Entities;

namespace FtpProxy.Infrastructure.Configuration
{
    public interface IConfiguration
    {
        IEnumerable<ConfigChannelSettings> ChannelSettings{ get;  }
    }
}