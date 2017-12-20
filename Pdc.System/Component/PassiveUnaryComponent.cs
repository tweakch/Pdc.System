using Pdc.System.Component.Connector;

namespace Pdc.System.Component
{
    /// <summary>
    /// 
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public abstract class PassiveUnaryComponent<T> : ComponentBase
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="compute"></param>
        protected PassiveUnaryComponent(UnaryComputation<T> compute) : base(new UnaryComputationConnector<T>())
        {
            Computation = compute;
        }

        /// <summary>
        ///     The unary method that performs the work
        /// </summary>
        public UnaryComputation<T> Computation { get; }
    }
}