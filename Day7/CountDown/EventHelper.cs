using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Threading;

namespace CountDown
{
    public static class EventHelper
    {
        public static void Raise<T>(this T e, EventHandler<T> handler, Object sender = null) where T : EventArgs
        {
            var local = handler;
            if (local != null) 
                local(sender, e);
        }

    }
}
