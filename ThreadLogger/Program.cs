﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;
using System.IO;

namespace ThreadLogger
{
    class Program
    {
        static void Main(string[] args)
        {            
            string path = "logfile.txt";
            Logger logger = new Logger(path);
            Parallel.For(0, 30, index => {
                try
                {
                    ThreadFunction.GeneratingErrors(Task.CurrentId);
                }
                catch (Exception e)
                {
                    logger.WriteErrorAsync(e.Message);
                }

            });         
                         

        }

     
    }
}