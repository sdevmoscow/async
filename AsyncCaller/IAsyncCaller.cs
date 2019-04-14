using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Async
{
    public interface IAsyncCaller
    {
        bool Invoke(int duration, object sender, EventArgs e);
    }
}


