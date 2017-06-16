
using Microsoft.Extensions.Configuration;
using Microsoft.Extensions.Logging;


namespace FtpProxy.Infrastructure.Jobs
{
     public static class Logs{
         public static ILoggerFactory Factory = new LoggerFactory();

        public static void Init(IConfiguration configuration)
        {
           //  Factory.AddConsole(LogLevel.Warning, includeScopes: true);

        }

     }

}