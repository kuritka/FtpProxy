using System;


namespace FtpProxy.Infrastructure.Configuration
{


    /*
       This factory has been created regarding by 
        At the time of .net core 2.0 preview 1 this didnt work properly!!!
            .AddJsonFile("ChannelSettings.json", optional:true)
            .AddJsonFile($"ChannelSettings.{environment}.json", optional:true, reloadOnChange:true);
        Configuration is still overlied instead of reloaded !!
        please check https://docs.microsoft.com/en-us/aspnet/core/fundamentals/configuration
    */
    public class ConfigurationFactory : IConfigurationFactory
    {

        public const string  DefaultEnvironmentVariable = "PARAGRAPH_58";
        string IConfigurationFactory.GetConfigFileName()
        {

            var environment = Environment.GetEnvironmentVariable(DefaultEnvironmentVariable);

            switch(environment)
            {
                case "PROD": return "ChannelSettings.PROD.json";

                case "UAT": return "ChannelSettings.UAT.json";
                
                default: return "ChannelSettings.json";
            }
        }
    }
}