using System.Net.Http;
using System.Threading.Tasks;

namespace Pdc.System.Sample.Components.Active
{
    //#refactor move to Pdc.System.Component.Web
    public abstract class AsyncHttpClientOperation
    {
        private readonly IHttpClientSettings _settings;

        protected AsyncHttpClientOperation(HttpClient client, IHttpClientSettings settings)
        {
            _settings = settings;
            _client = client;
            Setup();
        }

        private readonly HttpClient _client;

        protected HttpClient Client => _client ?? new HttpClient();

        private void Setup()
        {
            _settings.AcceptHeaders.ForEach(setting => Client.DefaultRequestHeaders.Accept.Add(setting));
        }

        protected async Task<string> CallRestApi(string route, string parameter)
        {
            return await Client.GetStringAsync($"{route}/{parameter}");
        }
    }
}