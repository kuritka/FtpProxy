﻿using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using Microsoft.Extensions.Configuration;


namespace FtpProxy
{
    class Program
    {

        static void Main(string[] args)
        {

           var configuration = new Infrastructure.Configuration.Configuration();

            var file = Path.GetTempFileName();
            
            Console.WriteLine(file);
        }
    }
}

