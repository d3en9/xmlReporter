using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using xmlStorage;
using System.ComponentModel;
using System.Threading;

namespace xmlReporter
{
    class Program
    {
        static void Main(string[] args)
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
