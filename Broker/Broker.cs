using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Platform;

namespace Broker
{
    class Broker
    {
        static void Main(string[] args)
        {
            Task t = Task.Factory.StartNew(async () =>
                {
                    Console.WriteLine("Broker...");
                    XMLWorker xmlWorker = new XMLWorker("Reserv.txt");
                    MessageSenderReceiver messageReceiveSend = new MessageSenderReceiver();
                    BinaryWorker bw = new BinaryWorker();
                    MessageChain msg_chain = xmlWorker.readXML();
                    Message m = null;
                    byte[] bytes = null;

                    if (msg_chain != null)
                    {
                        while (true)
                        {
                            m = msg_chain.extract();
                            if (m == null) break;

                            bytes = bw.messageToBytes(m);
                            messageReceiveSend.sendBytesAsync(bytes, m.port);
                            xmlWorker.clear();
                        }
                    }

                    while (true)
                    {
                        bytes = await messageReceiveSend.receiveBytesAsync(30000);
                        m = bw.bytesToMessage(bytes);
                        if (m != null)
                        {
                            MessageChain msg_chain_reserv = new MessageChain();
                            msg_chain_reserv.add(m);
                            xmlWorker.writeXML(msg_chain_reserv);
                        }
                        messageReceiveSend.sendBytesAsync(bytes, m.port);
                        xmlWorker.clear();
                        Console.WriteLine("Message was sent to port " + m.port + "!");
                    }
                });
            t.Wait();
        }
    }
}
