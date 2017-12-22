using Pdc.Net.Http;
using Pdc.Net.Http.Configuration;
using Pdc.Net.Http.Validation;
using System;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pdc.Net.Service.Client
{
    public class HttpClientWrapper : IHttpGetClient, IHttpPostClient
    {
        public HttpClientWrapper(IHttpClientConfiguration clientConfiguration)
        {
            if (clientConfiguration == null)
            {
                clientConfiguration = AHttpClientConfiguration.DefaultConfiguration;
                //set default communication ClientConfiguration
            }
            ClientConfiguration = clientConfiguration;
        }

        public HttpClientWrapper() : this(null)
        {
        }

        public IHttpClientConfiguration ClientConfiguration { get; }
        public IHttpContentValidator ContentValidator => ClientConfiguration.ContentValidator;

        public virtual string GetString(string url)
        {
            var getStringAsync = GetStringAsync(url);
            getStringAsync.Wait();
            return getStringAsync.Result;
        }

        public virtual Task<string> GetStringAsync(string url)
        {
            CheckEndpointUrl(url);
            return PdcHttp.GetStringAsync(url);
        }

        public virtual HttpResponseMessage Post(string url, HttpContent content)
        {
            var postAsync = PostAsync(url, content);
            postAsync.Wait();
            return postAsync.Result;
        }

        public virtual Task<HttpResponseMessage> PostAsync(string url, HttpContent content)
        {
            CheckEndpointUrl(url);
            CheckContent(content);
            return PdcHttp.PostAsync(url, content);
        }

        public static bool IsUrl(string url)
        {
            return PdcHttp.IsUrl(url);
        }

        private static void CheckEndpointUrl(string url)
        {
            var uri = new Uri(url);
            if (!IsUrl(url)) throw new InvalidEndpointException(nameof(url));
        }

        /// <summary>
        ///     Checks the content of the post request for configured ClientConfiguration
        /// </summary>
        /// <param name="content"></param>
        private void CheckContent(HttpContent content)
        {
            var result = ContentValidator.Validate(content, ClientConfiguration);
            if (result.HasErrors)
            {
                // Log, throw, etc.
            }
        }
    }

    public class HttpJsonClient : HttpClientWrapper
    {
        public HttpJsonClient() : base(new HttpJsonClientConfiguration())
        {
        }

        public override Task<string> GetStringAsync(string url)
        {
            return base.GetStringAsync(url).ContinueWith(s =>
            {
                //Unwrap escaped json objects
                var json = s.Result;
                json = json.Replace("\"{", "{");
                json = json.Replace("}\"", "}");
                json = json.Replace("\\\"", "\"");
                return json;
            });
        }
    }
}