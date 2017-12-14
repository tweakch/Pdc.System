using System.Configuration;
using System.Runtime.Remoting.Channels;
using System.Security.Authentication;

namespace Pdc.Net.Service.Client
{
    public interface IClientProvider
    {
        object GetClient();
        object GetClient(string configurationName);
    }
}
