using System;
using System.CodeDom;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using Pdc.System;
using Pdc.System.Process;

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
