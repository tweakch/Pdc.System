using Pdc.Net.Service.Inspector;
using System.ServiceModel.Channels;
using System.ServiceModel.Description;
using System.ServiceModel.Dispatcher;

namespace Pdc.Net.Service.Behaviour
{
    /// <summary>
    /// The default client behaviour pdc uses to inspect messages on a wcf client
    /// </summary>
    public class DefaultClientBehavior : IEndpointBehavior
    {
        private readonly IClientMessageInspector _inspector;

        /// <summary>
        /// Inject your own inspector
        /// </summary>
        /// <param name="inspector"></param>
        public DefaultClientBehavior(IClientMessageInspector inspector)
        {
            _inspector = inspector;
        }

        /// <summary>
        /// Creates the default client behaviour pdc uses with the standard PdcMessageInspector
        /// </summary>
        public DefaultClientBehavior() : this(false)
        {
        }

        /// <summary>
        /// Creates the default client behaviour pdc uses.
        /// <param name="extended">If true, the behaviour will use the <see cref="PdcMessageInspector.ConfigawareInspector"/> which is </param>
        /// </summary>
        public DefaultClientBehavior(bool extended = false) : this(extended ? PdcMessageInspector.ConfigawareInspector : PdcMessageInspector.Default)
        {
        }

        public void AddBindingParameters(ServiceEndpoint endpoint, BindingParameterCollection bindingParameters)
        {
        }

        public void ApplyClientBehavior(ServiceEndpoint endpoint, ClientRuntime clientRuntime)
        {
            //Add the inspector
            clientRuntime.MessageInspectors.Add(_inspector);
        }

        public void ApplyDispatchBehavior(ServiceEndpoint endpoint, EndpointDispatcher endpointDispatcher)
        {
        }

        public void Validate(ServiceEndpoint endpoint)
        {
        }
    }
}