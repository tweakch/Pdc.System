using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pdc.System.Component
{
    //#refactor move to Pdc.System.Component.Web
    /// <summary>
    ///
    /// </summary>
    public abstract class AsyncRestApiComponent : ActiveComponentBase
    {
        private readonly IHttpClientSettings _settings;

        /// <summary>
        ///
        /// </summary>
        /// <param name="client"></param>
        /// <param name="settings"></param>
        protected AsyncRestApiComponent(HttpClient client, IHttpClientSettings settings)
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

        protected async Task<HttpResponseMessage> RestPost(string route, IEnumerable<KeyValuePair<string, string>> content)
        {
            return await Client.PostAsync(route, new FormUrlEncodedContent(content));
        }

        protected async Task<string> RestGet(string route, string parameter)
        {
            var uri = $"{route}{parameter}";
            return await Client.GetStringAsync(uri);
        }
    }
}