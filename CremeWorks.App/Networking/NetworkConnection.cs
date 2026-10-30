using System;
using System.IO;
using System.Net.Sockets;
using Newtonsoft.Json;

namespace CremeWorks.App.Networking
{
    public class NetworkConnection(TcpClient client, StreamWriter writer, StreamReader reader, string name)
    {
        public Guid Key { get; init; } = Guid.NewGuid();
        public StreamWriter Writer { get; init; } = writer;
        public StreamReader Reader { get; init; } = reader;
        public TcpClient Client { get; init; } = client;
        public string Name { get; init; } = name;

        private readonly object _lock = new();

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
