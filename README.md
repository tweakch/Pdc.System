# PdcFramework

This framework introduces terminology through it's interfaces and classes that help you do your job well.

## Components as a Service

> TL;DR Components are atomic units that can be active or passive. Active Components can generate control signals. Passive Components can only receive them.

A COMPONENT (by definition) is a part of a larger entity. An object that fits into an existing machine / ecosystem. What we as programmers do is design these components by describing them in code. That's it.

### Passive Components

In system engineering terms, Passive Components are incapable of signal amplification. This means they are just sitting there and do their job. They can be installed / uninstalled but not activated or deactivated.

Passive components consist of a [Passive Computation Unit][1] and an [Invocation Connector][1].

Examples for passive components include:

* Sockets
* RESTful Webservices
* Databases
* Caches
* A knights shield
* Earths magnetic field

### Active Components

An active component is an autonomous, managed, hierarchical software entity that exposes and uses functionalities via services and whose behavior is defined in terms of an internal architecture. *[[Pokahr & Braubach, 2012]][2]*

Active components consist of an [Active Computation Process][1] and a [Channels Connector][1].

Just like their Passive counterparts, Active components can be installed and unistalled. But unlike passive components, they need to be activated in order to work. So they have an internal control thread and can receive an external control thread. These threads are only synchronized within the Channels Connector.

Examples for active components include:

* Client in a Client/Server environment
* Bird of Prey cloaking module.
* Death Star Mk I Superlaser

### Composite Components

Active and Passive Components can be linked together to create a Composite Component. Interestingly, when reversing the order of the linked components, you also change it from Active to Passive.

And before we write the first line of code, we have to think about the ROLE of a COMPONENT within our ecosystem.

## The role of roles

> TL;DR By combining Components you create Composites that act in a certain way. This "certain way" is described by the COMPOSITE ROLE.

### Roles

Regardless of their Active or Passive nature, Components can take on ROLES.

* TRANSMITTER (send data somewhere, Active Only)
* RECEIVER (receive data from someone, Passive and Active)
* TRANSCEIVER (does both, Active Only)

This framework is built around this core concept, and you will find a lot of classes that support this way of thinking.

## Conventions

### Dependency Injection Ready

All classes can be used - and are tested with - with Unity.
    var configuration = new Pdc.System.AssemblyConfigurator(Assembly.GetExecutingAssembly();)
    UnityContainer container = new UnityContainer(); 

## Links
[1]: https://pdfs.semanticscholar.org/b0ae/820f7f077eda74c11fc22d0da45f2300a4a0.pdf
[2]: https://vsis-www.informatik.uni-hamburg.de/getDoc.php/publications/433/activecomponents_short.pdf
[3]: https://vsis-www.informatik.uni-hamburg.de/getDoc.php/publications/477/jadex_peds_revised3.pdf
