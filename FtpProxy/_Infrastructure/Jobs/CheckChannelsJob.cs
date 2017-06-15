using System;
using FtpProxy.Infrastructure;


namespace FtpProxy.Infrastructure.Jobs
{

    public class CheckChannelsJob : IJob
    {
        public void Execute()
        {
            Console.WriteLine("\n\nRecurring Job\n\n");
        }
    }

}