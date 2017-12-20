# PdcFramework

This framework introduces terminology through it's interfaces and classes that help you do your job and do it well.

## The power of components

> The source code of `AirportInfoComponent` and `AbbreviationExtenderComponent` can be found in the Samples.

```csharp
// receive raw airport data
var info = AirportInfoComponent.Execute("JFK");
// {"delay":"true","IATA":"JFK"...

// directly map results to your classes
var delay = AirportInfoComponent.Execute<AirportInfo>("JFK").Delay;
// true

// string components together
var sequence = PipeConnector.Sequence<AirportInfoComponent, AbbreviationExtenderComponent>();
var example = sequence.Execute("JFK");
// example = {"delay":"true","internationalAirTransportAssociation":"John Fitzgerald Kennedy...
```

## Components as a Service

> **TL;DR** COMPONENTS are atomic units that can be ACTIVE (generate control signals) or PASSIVE (receive control signals).

A COMPONENT (by definition) is a part of a larger entity. An object that fits into an existing machine / ecosystem. What we as programmers do is design these components by describing them in code. That's it.

### Passive Components

In system engineering terms, Passive Components are incapable of signal amplification. This means they are just sitting there and do their job. They can be installed / uninstalled but not activated or deactivated.

Passive components consist of a [Passive Computation Unit][1] and an [Invocation Connector][1].

Examples for passive components include:

* Server (in a client/server environment)
* Databases
* Caches
* A knights shield
* Earths magnetic field

### Active Components

An active component is an autonomous, managed, hierarchical software entity that exposes and uses functionalities via services and whose behavior is defined in terms of an internal architecture. *[[Pokahr & Braubach, 2012]][2]*

Active components consist of an [Active Computation Process][1] and a [Channels Connector][1].

Just like their Passive counterparts, Active components can be installed and unistalled. But unlike passive components, they need to be activated in order to work. So they have an internal control thread and can receive an external control thread. These threads are only synchronized within the Channels Connector.

Examples for active components include:

* Client (in a client/server environment)
* ...
* ...
* Bird of Prey cloaking module.
* Death Star Mk I Superlaser

### Composite Components

Active and Passive Components can be linked together by [Composition Operators][1] to create a Composite Component. Depending on the nature of these operators, composition can yield either an Active or Passive Compisite.

For sequencing we use

* Pipe Connectors and
* Sequencers

For branching we use the

* Selector Connector

#### Pipe Connector

A pipe that composes Components C~1~,...,C~n~ can call methods in  C~1~,...,C~n~ in that order and pass the results to subsequent methods.

#### Sequencer

Does the same as a pipe, but can't pass method results.

#### Selector Connector

Selectors are Stateful Facades. A [Facade][facade] is a unified interface to a set of objects. A [Stateful Facade][stateful_facade] behaves depending on the current state of the facade.

This might seem like an anti-pattern, but the statefulness of the Connector is needed to create an Active Composite.

Depending on it's state, the facade determines which sub-component’s methods can be called. So, if a sub-component is active, then the composite will also be active. It can service an endless sequence of inputs and the role of the connector thread is to provide these inputs to the component itself.

## The role of roles

> TL;DR By combining Components you create Composites that act in a certain way. This "certain way" is described by the COMPOSITE ROLE.

### Roles

Since pdc works with databases and webservices to send / receive data from customers, we predefined three roles in this framework for you to use. Of course you can extend these roles or create new ones.

#### Transmitters

> Send data somewhere, Active Only)

asd

#### Receivers

> Receive data from someone, Passive and Active

asd

#### Transceivers

> Receive and transmit data, Active Only)

asd

## Conventions

### Dependency Injection Ready

All classes can be used - and are tested - with Unity.

```csharp
var configuration = new Pdc.System.AssemblyConfigurator(Assembly.GetExecutingAssembly();
UnityContainer container = new UnityContainer();
```

---

[1]: https://pdfs.semanticscholar.org/b0ae/820f7f077eda74c11fc22d0da45f2300a4a0.pdf
[2]: https://vsis-www.informatik.uni-hamburg.de/getDoc.php/publications/433/activecomponents_short.pdf
[3]: https://vsis-www.informatik.uni-hamburg.de/getDoc.php/publications/477/jadex_peds_revised3.pdf
[facade]:https://sourcemaking.com/design_patterns/facade
[stateful_facade]:http://bit.ly/2BHWXHx