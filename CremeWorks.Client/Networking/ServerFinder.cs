using System.Net;
using System.Net.Sockets;
using System.Text;

namespace CremeWorks.Client.Networking;
public class ServerFinder
{
    private UdpClient _listenClient;

    public event Action<IPAddress>? ServerFound;

    private const int LISTENING_PORT = 25565;
    private const string LISTENING_IDENTIFIER = "CremeWorks Listener v1.0";

    public ServerFinder()
    {
        _listenClient = new UdpClient();
        _listenClient.Client.Bind(new IPEndPoint(IPAddress.Any, LISTENING_PORT));
    }

    public async Task ListenAsync(CancellationToken cancelSource)
    {
        while (!cancelSource.IsCancellationRequested)
        {
            var recvBuffer = await _listenClient.ReceiveAsync(cancelSource);
            var str = Encoding.ASCII.GetString(recvBuffer.Buffer);
            if (str != LISTENING_IDENTIFIER) continue;
            ServerFound?.Invoke(recvBuffer.RemoteEndPoint.Address);
        }
    }
}
