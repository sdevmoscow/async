using System;
using System.Collections.Generic;
using System.ComponentModel;
using System.Runtime.Remoting.Messaging;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Async
{
    public class AsyncCaller : IAsyncCaller
    {
        private static EventHandler handler;

        public AsyncCaller(EventHandler h)
        {
            handler = h;
        }

        public bool Invoke(int duration, object sender, EventArgs e)
        {

            IAsyncResult result = handler.BeginInvoke(sender, e, null, null);

            var timedTask = Task.Factory.StartNew(() =>
            {
                while (result.IsCompleted != true) ;
            });

            timedTask.Wait(duration);

            return result.IsCompleted;
        }
    }
}
