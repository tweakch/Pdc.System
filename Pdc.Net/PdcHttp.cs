using System;
using System.Net.Http;
using System.Threading;
using System.Threading.Tasks;

namespace Pdc.Net
{
    public static class PdcHttp
    {
        private static HttpClient __defaultClient;

        public static HttpClient DefaultClient => __defaultClient ?? (__defaultClient = new HttpClient());

        public static HttpResponseMessage Get(string uri)
        {
            return Get(new Uri(uri));
        }

        public static string GetString(string uri)
        {
            return GetString(new Uri(uri));
        }

        public static HttpResponseMessage Get(Uri uri)
        {
            var getAsync = GetAsync(uri);
            getAsync.Wait();
            return getAsync.Result;
        }

        public static string GetString(Uri uri)
        {
            var stringAsync = GetStringAsync(uri);
            stringAsync.Wait();
            return stringAsync.Result;
        }

        public static Task<string> GetStringAsync(Uri uri)
        {
            return __defaultClient.GetStringAsync(uri);
        }

        public static Task<HttpResponseMessage> GetAsync(Uri uri)
        {
            return __defaultClient.GetAsync(uri);
        }

        public static Task<string> GetStringAsync(string uri)
        {
            return __defaultClient.GetStringAsync(uri);
        }

        public static Task<HttpResponseMessage> GetAsync(string uri)
        {
            return __defaultClient.GetAsync(uri);
        }

        public static Task<HttpResponseMessage> PostAsnyc(Uri uri, HttpContent content)
        {
            return __defaultClient.PostAsync(uri, content);
        }

        public static Task<HttpResponseMessage> PostAsnyc(Uri uri, HttpContent content,
            CancellationToken cancellationToken)
        {
            return __defaultClient.PostAsync(uri, content, cancellationToken);
        }

        public static Task<HttpResponseMessage> PostAsnyc(string uri, HttpContent content,
            CancellationToken cancellationToken)
        {
            return __defaultClient.PostAsync(uri, content, cancellationToken);
        }

        public static Task<HttpResponseMessage> PostAsync(string uri, HttpContent content)
        {
            return __defaultClient.PostAsync(uri, content);
        }

        public static Task<HttpResponseMessage> PostAsync(Uri uri, HttpContent content)
        {
            return __defaultClient.PostAsync(uri, content);
        }

        public static HttpResponseMessage Post(string uri, HttpContent content)
        {
            return Post(new Uri(uri), content);
        }

        public static HttpResponseMessage Post(Uri uri, HttpContent content)
        {
            var postAsync = PostAsync(uri, content);
            postAsync.Wait();
            return postAsync.Result;
        }

        public static bool IsUrl(string url)
        {
            throw new NotImplementedException();
        }
    }
}