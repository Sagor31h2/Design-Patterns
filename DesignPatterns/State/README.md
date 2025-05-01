# **State Pattern**

---

### **1. Problem Statement**

Consider designing a **Gumball Machine** that changes behavior depending on its **internal state**:

- If no quarter is inserted → reject crank turn.
- If a quarter is inserted → allow crank turn and dispense.
- If it’s sold out → refuse any actions.

You may initially write conditionals like:

```java
if (state == NO_QUARTER) {
   // do something
} else if (state == HAS_QUARTER) {
   // do something else
}
```

This leads to:

- 🧩 **Hard-to-read code** as logic grows.
- 🔄 **Duplication** when the same checks are repeated.
- 🧱 **Tightly coupled logic**: Adding new states requires modifying multiple parts.
- 😫 **Hard to maintain** as behavior spreads across many conditionals.

---

### **2. State Pattern Solution**

The **State Pattern** encapsulates varying behavior for the same object based on its internal state into separate classes.  

🔁 **Behavioral pattern**  
🎯 **Intent**: Allow an object to change its behavior when its internal state changes — as if the object changed its class.

---

### **3. Participants in the State Pattern**

| Role         | Responsibility                                                                 |
|--------------|----------------------------------------------------------------------------------|
| `Context`    | Maintains an instance of a concrete `State`. Delegates state-specific behavior. |
| `State`      | An interface for encapsulating behavior.                                        |
| `ConcreteState` | Implements behavior associated with a specific state.                          |

---

### **4. Class Diagram**

📦 `State`  
↳ `NoQuarterState`, `HasQuarterState`, `SoldState`, `SoldOutState`  
🎮 `GumballMachine` acts as the `Context`.

```plaintext
   +------------------+
   |     State        |<-----------------+
   +------------------+                  |
   | + insertQuarter()|                  |
   | + ejectQuarter() |                  |
   | + turnCrank()    |                  |
   | + dispense()     |                  |
   +------------------+                  |
          ▲                             |
          |                             |
    +-------------+       +-------------+       +-------------+
    | NoQuarter   |       | HasQuarter  |       | SoldOut     |
    | State       |       | State       |       | State       |
    +-------------+       +-------------+       +-------------+
              \___________________ ___________________/
                                  |
                       +------------------------+
                       |     GumballMachine      |
                       | (maintains currentState)|
                       +------------------------+
```

---

### **5. Step-by-Step Code**

---

#### **Step 1: Define the `State` Interface**

```java
public interface State {
    void insertQuarter();
    void ejectQuarter();
    void turnCrank();
    void dispense();
}
```

Each method represents an action that the user can perform. Each concrete state will implement these differently.

---

#### **Step 2: Implement Concrete States**

---

🔹 **NoQuarterState**

```java
public class NoQuarterState implements State {
    GumballMachine gumballMachine;

    public NoQuarterState(GumballMachine gumballMachine) {
        this.gumballMachine = gumballMachine;
    }

    public void insertQuarter() {
        System.out.println("You inserted a quarter.");
        gumballMachine.setState(gumballMachine.getHasQuarterState());
    }

    public void ejectQuarter() {
        System.out.println("You haven't inserted a quarter.");
    }

    public void turnCrank() {
        System.out.println("You turned, but there's no quarter.");
    }

    public void dispense() {
        System.out.println("You need to pay first.");
    }
}
```

---

🔹 **HasQuarterState**

```java
public class HasQuarterState implements State {
    GumballMachine gumballMachine;

    public HasQuarterState(GumballMachine gumballMachine) {
        this.gumballMachine = gumballMachine;
    }

    public void insertQuarter() {
        System.out.println("You can't insert another quarter.");
    }

    public void ejectQuarter() {
        System.out.println("Quarter returned.");
        gumballMachine.setState(gumballMachine.getNoQuarterState());
    }

    public void turnCrank() {
        System.out.println("You turned...");
        gumballMachine.setState(gumballMachine.getSoldState());
    }

    public void dispense() {
        System.out.println("No gumball dispensed.");
    }
}
```

---

🔹 **SoldState**

