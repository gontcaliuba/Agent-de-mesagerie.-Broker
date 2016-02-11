using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform
{
    [Serializable]
    public class Message
    {
        public int port { get; set; }
        public string message { get; set; }

        public Message()
        {
        }
        public Message(int port, string message)
        {
            this.port = port;
            this.message = message;
        }
    }
}
