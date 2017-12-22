using Pdc.System.Component.Connector;
using System;
using System.Collections.Generic;
using System.Threading.Tasks;

namespace Pdc.System.Component
{
    /// <summary>
    ///
    /// </summary>
    public class ChannelEnvironment : IChannelEnvironment
    {
        private List<Tuple<object, object>> io;

        /// <summary>
        ///
        /// </summary>
        /// <param name="computationUnit"></param>
        public ChannelEnvironment(IActiveComputationUnit computationUnit)
        {
            io = new List<Tuple<object, object>>();
            ComputationUnit = computationUnit;
        }

        /// <summary>
        ///
        /// </summary>
        public IActiveComputationUnit ComputationUnit { get; }

        /// <summary>
        ///
        /// </summary>
        /// <param name="inValues"></param>
        public Task<List<object>> SetInputValues(List<object> inValues)
        {
            _inValues = inValues;
            var channelOperation = Task.Run(() => PerformChannelOperation());
            return channelOperation;
        }

        private async Task<List<object>> PerformChannelOperation()
        {
            _outValues = await ComputationUnit.Invoke(_inValues);
            return _outValues;
        }

        private List<object> _outValues;

        private List<object> _inValues;
    }
}