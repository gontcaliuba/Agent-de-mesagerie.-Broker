using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Platform
{
    class Program
    {
        static void Main(string[] args)
        {
            MessageChain mch = new MessageChain();
            mch.add(new Message(1, "test1"));
            mch.add(new Message(2, "test2"));
            mch.add(new Message(3, "test3"));
            XMLWorker xmlw = new XMLWorker("test.txt");
            xmlw.writeXML(mch);
        }
    }
}
