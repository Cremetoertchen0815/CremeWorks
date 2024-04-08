using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Runtime.InteropServices;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CremeWorks.Networking
{
    public class NetworkingServer
    {
        private UdpClient _broadcastClient = new UdpClient();
        private CancellationTokenSource _cancelSource = null;
        private CancellationToken _cancelToken;

        private const int BROADCAST_INTERVAL_SEC = 2;
        private const int BROADCAST_PORT = 25565;
        private const string BROADCAST_IDENTIFIER = "CremeWorks Listener v1.0";

        public void Start()
        {
            _cancelSource = new CancellationTokenSource();
            _cancelToken = _cancelSource.Token;

            Task.Run(BroadcastingLoop);
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
    }
}
