using Async;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace AsyncConsole
{
    class Program
    {
        static void Main(string[] args)
        {
            EventHandler h = new EventHandler(MyEventHandler);

            IAsyncCaller ac = new AsyncCaller(h);

            Enumerable.Range(0, 2)
                .Select(r => 2000 + r * 3000)
                .ToList()
                .ForEach(timeout =>
                {
                    Console.WriteLine($"\nTime limit: {timeout} ms: ");
                    bool completedOK = ac.Invoke(timeout, null, EventArgs.Empty);

                    Console.WriteLine(completedOK ?
                        "\nOperation finished successfully." :
                        $"\nOperation was canceled by time limit: {timeout} ms.");
                });

            Console.Write("\nPress any key..");
            Console.ReadKey();
        }

        private static void MyEventHandler(object sender, EventArgs e)
        {
            // duration is 3000 ms:
            for (int i = 0; i < 30; i++)
            {
                Console.Write(i + " ");
                Thread.Sleep(100);
            }
        }
    }
}
