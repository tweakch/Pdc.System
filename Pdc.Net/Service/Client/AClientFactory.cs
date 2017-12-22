using System;
using System.ServiceModel;
using System.ServiceModel.Description;

namespace Pdc.Net.Service.Client
{
    public abstract class AClientFactory<TChannel> where TChannel : class
    {
        private readonly IClientProvider _provider;

        protected AClientFactory(IClientProvider provider)
        {
            _provider = provider;
        }

        public object CreateClient(string configurationName)
        {
            var client = _provider.GetClient(configurationName);
            return client;
        }

        public object CreateClient(string configurationName, string username, string password)
        {
            var client = (ClientBase<TChannel>)_provider.GetClient(configurationName);
            if (client.ClientCredentials == null) throw new NotSupportedException();
            client.ClientCredentials.UserName.UserName = username;
            client.ClientCredentials.UserName.Password = username;
            return client;
        }

        public object CreateClient(string configurationName, IEndpointBehavior behaviour)
        {
            var client = (ClientBase<TChannel>)CreateClient(configurationName);
            client.Endpoint.Behaviors.Add(behaviour);
            return client;
        }

        public object CreateClient(string configurationName, string username, string password,
            IEndpointBehavior behaviour)
        {
            var client = (ClientBase<TChannel>)CreateClient(configurationName, username, password);
            client.Endpoint.Behaviors.Add(behaviour);
            return client;
        }
    }
}