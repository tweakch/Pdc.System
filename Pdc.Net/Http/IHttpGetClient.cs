using System.Threading.Tasks;

namespace Pdc.Net.Http
{
    interface IHttpGetClient
    {
        string GetString(string url);
        Task<string> GetStringAsync(string url);
    }
}