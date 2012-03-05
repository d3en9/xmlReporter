using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xmlStorage;
using System.ComponentModel;
using System.Threading;
using log4net;
using System.IO;

namespace xmlReporter
{
    class Program
    {
        public static readonly ILog log = LogManager.GetLogger(typeof(Program));

        static void Main(string[] args)
        {
            //log4net.Config.DOMConfigurator.Configure();
            //log4net.Config.XmlConfigurator.Configure(new FileInfo(""));
            //log.Warn("WARN");
            TestInsert();
        }

        public static void TestInsert()
        {
            MongoDbHelper.Clear("xmlStorage");
            for (int i = 0; i < 500; i++)
            {
                MongoDbHelper.JsonInsert("xmlStorage", String.Format("{{number: {0}}}",i));
            }
        }

        public static void TestThreads()
        {
            for (int i = 0; i < 10; i++)
            {
                Thread t = new Thread(Work);
                t.Start("Thread" + i.ToString());
            }
            Console.ReadKey();
        }

        private static void Work(object nameT)
        {
            Thread.Sleep(2000);
            Console.WriteLine((string)nameT+": Collection Names");
            foreach (string name in MongoDbHelper.getCollectionNames())
            {
                Console.WriteLine((string)nameT + ": " + name);
            }            
        }

    }
}
