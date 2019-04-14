using Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncExt
{
    class Program
    {
        static void Main(string[] args)
        {
            EventHandler h = new EventHandler(MyEventHandler);
            AsyncCaller ac = new AsyncCaller(h);

            Console.WriteLine("\ntime limit: 1000 ms: ");
            bool completedOK = ac.Invoke(1000, null, EventArgs.Empty);

            Console.WriteLine("\ntime limit: 5000 ms: ");
            completedOK = ac.Invoke(5000, null, EventArgs.Empty);

            Console.Write("\nPress any key..");
            Console.ReadKey();
        }

        private static void MyEventHandler(object sender, EventArgs e)
        {
            for (int i = 0; i < 30; i++)
            {
                Console.Write(i + " ");
                Thread.Sleep(100);
            }

           // Console.ReadKey();
        }

    }
}
