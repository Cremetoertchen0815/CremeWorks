using Newtonsoft.Json;
using System;
using System.IO;
using System.Net.Sockets;

namespace CremeWorks.Networking
{
    public class NetworkConnection
    {
        public Guid Key { get; set; }
        public StreamWriter Writer { get; set; }
        public StreamReader Reader { get; set; }
        public TcpClient Client { get; set; }
        public string Name { get; set; }

        private object _lock = new object();

        public void SendMessage(MessageTypeEnum type, object data)
        {
            lock (_lock)
            {
                Writer.WriteLine(((byte)type).ToString());
                Writer.Flush();
                Writer.WriteLine(data is string s ? s : JsonConvert.SerializeObject(data));
                Writer.Flush();
            }
        }
    }
}
