using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Cleverence
{
    public class AsyncCaller
    {
        private EventHandler _eventHandler;

        public AsyncCaller(EventHandler eventHandler)
        {
            _eventHandler = eventHandler;
        }

        public bool Invoke(int miliseconds, object? sender, EventArgs e)
        {
            if (miliseconds >= 0)
            {
                var task = Task.Run(() => _eventHandler.Invoke(sender, e));

                return task.Wait(miliseconds);
            }

            throw new ArgumentException("Time miliseconds cannot be less than 0");
        }
    }
}
