using System;
using Pdc.System;

namespace Pdc.Schema
{
    public class TransmitterSchema : IClientProvider
    {
        public TransmitterSchema()
        {
            
        }

        public IClient GetClient()
        {
            throw new NotImplementedException();
        }
    }
}