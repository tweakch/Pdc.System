namespace Pdc.System.Component
{
    /// <summary>
    ///     Abstract base class for all passive components
    /// </summary>
    public abstract class PassiveComponentBase : ComponentBase
    {
        /// <summary>
        ///     Initializes a component
        /// </summary>
        protected PassiveComponentBase()
        {
            ComponentTypeType = EComponentType.Passive;
        }
    }
}