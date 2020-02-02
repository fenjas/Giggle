using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Automation
{
    class Program
    {
        static string autoFolder = @"c:\automation";
        static string pathToKafkaTests = @"C:\automation\kafka\Docker\setupKafka.cmd";
        static string pathToSpecFlowTests = @"C:\automation\specflow\runtests.cmd";
        static string usage = "Usage: automation -kafka -specflow";

        static void VerifyAutomationFolderExists()
        {
            if (!Directory.Exists(autoFolder)) throw new Exception($"{autoFolder} was not found. Please create it and compile the needed projects to it");
        }

        static void KafkaTests()
        {
            if (File.Exists(pathToKafkaTests))
            {
                System.Diagnostics.Process.Start(pathToKafkaTests).WaitForExit();
            }
        }

        static void SpecFlowTests()
        {
            if (File.Exists(pathToKafkaTests))
            {
                System.Diagnostics.Process.Start(pathToSpecFlowTests).WaitForExit();
            }
        }

        static void Main(string[] args)
        {
            try
            {
                VerifyAutomationFolderExists();
                
                if (args.Any())
                {
                    if (args[0].Equals("-specflow")) SpecFlowTests();
                    else
                    if (args[0].Equals("-kafka")) KafkaTests();
                    else 
                        Console.WriteLine(usage);
                }
                else 
                    throw new Exception(usage);
            }
            catch (Exception ex)
            {
                Console.WriteLine(ex.Message);
            }
        }
    }
}
