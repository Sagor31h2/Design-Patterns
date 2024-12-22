### Command Design Pattern - _Head First Design Patterns (Second Edition)_

The **Command Pattern** encapsulates a request as an object, thereby allowing users to parameterize objects with different requests, queue or log requests, and support undoable operations. This pattern decouples the sender (Invoker) from the receiver of the action.

---

### **Key Points of Command Pattern**:

1. **Encapsulation**: Commands encapsulate requests, allowing them to be treated as standalone objects.
2. **Flexibility**: Enables parameterizing objects with operations, delaying execution, or queuing operations.
3. **Undo/Redo Support**: Commands can store state to allow undo/redo functionality.
4. **Decoupling**: Decouples the Invoker (sender) from the Receiver (performer of the action).

---

### **Java Example of Command Pattern**

#### 1. **Basic Structure**

The example demonstrates a simple remote control that can turn a light on and off. 

##### **Command Interface**

Defines a common interface for all command classes with the `execute` method.

```java
public interface Command {
    void execute();
}
```

##### **Receiver**

The receiver is the class that performs the action when a command is executed.

```java
public class Light {
    public void on() {
        System.out.println("The light is ON");
    }

    public void off() {
        System.out.println("The light is OFF");
    }
}
```

##### **Concrete Command Classes**

Concrete implementations of the `Command` interface, invoking specific methods on the receiver.

```java
public class LightOnCommand implements Command {
    private Light light;

    public LightOnCommand(Light light) {
        this.light = light;
    }

    @Override
    public void execute() {
        light.on();
    }
}

public class LightOffCommand implements Command {
    private Light light;

    public LightOffCommand(Light light) {
        this.light = light;
    }

    @Override
    public void execute() {
        light.off();
    }
}
```

##### **Invoker**

The Invoker class triggers the commands. It has a method to set the command and another to execute it.

```java
public class RemoteControl {
    private Command command;

    public void setCommand(Command command) {
        this.command = command;
    }

    public void pressButton() {
        command.execute();
    }
}
```

##### **Client**

The client creates the concrete commands and configures the invoker.

```java
public class RemoteControlTest {
    public static void main(String[] args) {
        RemoteControl remote = new RemoteControl();
        Light livingRoomLight = new Light();

        Command lightOn = new LightOnCommand(livingRoomLight);
        Command lightOff = new LightOffCommand(livingRoomLight);

        remote.setCommand(lightOn);
        remote.pressButton(); // Output: The light is ON

        remote.setCommand(lightOff);
        remote.pressButton(); // Output: The light is OFF
    }
}
```

---

### **Explanation of Key Concepts**

1. **Invoker**:
   - Responsible for triggering the command execution.
   - Knows about the command object but not the receiver details.

2. **Receiver**:
   - The object that performs the actual action when the command is executed.

3. **Command Interface**:
   - Provides a common interface for all commands.
   - Ensures that the Invoker and Receiver are decoupled.

4. **Concrete Commands**:
   - Implement specific actions to be performed on the Receiver.

---

### **Advanced Features**

1. **Undo Functionality**:
   - Add an `undo` method to the `Command` interface.
   - Maintain a history stack in the Invoker for undo/redo operations.

```java
public interface Command {
    void execute();
    void undo();
}
```

2. **Command Queuing**:
   - Use a list to queue commands for batch processing.
   - Execute them sequentially or concurrently.

---

### **Pros and Cons of Command Pattern**

**Pros**:
- Decouples the Invoker and Receiver, improving flexibility.
- Simplifies logging, queuing, and undo/redo operations.
- Easily extendable to add new commands.

**Cons**:
- Can increase the number of classes in the system.
- Overhead of creating command objects for simple operations.

---

### **Use Cases for Command Pattern**

- **GUI Applications**: Assigning actions to buttons, menus, or keyboard shortcuts.
- **Macro Recording**: Recording and executing sequences of commands.
- **Task Scheduling**: Queueing tasks for execution at a later time.
- **Undo/Redo Mechanism**: Maintaining a history of actions for rollback functionality.

---

The Command Pattern is a powerful tool for creating flexible, decoupled systems, particularly when there’s a need to parameterize requests, queue tasks, or support undo functionality. Let me know if you'd like further details or examples!