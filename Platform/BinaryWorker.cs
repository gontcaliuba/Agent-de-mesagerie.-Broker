using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Runtime.Serialization;
using System.Runtime.Serialization.Formatters.Binary;
using System.Text;
using System.Threading.Tasks;

namespace Platform
{
    public class BinaryWorker
    {
        public byte[] messageToBytes(Message m)
        {
            byte[] bytes = null;
            IFormatter formatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream())
            {
                formatter.Serialize(stream, m);
                bytes = stream.ToArray();
            }
            if (bytes.Count() <= 0) return null;
            return bytes;
        }
        public Message bytesToMessage(byte[] bytes)
        {
            Message m = null;
            IFormatter formatter = new BinaryFormatter();
            using (MemoryStream stream = new MemoryStream(bytes))
            {
                m = (Message)formatter.Deserialize(stream);
            }
            return m;
        }
    }
}
