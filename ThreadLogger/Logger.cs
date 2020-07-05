using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace ThreadLogger
{
    public class Logger
    {
        string _Path;
        private object locker = new object();

        public Logger(string path)
        {
            _Path = path;
            CreateFileIfNotExtists();
        }

        private void CreateFileIfNotExtists()
        {
            if (!File.Exists(_Path))
            {
                using (FileStream fs = File.Create(_Path))
                {
                    byte[] title = new UTF8Encoding(true).GetBytes("Log File init comment \n");
                    fs.Write(title, 0, title.Length);
                }
            }
        }

        public void WriteErrorAsync(string error)
        {
            lock(locker)
            {
                File.AppendAllText(_Path, error + "\n");
            }
           
        }
    }
}
