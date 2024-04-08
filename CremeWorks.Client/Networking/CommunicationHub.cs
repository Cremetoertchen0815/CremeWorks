using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Net.Sockets;
using System.Text;
using System.Threading.Tasks;

namespace CremeWorks.Client.Networking;
public class CommunicationHub
{
    private IPAddress _address;
    private TcpClient? _client = null;
    private StreamReader? _reader = null;
    private StreamWriter? _writer = null;

    private const int PORT = 187;
    private const string WELCOME_DATA = "Welcome to CremeWorks!";

    public delegate void RPCDelegate(MessageTypeEnum type, string? data);
    public event RPCDelegate? DataReceived;


    public CommunicationHub(IPAddress address) => _address = address;

    public async Task<bool> Connect()
    {
        try
        {
            _client = new TcpClient();
            await _client.ConnectAsync(new IPEndPoint(_address, PORT));

            _reader = new StreamReader(_client.GetStream());
            _writer = new StreamWriter(_client.GetStream());
            if (await _reader.ReadLineAsync() != WELCOME_DATA) return false;
            _ = Task.Run(ReadData);
            return false;
        }
        catch (Exception)
        {
            return false;
        }
    }

    private async Task ReadData()
    {
        while (_client!.Connected)
        {
            var data = await _reader!.ReadLineAsync();
            if (data is null) break;
            var index = (MessageTypeEnum)byte.Parse(data);
            DataReceived?.Invoke(index, await _reader!.ReadLineAsync());
        }
    }


    
}