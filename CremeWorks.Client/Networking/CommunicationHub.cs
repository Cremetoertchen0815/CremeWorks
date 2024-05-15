using Newtonsoft.Json;
using System.Net;
using System.Net.Sockets;

namespace CremeWorks.Client.Networking;
public class CommunicationHub
{
    public readonly IPAddress Address;
    private TcpClient? _client = null;
    private StreamReader? _reader = null;
    private StreamWriter? _writer = null;

    private const int PORT = 187;
    private const string WELCOME_DATA = "Welcome to CremeWorks!";

    public delegate void RPCDelegate(MessageTypeEnum type, string? data);
    public event RPCDelegate? DataReceived;
    public event Action? Disconnected;


    public CommunicationHub(IPAddress address) => Address = address;

    public async Task<bool> Connect()
    {
        try
        {
            _client = new TcpClient();

            int triesLeft = 50;
            while (triesLeft-- > 0) 
            {
                try
                {
                    await _client.ConnectAsync(new IPEndPoint(Address, PORT));
                }
                catch (Exception)
                {
                    continue;
                }
                break;
            }

            if (triesLeft <= 0) return false;


            _reader = new StreamReader(_client.GetStream());
            _writer = new StreamWriter(_client.GetStream());
            if (await _reader.ReadLineAsync() != WELCOME_DATA) return false;
            _writer.WriteLine(Environment.MachineName);
            _writer.Flush();
            _ = Task.Run(ReadData);
            return true;
        }
        catch (Exception)
        {
            return false;
        }
    }

    private async Task ReadData()
    {
        try
        {
            while (_client!.Connected)
            {
                var data = await _reader!.ReadLineAsync();
                if (data is null) break;
                var index = (MessageTypeEnum)byte.Parse(data);
                var body = await _reader!.ReadLineAsync();
                DataReceived?.Invoke(index, body);
            }
        }
        finally
        {
            Disconnected?.Invoke();
        }
    }
    public void SendData(MessageTypeEnum type, object data)
    {
        try
        {
            if (_writer is null) return;
            _writer.WriteLine(((byte)type).ToString());
            _writer.WriteLine(data is string s ? s : JsonConvert.SerializeObject(data));
            _writer.Flush();
        }
        catch (Exception)
        {
        }
    }



}