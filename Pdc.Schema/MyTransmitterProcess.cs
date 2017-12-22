using Pdc.System;
using Pdc.System.Process;
using System;

namespace Pdc.Schema
{
    public class MyTransmitterProcess : PdcTransmitterProcess<TransmitterSchema>
    {
        protected override void OnBeforeRun()
        {
            throw new NotImplementedException();
        }

        protected override void OnAfterRun()
        {
            throw new NotImplementedException();
        }

        protected override void OnRun(IClient client)
        {
            throw new NotImplementedException();
        }
    }
}