using System.Net;
using System.Net.Sockets;

namespace BV.Game.Components.Network;

/// <summary>
/// Resolves the server address into its IPv4 address.
/// Supports buffering the last translation if reconnects occur.
/// </summary>
public class DnsResolverIPv4
{
    public static readonly DnsResolverIPv4 Instance = new();
    private DnsResolverIPv4() { }

    private string? _lastHostName = null;
    private IPAddress? _lastIP = null;

    /// <summary>
    /// Translate the <paramref name="hostname"/> parameter into an IPv4 address asynchronously.
    /// This is done specifically to prevent the system translating the hostname into an IPv6 address,
    /// which fails to connect and leaves the connecting client hanging and waiting for timeout.
    /// </summary>
    /// <param name="hostname"></param>
    /// <returns></returns>
    public async Task<IPAddress> ResolveHostname(string hostname)
    {
        if (_lastIP is not null && _lastHostName == hostname) return _lastIP;

        var addresses = await Dns.GetHostAddressesAsync(_lastHostName = hostname, AddressFamily.InterNetwork);
        return _lastIP = addresses.First();
    }
}
