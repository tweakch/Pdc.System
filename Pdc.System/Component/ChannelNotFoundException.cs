using System;

namespace Pdc.System.Component
{
    /// <summary>
    /// 
    /// </summary>
    public class ChannelNotFoundException : Exception
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="channelName"></param>
        public ChannelNotFoundException(string channelName) : base($"{channelName} was not found.")
        {
        }
    }
}