using Microsoft.VisualStudio.TestTools.UnitTesting;
using FtpProxy.Infrastructure;
using FtpProxy.Infrastructure.Configuration;

namespace FtpProxy.Tests
{

    [TestClass]
    public class ConfigurationFactoryTest
    {
        [TestMethod]
        public void TestPROD()
        {
            var configFileName = TestEnvironment("PROD");

            Assert.AreSame(configFileName,"ChannelSettings.PROD.json");
        }


        [TestMethod]
        public void TestEMPTY()
        {
            var configFileName = TestEnvironment(string.Empty);

            Assert.AreSame(configFileName,"ChannelSettings.json");
        }


        private string TestEnvironment(string variable)
        {
            //https://msdn.microsoft.com/en-us/library/77zkk0b6(v=vs.110).aspx

            var tempVariable = System.Environment.GetEnvironmentVariable(ConfigurationFactory.DefaultEnvironmentVariable);

            try{
            
                IConfigurationFactory configurationFactory = new ConfigurationFactory();                        

                System.Environment.SetEnvironmentVariable(ConfigurationFactory.DefaultEnvironmentVariable,variable);

                var configFileName = configurationFactory.GetConfigFileName();

                return configFileName;
            } 
            finally
            {
                System.Environment.SetEnvironmentVariable(ConfigurationFactory.DefaultEnvironmentVariable,tempVariable);
            }                        
        }
    }
}
