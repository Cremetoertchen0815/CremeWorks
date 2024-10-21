using System;
using System.Collections.Generic;
using System.Linq;
using System.Net;
using System.Text;
using System.Threading.Tasks;

namespace CremeWorks.App.Networking.Cloud;
public class SimpleWebProxy : IWebProxy
{
    public ICredentials? Credentials { get; set; }

    public Uri? GetProxy(Uri destination) => destination;
    public bool IsBypassed(Uri host) => false;
}
