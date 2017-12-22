using Pdc.Net.Service.Behaviour;
using System;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Pdc.Net.Service
{
    public static class EndpointBehaviourFactory
    {
        public static IEndpointBehavior Default { get; } = CreateDefaultBehaviour();

        public static IEndpointBehavior CreateDefaultBehaviour()
        {
            return new DefaultClientBehavior();
        }

        public static IEndpointBehavior CreateSpecificBehaviour(IClientMessageInspector inspector)
        {
            return new DefaultClientBehavior(inspector);
        }

        /// <summary>
        /// Creates an endpoint behaviour
        /// </summary>
        /// <typeparam name="TInspector">The inspector containing the specific behaviour.</typeparam>
        /// <returns></returns>
        public static IEndpointBehavior CreateSpecificBehaviour<TInspector>() where TInspector : IClientMessageInspector
        {
            return CreateSpecificBehaviour(Activator.CreateInstance<TInspector>());
        }
    }
}