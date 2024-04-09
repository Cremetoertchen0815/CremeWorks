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
    }
}
