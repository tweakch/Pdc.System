using Pdc.System.Component.Connector;
using System;

namespace Pdc.System.Component
{
    /// <summary>
    ///     Generic base class for a passive component
    /// </summary>
    /// <typeparam name="TConnector">Type of the connector</typeparam>
    /// <typeparam name="TComputationUnit">Type of the computation unit</typeparam>
    public abstract class PassiveComponentBase<TConnector, TComputationUnit>
        : PassiveComponentBase
        where TConnector : IConnector
        where TComputationUnit : IPassiveComputationUnit
    {
        /// <summary>
        ///
        /// </summary>
        protected PassiveComponentBase()
            : base(Activator.CreateInstance<TConnector>(), Activator.CreateInstance<TComputationUnit>())
        {
        }
    }

    /// <summary>
    ///     Abstract base class for a passive component
    /// </summary>
    public abstract class PassiveComponentBase : ComponentBase
    {
        /// <summary>
        ///
        /// </summary>
        protected PassiveComponentBase()
        {
        }

        /// <summary>
        ///     The computation unit of the component
        /// </summary>
        public IPassiveComputationUnit PassiveComputationUnit { get; private set; }

        /// <summary>
        ///     Initializes a component
        /// </summary>
        /// <param name="connector"></param>
        protected PassiveComponentBase(IConnector connector) : base(connector)
        {
            ComponentType = EComponentType.Passive;
        }

        /// <summary>
        ///     Initializes a component
        /// </summary>
        /// <param name="connector"></param>
        /// <param name="unit"></param>
        protected PassiveComponentBase(IConnector connector, IPassiveComputationUnit unit) : base(connector)
        {
            PassiveComputationUnit = unit;
        }
    }
}