using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Platform
{
    public class MessageSenderReceiver
    {
        public async Task sendBytesAsync(byte[] bytes, int port)
        {
            if (bytes.Count() <= 0) return;

            UdpClient trasport = new UdpClient();
            trasport.Connect("127.0.0.1", port);
            trasport.Send(bytes, bytes.Length);
            trasport.Close();
        }

        public async Task<byte[]> receiveBytesAsync(int port)
        {
            UdpClient trasport = new UdpClient(port);
           // IPEndPoint ep = new IPEndPoint(IPAddress.Parse("127.0.0.1"), port);
            UdpReceiveResult result = await trasport.ReceiveAsync();
            byte[] bytes = result.Buffer;
            trasport.Close();
            return bytes;
        }
    }
}
