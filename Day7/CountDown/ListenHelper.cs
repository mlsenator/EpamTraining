using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace CountDown
{
    public class ListenHelper
    {

        private IListener[] listeners;

        public ListenHelper(params IListener[] listeners)
        {
            this.listeners = listeners;
        }
        public void ListenAll()
        {
            foreach (var ls in listeners)
            {
                ls.Listen();
            }
        }
        public void StopListenAll()
        {
            foreach (var ls in listeners)
            {
                ls.StopListen();
            }
        }

        public void AddListener(IListener listener)
        {
            listener.Listen();
        }

        public void RemoveListener(IListener listener)
        {
            listener.StopListen();
        }
    }
}
