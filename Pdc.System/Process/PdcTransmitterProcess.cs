using System;

namespace Pdc.System
{
    /// <summary>
    ///     Provides a template process for Transmitter classes to send data through the IClient interface
    /// </summary>
    /// <typeparam name="T"></typeparam>
    // #refactor Extract to Pdc.Data.Process namespace
    public abstract class PdcTransmitterProcess<T> : ITransmitterProcess where T : IClientProvider
    {
        private readonly Action _afterRun;
        private readonly Action _beforeRun;
        private readonly Action<IClient> _run;

        protected PdcTransmitterProcess()
        {
            _beforeRun = OnBeforeRun;
            _run = OnRun;
            _afterRun = OnAfterRun;
        }

        public void Run()
        {
            IClientProvider provider = Activator.CreateInstance<T>();
            var client = provider.GetClient();
            _beforeRun();
            _run(client);
            _afterRun();
        }

        public int Errors { get; protected set; } = 0;
        protected abstract void OnBeforeRun();
        protected abstract void OnAfterRun();
        protected abstract void OnRun(IClient client);
    }
}
