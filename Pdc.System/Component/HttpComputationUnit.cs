using System;
using System.Collections.Generic;
using System.Net.Http;
using System.Threading.Tasks;

namespace Pdc.System.Component
{
    public abstract class HttpComputationUnit<TSettings> : AsyncRestApiComponent, IActiveComputationUnit
        where TSettings : IHttpClientSettings
    {
        protected const string CANCELLED_BY_USER = "The operation was cancelled by the user.";

        protected HttpComputationUnit() : this(new HttpClient(), Activator.CreateInstance<TSettings>())
        {
        }

        protected HttpComputationUnit(HttpClient client, IHttpClientSettings settings) : base(client, settings)
        {
        }

        public abstract Task<List<object>> Invoke(List<object> inValues);
    }
}