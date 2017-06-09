using System.Collections.Generic;

namespace FtpProxy.Infrastructure.Configuration
{
    partial class Configuration 
    {
        //Default configurations when configuration in {*.json, .ini , environment vatriables, command line args} is not delivered!
        private readonly IDictionary<string,string> _defalutValues  = new Dictionary<string,string>
                    { 
                        ["name"]  = "Ftp proxy", 
                        ["1"]  = "123", 
                    };
    }

}