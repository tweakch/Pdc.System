using System.ServiceModel;
using System.ServiceModel.Channels;
using System.ServiceModel.Dispatcher;

namespace Pdc.Net.Service.Inspector
{
    public class PdcMessageInspector : IClientMessageInspector
    {
        public virtual void AfterReceiveReply(ref Message reply, object correlationState)
        {
            var replyEmpty = reply.IsEmpty;
        }

        public virtual object BeforeSendRequest(ref Message request, IClientChannel channel)
        {
            var empty = request.IsEmpty;
            return null;
        }

        public static IClientMessageInspector Default => new PdcMessageInspector();
        public static IClientMessageInspector ConfigawareInspector => new PdcMessageInspector();
    }
}