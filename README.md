# Design Patterns

This repository is learning material.

Reading **Head First Design Patterns** by Eric Freeman

The books example in Java. I wrote codes in C#. As my primary Development language C# and C# is rich enough for the OOP Implementation.

If you are reading this, you can implement on your preferred language.Core concepts are same.

# Table of Contents

- What are Design Patterns
- Key Characteristics of Design Patterns
- Types of Software Design Patterns

# What are Design Patterns

Design patterns are reusable solutions to common problems in software design. They represent best practices used by experienced object-oriented software developers. Design patterns provide a standard terminology and are specific to particular scenarios.

# Key Characteristics of Design Patterns

- **Reusability:** Patterns can be applied to different projects and problems, saving time and effort in solving similar issues.

- **Standardization:** They provide a shared language and understanding among developers, facilitating communication and collaboration.

- **Efficiency:** By using established patterns, developers can avoid reinventing the wheel, leading to faster and more reliable development.
  Flexibility: Patterns are abstract solutions that can be adapted to fit various contexts and requirements.

## Types of Software Design Patterns

There are three types of Design Patterns:

<!-- - Creational Design Pattern
- Structural Design Pattern
- Behavioral Design Pattern -->
<h2> Creational Design Patterns </h2>
<details> 
<summary> Click to Expand </summary>
Creational Design Pattern abstract the instantiation process. They help in making a system independent of how its objects are created, composed and represented.

1. **Factory Method Design Pattern:**
   The Factory Method pattern is used to create objects without specifying the exact class of object that will be created. This pattern is useful when you need to decouple the creation of an object from its implementation.

2. **Abstract Factory Method Design Pattern:**
   Abstract Factory pattern is almost similar to Factory Pattern and is considered as another layer of abstraction over factory pattern. Abstract Factory patterns work around a super-factory which creates other factories.

3. **Singleton Method Design Pattern:**
   The Singleton method or Singleton Design pattern is one of the simplest design patterns. It ensures a class only has one instance, and provides a global point of access to it.

4. **Prototype Method Design Pattern:**
   Prototype allows us to hide the complexity of making new instances from the client. The concept is to copy an existing object rather than creating a new instance from scratch, something that may include costly operations. The existing object acts as a prototype and contains the state of the object.

5. **Builder Method Design Pattern:**
   Builder pattern aims to “Separate the construction of a complex object from its representation so that the same construction process can create different representations.” It is used to construct a complex object step by step and the final step will return the object.
</details>

<h2>Structural Design Patterns </h2>
<details> 
<summary> Click to Expand </summary>
Structural Design Patterns are concerned with how classes and objects are composed to form larger structures. Structural class patterns use inheritance to compose interfaces or implementations.

1. **Adapter Method Design Pattern:**
   The adapter pattern convert the interface of a class into another interface clients expect. Adapter lets classes work together that couldn’t otherwise because of incompatible interfaces.

2. **Bridge Method Design Pattern:**
   The bridge pattern allows the Abstraction and the Implementation to be developed independently and the client code can access only the Abstraction part without being concerned about the Implementation part.

3. **Composite Method Design Pattern:**
   Composite pattern is a partitioning design pattern and describes a group of objects that is treated the same way as a single instance of the same type of object. The intent of a composite is to “compose” objects into tree structures to represent part-whole hierarchies.

4. **Decorator Method Design Pattern:**
   It allows us to dynamically add functionality and behavior to an object without affecting the behavior of other existing objects within the same class. We use inheritance to extend the behavior of the class. This takes place at compile-time, and all the instances of that class get the extended behavior.

5. **Facade Method Design Pattern:**
   Facade Method Design Pattern provides a unified interface to a set of interfaces in a subsystem. Facade defines a high-level interface that makes the subsystem easier to use.

6. **Flyweight Method Design Pattern:**
   This pattern provides ways to decrease object count thus improving application required objects structure. Flyweight pattern is used when we need to create a large number of similar objects.

7. **Proxy Method Design Pattern:**
   Proxy means ‘in place of’, representing’ or ‘in place of’ or ‘on behalf of’ are literal meanings of proxy and that directly explains Proxy Design Pattern. Proxies are also called surrogates, handles, and wrappers. They are closely related in structure, but not purpose, to Adapters and Decorators.
</details>
<h2> Behavioral Design Patterns </h2>
<details> 
<summary> Click to Expand </summary>
Behavioral Patterns are concerned with algorithms and the assignment of responsibilities between objects. Behavioral patterns describe not just patterns of objects or classes but also the patterns of communication between them. These patterns characterize complex control flow that’s difficult to follow at run-time.

1. **Chain Of Responsibility Method Design Pattern:**
   Chain of responsibility pattern is used to achieve loose coupling in software design where a request from the client is passed to a chain of objects to process them. Later, the object in the chain will decide themselves who will be processing the request and whether the request is required to be sent to the next object in the chain or not.

2. **Command Method Design Pattern:**
   The Command Pattern is a behavioral design pattern that turns a request into a stand-alone object, containing all the information about the request. This object can be passed around, stored, and executed at a later time

3. **Interpreter Method Design Pattern:**
   Interpreter pattern is used to defines a grammatical representation for a language and provides an interpreter to deal with this grammar.

4. **Mediator Method Design Pattern:**
   It enables decoupling of objects by introducing a layer in between so that the interaction between objects happen via the layer.

5. **Memento Method Design Patterns:**
   It is used to restore state of an object to a previous state. As your application is progressing, you may want to save checkpoints in your application and restore back to those checkpoints later. Intent of Memento Design pattern is without violating encapsulation, capture and externalize an object’s internal state so that the object can be restored to this state later.

6. **Observer Method Design Pattern:**
   It defines a one-to-many dependency between objects, so that when one object (the subject) changes its state, all its dependents (observers) are notified and updated automatically.

7. **State Method Design Pattern**
   A state design pattern is used when an Object changes its behavior based on its internal state. If we have to change the behavior of an object based on its state, we can have a state variable in the Object and use the if-else condition block to perform different actions based on the state.

8. **Strategy Method Design Pattern:**
   The Strategy Design Pattern allows the behavior of an object to be selected at runtime. It is one of the Gang of Four (GoF) design patterns, which are widely used in object-oriented programming. The Strategy pattern is based on the idea of encapsulating a family of algorithms into separate classes that implement a common interface.

9. **Template Method Design Pattern:**
   Template method design pattern is to define an algorithm as a skeleton of operations and leave the details to be implemented by the child classes. The overall structure and sequence of the algorithm are preserved by the parent class.

10. **Visitor Method Design Pattern:**
    It is used when we have to perform an operation on a group of similar kind of Objects. With the help of visitor pattern, we can move the operational logic from the objects to another class.

</details>
<h1>Head First Design Patterns</h1>
From Here the book chapter starts

- [Chapter 1 | Strategy Pattern](./DesignPatterns/Singleton/README.md)

- [Chapter 2 | Observer Pattern](./DesignPatterns/Observer/README.md)

- [Chapter 3 | Decorator Pattern](./DesignPatterns/Decorator/RADME.md)

- [Chapter 4 | Factory Pattern](./DesignPatterns/Factory/README.md)

- [Chapter 4 | Abstract Factory Pattern](./DesignPatterns/AbstractFactory/README.md)
- [Chapter 5 | Singleton Pattern](./DesignPatterns/Singleton/README.md)
- [Chapter 6 | Command Pattern](./DesignPatterns/Command/README.md)
