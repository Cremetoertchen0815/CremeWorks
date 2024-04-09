using CremeWorks.Client.Networking;
using System;
using System.Collections.Concurrent;
using System.IO;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CremeWorks.Networking
{
    public class NetworkingServer
    {
        private TcpListener _dataListener;
        private UdpClient _broadcastClient = new UdpClient();
        private CancellationTokenSource _cancelSource = null;
        private CancellationToken _cancelToken;
        private ConcurrentDictionary<Guid, NetworkConnection> _connections = new ConcurrentDictionary<Guid, NetworkConnection>();

        private const int BROADCAST_INTERVAL_SEC = 2;
        private const int BROADCAST_PORT = 25565;
        private const string BROADCAST_IDENTIFIER = "CremeWorks Listener v1.0";
        private const int PORT = 187;
        private const string WELCOME_DATA = "Welcome to CremeWorks!";

        public delegate void UserJoinedDelegate(NetworkConnection con);
        public delegate void MessageHandleDelegate(MessageTypeEnum type, string data, NetworkConnection con);

        public event UserJoinedDelegate UserJoined;
        public event MessageHandleDelegate MessageReceived;

        public void Start()
        {
            _cancelSource = new CancellationTokenSource();
            _cancelToken = _cancelSource.Token;

            _dataListener = new TcpListener(new IPEndPoint(IPAddress.Any, PORT));
            _dataListener.Start();

            Task.Run(BroadcastingLoop);
            Task.Run(ListenForClients);
        }

        public void SendToAll(MessageTypeEnum type, string data)
        {
            foreach (var item in _connections)
            {
                item.Value.Writer.WriteLine(((byte)type).ToString());
                item.Value.Writer.WriteLine(data);
            }
        }

        public void Stop() => _cancelSource.Cancel();

        private async Task BroadcastingLoop()
        {
            var data = Encoding.ASCII.GetBytes(BROADCAST_IDENTIFIER);
            var ep = new IPEndPoint(IPAddress.Broadcast, BROADCAST_PORT);
            while (!_cancelToken.IsCancellationRequested)
            {
                _broadcastClient.Send(data, data.Length, ep);
                await Task.Delay(TimeSpan.FromSeconds(BROADCAST_INTERVAL_SEC), _cancelToken);
            }
        }

        private async Task ListenForClients()
        {
            while (!_cancelToken.IsCancellationRequested)
            {
                try
                {
                    var client = await _dataListener.AcceptTcpClientAsync();
                    var stream = client.GetStream();
                    var streamw = new StreamWriter(stream);
                    var streamr = new StreamReader(stream);
                    var guid = Guid.NewGuid();

                    await streamw.WriteLineAsync(WELCOME_DATA);
                    var name = await streamr.ReadLineAsync();
                    var con = new NetworkConnection()
                    {
                        Key = guid,
                        Client = client,
                        Reader = streamr,
                        Writer = streamw,
                        Name = name
                    };
                    _connections.TryAdd(guid, con);

                    _ = Task.Run(() => ClientReadLoop(con), _cancelToken);
                }
                catch (Exception)
                {
                    
                }
            }
        }

        private async Task ClientReadLoop(NetworkConnection con)
        {
            try
            {
                while (con.Client.Connected && !_cancelToken.IsCancellationRequested)
                {
                    var data = await con.Reader.ReadLineAsync();
                    if (data is null) break;
                    var index = (MessageTypeEnum)byte.Parse(data);
                    var nextData = await con.Reader.ReadLineAsync();
                    MessageReceived?.Invoke(index, nextData, con);
                }
            }
            catch (Exception)
            {
                _connections.TryRemove(con.Key, out _);
                throw;
            }
        }
    }
}
