using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading;
using System.Threading.Tasks;

namespace CremeWorks.Client.Networking
{
    public class ServerFinder
    {
        private UdpClient _listenClient;

        private const int LISTENING_PORT = 25565;
        private const string LISTENING_IDENTIFIER = "CremeWorks Listener v1.6";

        public ServerFinder()
        {
            _listenClient = new UdpClient();
            _listenClient.Client.Bind(new IPEndPoint(IPAddress.Any, LISTENING_PORT));
        }

        public async Task<IPAddress?> ListenAsync(CancellationToken cancelSource)
        {
            var recvBuffer = await _listenClient.ReceiveAsync();
            var str = Encoding.ASCII.GetString(recvBuffer.Buffer);
            _listenClient.Close();
            if (str != LISTENING_IDENTIFIER) return null;
            return recvBuffer.RemoteEndPoint.Address;
        }
    }
}
