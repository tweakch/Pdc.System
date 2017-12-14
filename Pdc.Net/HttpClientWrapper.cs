using System.Net.Http;
using System.Threading.Tasks;
using Pdc.Net.Http;

namespace Pdc.Net
{
    public class HttpClientWrapper : IHttpGetClient, IHttpPostClient
    {
        public IHttpClientConfiguration Configuration { get; set; }

        public HttpClientWrapper(IHttpClientConfiguration configuration)
        {
            if (configuration == null)
            {
                configuration = HttpClientConfiguration.DefaultConfiguration;
                //set default communication Configuration
            }
            Configuration = configuration;
        }


        public HttpClientWrapper() : this(null)
        {
        }

        public string GetString(string url)
        {
            var getStringAsync = GetStringAsync(url);
            getStringAsync.Wait();
            return getStringAsync.Result;
        }

        public static bool IsUrl(string url)
        {
            return PdcHttp.IsUrl(url);
        }

        public Task<string> GetStringAsync(string url)
        {
            CheckEndpointUrl(url);
            return PdcHttp.GetStringAsync(url);
        }

        private static void CheckEndpointUrl(string url)
        {
            if (!IsUrl(url)) throw new InvalidEndpointException(nameof(url));
        }

        public HttpResponseMessage Post(string url, HttpContent content)
        {
            var postAsync = PostAsync(url, content);
            postAsync.Wait();
            return postAsync.Result;
        }

        public Task<HttpResponseMessage> PostAsync(string url, HttpContent content)
        {
            CheckEndpointUrl(url);
            CheckContent(content);
            return PdcHttp.PostAsync(url, content);
        }

        /// <summary>
        /// Checks the content of the post request for configured Configuration
        /// </summary>
        /// <param name="content"></param>
        private void CheckContent(HttpContent content)
        {
            var result = HttpContentValidator.Validate(content, Configuration);
            if (result.HasErrors)
            {
                // Log, throw, etc.  
            }
        }
    }
}