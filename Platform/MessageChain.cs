using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace Platform
{
    [Serializable]
    public class MessageChain
    {
        public List<Message> messages = new List<Message>();
        //public Mutex mut = new Mutex();
        
        public void add(Message m)
        {
            //mut.WaitOne();
            {
                if (m != null)
                {
                    messages.Add(m);
                }
            }
           // mut.ReleaseMutex();
        }

        public Message extract()
        {
            Message m = null;
            //mut.WaitOne();
            {
                if (messages.Count > 0)
                {
                    m = messages[0];
                    messages.RemoveAt(0);
                }
            }
            //mut.ReleaseMutex();
            return m;
        }
    }
}
