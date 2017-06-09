using System;
using System.Collections.Generic;

namespace FtpProxy.Infrastructure.Configuration
{

   public class ChannelSettings
   {

            public IEnumerable<FtpChannel> Ftp{get; set;}
            public IEnumerable<Channel> Local{get; set;}

            public class Channel 
            {
                public string Name {get; set;}
                public string In {get; set;}
                public string Out {get; set;}
            } 

            public class FtpChannel  : Channel
            {
                public string Host {get; set;}
                public int Port {get; set;}
            } 


     }
}