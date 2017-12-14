using System;
using System.Collections.Generic;
using System.Linq;
using System.Net.Http;
using System.Text;
using System.Threading.Tasks;

namespace Pdc.Net
{
    interface IHttpPostClient
    {
        HttpResponseMessage Post(string url, HttpContent content);
        Task<HttpResponseMessage> PostAsync(string url, HttpContent content);
    }
}
