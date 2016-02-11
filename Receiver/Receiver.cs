using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Platform;

namespace Receiver
{
    class Receiver
    {
        static void Main(string[] args)
        {
            Task t = Task.Factory.StartNew(async () =>
                {
                    Console.WriteLine("Receiver...");
                    Console.WriteLine("Input my port number! ^_^");
                    int port = Convert.ToInt32(Console.ReadLine());

                    MessageSenderReceiver messageReceiver = new MessageSenderReceiver();
                    XMLWorker xmlWorker = new XMLWorker("ReceivedMessages.txt");
                    MessageChain msg_chain = new MessageChain();
                    //Task<byte[]> bytes = null;
                    BinaryWorker bw = new BinaryWorker();
                    Message mg = null;
                    while (true)
                    {
                        byte[]bytes = await messageReceiver.receiveBytesAsync(port);
                        mg = bw.bytesToMessage(bytes);
                        msg_chain.add(mg);
                        xmlWorker.writeXML(msg_chain);
                        Console.WriteLine(mg.message);
                        Console.ReadLine();
                    }
                });
            t.Wait();
        }
    }
}
