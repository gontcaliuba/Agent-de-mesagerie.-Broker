using System;
using System.Collections.Generic;
using System.IO;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using System.Xml.Serialization;

namespace Platform
{
    public class XMLWorker
    {
        string xmlName;
        public XMLWorker(string xmlName)
        {
            this.xmlName = xmlName;
        }

        public MessageChain readXML()
        {
            XmlSerializer formatter = new XmlSerializer(typeof(MessageChain));
            MessageChain newMessage = null;
            try
            {
                using (FileStream fs = new FileStream(xmlName, FileMode.Open))
                {
                    newMessage = (MessageChain)formatter.Deserialize(fs);
                }
            }
            catch
            {
                return null;
            }
            return newMessage;
        }
        public void writeXML(MessageChain m)
        {
            XmlSerializer formatter = new XmlSerializer(typeof(MessageChain));
            using (FileStream fs = new FileStream(xmlName, FileMode.OpenOrCreate))
            {
                formatter.Serialize(fs, m);
            }
        }

        public void clear()
        {
            File.Delete(xmlName);
        }

    }
}
