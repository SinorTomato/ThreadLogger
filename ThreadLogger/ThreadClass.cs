using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadLogger
{
    public static class ThreadFunction
    {   
        public static void GeneratingErrors(int? threadId)
        {
            Random random = new Random();
            if (random.Next() % 10 > 2)
                    throw new Exception($"error from {threadId} thread at time :" + DateTime.Now);
                      
        }
        
    }
}
