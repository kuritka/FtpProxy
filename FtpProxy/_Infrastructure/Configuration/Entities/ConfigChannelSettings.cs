using System;
using System.Collections;
using System.Collections.Generic;

namespace FtpProxy.Infrastructure.Configuration.Entities
{

   public class ConfigChannelSettings 
   {
       
        public class ConfigSettings 
        {
                public ConfigChannelType Type {get; set;}
                public string Name {get; set;}
                public string Path {get; set;}
                public string Host {get; set;}
                public int Port {get; set;}
        } 

        public ConfigSettings From {get; set;}
        public ConfigSettings To {get; set;}
    }
}