using System.Collections.Generic;
using System.Linq;

namespace Pdc.System.Component
{
    /// <summary>
    ///     Abstract base class for all Components
    /// </summary>
    public abstract class ComponentBase : IComponent
    {
        /// <summary>
        /// Backing field for the SubCompomponents Property
        /// </summary>
        protected readonly IEnumerable<IComponent> subComponents;

        /// <summary>
        /// </summary>
        protected ComponentBase()
        {
        }

        /// <summary>
        /// </summary>
        /// <param name="subComponents"></param>
        protected ComponentBase(IEnumerable<IComponent> subComponents)
        {
            this.subComponents = subComponents;
        }

        /// <summary>
        ///     True if the component is active
        /// </summary>
        public bool IsActive => ComponentTypeType == EComponentType.Active;

        /// <summary>
        ///     True if the component is passive
        /// </summary>
        public bool IsPassive => ComponentTypeType == EComponentType.Passive;

        /// <summary>
        ///     True if the component has SubComponents, otherwise False
        /// </summary>
        public virtual bool IsComposite => SubComponents.Count() > 0;

        /// <summary>
        /// </summary>
        public IEnumerable<IComponent> SubComponents => subComponents ?? new List<IComponent>();

        /// <summary>
        ///     The type of the component
        /// </summary>
        public EComponentType ComponentTypeType { get; protected set; }
    }
}