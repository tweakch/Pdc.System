namespace Pdc.System.Component
{
    /// <summary>
    ///     Defines a computation that takes exactly one input value (unary)
    /// </summary>
    /// <param name="inValue">Input value of the computation</param>
    /// <param name="outValue">Result of the computation</param>
    public delegate void UnaryComputation(object inValue, out object outValue);

    /// <summary>
    ///     Defines a computation that takes exactly one input value (unary) and whos output value is of the same type as the input value.
    /// </summary>
    /// <param name="inValue">Input value of the computation</param>
    /// <param name="outValue">Result of the computation</param>
    /// <typeparam name="T">Type of the input and output value</typeparam>
    public delegate void UnaryComputation<T>(T inValue, out T outValue);

    /// <summary>
    ///     Defines a computation that takes exactly one input value (unary) and whos output value is of a different type than the input value.
    /// </summary>
    /// <param name="inValue">Input value of the computation</param>
    /// <param name="outValue">Result of the computation</param>
    /// <typeparam name="TIn">Type of the input value</typeparam>
    /// <typeparam name="TOut">Type of the output value</typeparam>
    public delegate void UnaryComputation<in TIn, TOut>(TIn inValue, out TOut outValue);
}