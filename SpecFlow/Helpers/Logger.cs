using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace SpecFlow.Helpers
{
    public class Logger
    {

        const string logsFolder = @"c:\automation\logs";

        public static void Log(string Message, bool sameline = false, bool nodate = false)
        {
            try
            {
                if (nodate == false) { Message = DateTime.Now + " --> " + Message; }
                
                if (!Directory.Exists(logsFolder))
                {
                    Directory.CreateDirectory(logsFolder);
                }

                string filepath = $@"{logsFolder}\specflow_{DateTime.Now.Date.ToShortDateString().Replace('/', '_')}.txt";
                if (!File.Exists(filepath))
                {
                    // Create a file to write to.   
                    using (StreamWriter sw = File.CreateText(filepath))
                    {
                        if (!sameline) sw.WriteLine(Message); else sw.Write(Message);
                    }
                }
                else
                {
                    using (StreamWriter sw = File.AppendText(filepath))
                    {
                        if (!sameline) sw.WriteLine(Message); else sw.Write(Message);
                    }
                }

                if (sameline) Console.Write(Message); else Console.WriteLine(Message);
            }
            catch (Exception ex)
            {
                Log(ex.Message);
            }
        }
    }
}
