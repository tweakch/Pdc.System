using System.Threading.Tasks;

namespace Pdc.Net.Http
{
    internal interface IHttpGetClient
    {
        string GetString(string url);

        Task<string> GetStringAsync(string url);
    }
}