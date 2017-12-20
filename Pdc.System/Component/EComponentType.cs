namespace Pdc.System.Component
{
    /// <summary>
    ///     Specifies kinds of components
    /// </summary>
    public enum EComponentType
    {
        /// <summary>
        ///     Specifies an Active Component
        /// </summary>
        Active,

        /// <summary>
        ///     Specifies a Passive Component
        /// </summary>
        Passive,

        /// <summary>
        ///     Specifies an Undefined Component
        /// </summary>
        Undefined
    }

    /// <summary>
    ///     Specifies the arity of the component.
    /// </summary>
    public enum EComponentArity
    {
        /// <summary>
        ///     Specifies a Component whos connector accepts exactly one input parameter
        /// </summary>
        Unary,

        /// <summary>
        ///     Specifies a Component whos connector accepts excatly two input parameters
        /// </summary>
        Binary,

        /// <summary>
        ///     Specifies a Component whos connector accepts exactly three input parameters
        /// </summary>
        Ternary,

        /// <summary>
        ///     Specifies a Component whos connector accepts N input parameters
        /// </summary>
        Nary
    }
}