using Pdc.System.Component.Connector;
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
        ///     Backing field for the SubCompomponents Property
        /// </summary>
        private readonly IEnumerable<IComponent> _subComponents;

        private IConnector _connector;

        /// <summary>
        /// </summary>
        protected ComponentBase()
        {
            ComponentType = EComponentType.Undefined;
            ComponentArity = EComponentArity.Nary;
        }

        /// <summary>
        /// </summary>
        protected ComponentBase(IConnector connector)
        {
            InitializeConnector(connector);
        }

        /// <summary>
        /// </summary>
        /// <param name="connector"></param>
        /// <param name="subComponents"></param>
        protected ComponentBase(IConnector connector, IEnumerable<IComponent> subComponents) : this(connector)
        {
            _subComponents = subComponents;
        }

        /// <summary>
        /// </summary>
        /// <param name="subComponents"></param>
        protected ComponentBase(IEnumerable<IComponent> subComponents)
        {
            _subComponents = subComponents;
        }

        /// <summary>
        ///     True if the component is active
        /// </summary>
        public bool IsActive => ComponentType == EComponentType.Active;

        /// <summary>
        ///     True if the component is passive
        /// </summary>
        public bool IsPassive => ComponentType == EComponentType.Passive;

        /// <summary>
        ///     Provides the interface for the Component
        /// </summary>
        public IConnector Connector => _connector ?? new NullConnector();

        /// <summary>
        ///     True if the component has SubComponents, otherwise False
        /// </summary>
        public virtual bool IsComposite => SubComponents.Count() > 0;

        /// <summary>
        /// </summary>
        public IEnumerable<IComponent> SubComponents => _subComponents ?? new List<IComponent>();

        /// <summary>
        ///     The type of the component
        /// </summary>
        public EComponentType ComponentType { get; protected set; }

        /// <summary>
        ///     The arity of the component
        /// </summary>
        public EComponentArity ComponentArity { get; protected set; }

        private void InferArity(IConnector connector)
        {
            //#refactor PO and infer arity from exposed connector methods
            // => arity == least supported input value count
            var name = connector.GetType().Name;
            if (name.Contains("Unary"))
            {
                ComponentArity = EComponentArity.Unary;
            }
            else if (name.Contains("Binary"))
            {
                ComponentArity = EComponentArity.Binary;
            }
            else if (name.Contains("Ternary"))
            {
                ComponentArity = EComponentArity.Ternary;
            }
            else
            {
                ComponentArity = EComponentArity.Nary;
            }
        }

        /// <summary>
        /// Registers the connector on the component and infers the component arity from the connector name
        /// </summary>
        /// <param name="connector"></param>
        protected void InitializeConnector(IConnector connector)
        {
            _connector = connector;
            _connector.Bind(this);
            InferArity(connector);
        }
    }
}