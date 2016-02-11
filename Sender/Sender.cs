using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Platform;
using System.Threading;

namespace Sender
{
    class Sender
    {
        static void Main(string[] args)
        {
            Task t = Task.Factory.StartNew(() =>
                {
                    XMLWorker xmlWorker = new XMLWorker("Send.txt");
                    MessageChain mg_chain = xmlWorker.readXML();
                    Message mg = null;

                    Console.WriteLine("Sender...");
                    while ((mg = mg_chain.extract()) != null)
                    {
                        Console.WriteLine("Press any key to send message!");
                        Console.ReadLine();
                        BinaryWorker bw = new BinaryWorker();
                        byte[] bytes = bw.messageToBytes(mg);
                        MessageSenderReceiver messageSender = new MessageSenderReceiver();
                        messageSender.sendBytesAsync(bytes, 30000);
                    }

                    Console.ReadLine();
                });
            t.Wait();
        }
    }
}
