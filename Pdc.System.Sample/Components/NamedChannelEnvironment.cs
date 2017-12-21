using System;
using System.Collections.Generic;
using System.Threading.Tasks;
using Pdc.System.Component;
using Pdc.System.Component.Connector;

namespace Pdc.System.Sample.Components
{
    /// <summary>
    /// 
    /// </summary>
    public class NamedChannelEnvironment : IChannelEnvironment
    {
        private List<Tuple<object, object>> io;
           
        /// <summary>
        /// 
        /// </summary>
        /// <param name="computationUnit"></param>
        public NamedChannelEnvironment(IActiveComputationUnit computationUnit)
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