```java
public class SoldState implements State {
    GumballMachine gumballMachine;

    public SoldState(GumballMachine gumballMachine) {
        this.gumballMachine = gumballMachine;
    }

    public void insertQuarter() {
        System.out.println("Please wait, we’re already giving you a gumball.");
    }

    public void ejectQuarter() {
        System.out.println("Sorry, you already turned the crank.");
    }

    public void turnCrank() {
        System.out.println("Turning twice doesn't get you another gumball!");
    }

    public void dispense() {
        gumballMachine.releaseBall();
        if (gumballMachine.getCount() > 0) {
            gumballMachine.setState(gumballMachine.getNoQuarterState());
        } else {
            System.out.println("Oops, out of gumballs!");
            gumballMachine.setState(gumballMachine.getSoldOutState());
        }
    }
}
```

---

🔹 **SoldOutState**

```java
public class SoldOutState implements State {
    GumballMachine gumballMachine;

    public SoldOutState(GumballMachine gumballMachine) {
        this.gumballMachine = gumballMachine;
    }

    public void insertQuarter() {
        System.out.println("Machine is sold out.");
    }

    public void ejectQuarter() {
        System.out.println("You can't eject, you haven’t inserted a quarter yet.");
    }

    public void turnCrank() {
        System.out.println("You turned, but there are no gumballs.");
    }

    public void dispense() {
        System.out.println("No gumball dispensed.");
    }
}
```

---

#### **Step 3: Create the Context – `GumballMachine`**

```java
public class GumballMachine {
    State soldOutState;
    State noQuarterState;
    State hasQuarterState;
    State soldState;

    State state;
    int count = 0;

    public GumballMachine(int numberGumballs) {
        soldOutState = new SoldOutState(this);
        noQuarterState = new NoQuarterState(this);
        hasQuarterState = new HasQuarterState(this);
        soldState = new SoldState(this);

        this.count = numberGumballs;
        this.state = numberGumballs > 0 ? noQuarterState : soldOutState;
    }

    public void insertQuarter() {
        state.insertQuarter();
    }

    public void ejectQuarter() {
        state.ejectQuarter();
    }

    public void turnCrank() {
        state.turnCrank();
        state.dispense();
    }

    void releaseBall() {
        System.out.println("A gumball comes rolling out...");
        if (count > 0) {
            count--;
        }
    }

    void setState(State state) {
        this.state = state;
    }

    public int getCount() {
        return count;
    }

    // Getters for each state
    public State getSoldOutState() { return soldOutState; }
    public State getNoQuarterState() { return noQuarterState; }
    public State getHasQuarterState() { return hasQuarterState; }
    public State getSoldState() { return soldState; }
}
```

---

#### **Step 4: Client Code – Running the Machine**

```java
public class GumballMachineTestDrive {
    public static void main(String[] args) {
        GumballMachine gumballMachine = new GumballMachine(5);

        gumballMachine.insertQuarter();
        gumballMachine.turnCrank();

        gumballMachine.insertQuarter();
        gumballMachine.ejectQuarter();

        gumballMachine.insertQuarter();
        gumballMachine.turnCrank();
        gumballMachine.insertQuarter();
        gumballMachine.turnCrank();
    }
}
```

---

### **6. Benefits of State Pattern**

- ✅ **Encapsulation of behavior per state** — No big `if-else` chains.
- 🔄 **Easy to change behavior** — Just change the state object.
- 🔧 **Open/Closed Principle** — Add new states without changing existing code.
- 🤝 **Delegation** — Cleaner `Context` class that delegates behavior to states.

---

### **7. Trade-Offs**

- 📂 **More Classes** — One class per state.
- 🧭 **Indirection** — Behavior is split across classes; harder to follow for beginners.
- 🧪 **Testing Overhead** — Each state must be tested individually.

---

### 📌 When to Use the State Pattern

- Game character behavior (walking, jumping, idle).
- UI widgets with modes (enabled, disabled, focused).
- Protocols (e.g., TCP: LISTEN → ESTABLISHED → CLOSED).
- Vending machines, ATMs, traffic lights.