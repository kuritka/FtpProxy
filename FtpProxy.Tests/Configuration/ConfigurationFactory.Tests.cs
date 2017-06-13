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
            IConfigurationFactory configurationFactory = new ConfigurationFactory();
            
            System.Environment.SetEnvironmentVariable(ConfigurationFactory.DefaultEnvironmentVariable,variable);

            var configFileName = configurationFactory.GetConfigFileName();
            
            return configFileName;
        }


    }


}
