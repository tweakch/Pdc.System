namespace Pdc.System.Component.Connector
{
    /// <summary>
    ///     Provides the interface for a unary component
    /// </summary>
    public interface IUnaryConnector : IConnector
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inValue"></param>
        /// <param name="outValue"></param>
        void Execute(object inValue, out object outValue);
    }

    /// <summary>
    ///     Provides the interface for an invariant unary component
    /// </summary>
    /// <typeparam name="TIn"></typeparam>
    /// <typeparam name="TOut"></typeparam>
    public interface IUnaryConnector<in TIn, TOut> : IConnector
    {
        /// <summary>
        /// </summary>
        /// <param name="inValue"></param>
        /// <param name="outValue"></param>
        void Execute(TIn inValue, out TOut outValue);
    }

    /// <summary>
    ///     Provides the interface for a covariant unary component
    /// </summary>
    /// <typeparam name="T"></typeparam>
    public interface IUnaryConnector<T> : IConnector
    {
        /// <summary>
        /// 
        /// </summary>
        /// <param name="inValue"></param>
        /// <param name="outValue"></param>
        void Execute(T inValue, out T outValue);
    }
}