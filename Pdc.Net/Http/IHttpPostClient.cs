using System.Net.Http;
using System.Threading.Tasks;

namespace Pdc.Net.Http
{
    internal interface IHttpPostClient
    {
        HttpResponseMessage Post(string url, HttpContent content);

        Task<HttpResponseMessage> PostAsync(string url, HttpContent content);
    }
}