using System.Threading.Tasks;

namespace Pdc.Net
{
    interface IHttpGetClient
    {
        string GetString(string url);
        Task<string> GetStringAsync(string url);
    }
}