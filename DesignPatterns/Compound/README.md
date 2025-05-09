# 🧠 Compound Pattern Summary

---

## **1. Problem Statement**

You are building a **Duck Simulator**, where:

* Ducks quack.
* Some ducks should count their quacks.
* Some birds (like geese) don’t quack, but you want to include them anyway.
* Ducks should be observed for analytics (e.g., quack logging).
* Ducks and groups of ducks should behave the same way.

You realize that no single pattern covers all this. You need a combination — a **Compound Pattern**.

---

## **2. Solution: Combine Patterns**

To model this system, you **combine multiple patterns**:

| Pattern              | Purpose                                    |
| -------------------- | ------------------------------------------ |
| **Decorator**        | Wrap ducks to count quacks                 |
| **Adapter**          | Adapt `Goose` into a quacking `Duck`       |
| **Composite**        | Manage groups of ducks (flocks)            |
| **Abstract Factory** | Create families of duck objects            |
| **Observer**         | Allow observers to watch quacking behavior |

---

## **3. Step-by-Step Implementation**

---

### ✅ Interface: `Quackable`

Every quacking object (ducks, goose adapter, flock) implements this:

```java
public interface Quackable extends QuackObservable {
    void quack();
}
```

---

### 🦆 Concrete Duck: `MallardDuck`

```java
public class MallardDuck implements Quackable {
    Observable observable;

    public MallardDuck() {
        observable = new Observable(this);
    }

    public void quack() {
        System.out.println("Quack");
        notifyObservers();
    }

    public void registerObserver(Observer observer) {
        observable.registerObserver(observer);
    }

    public void notifyObservers() {
        observable.notifyObservers();
    }
}
```

* `Observable` handles the observer logic.
* Ducks delegate observer management to it.

---

### 🎛️ Decorator: `QuackCounter`

Adds quack-counting behavior to ducks:

```java
public class QuackCounter implements Quackable {
    Quackable duck;
    static int numberOfQuacks;

    public QuackCounter(Quackable duck) {
        this.duck = duck;
    }

    public void quack() {
        duck.quack();
        numberOfQuacks++;
    }

    public static int getQuacks() {
        return numberOfQuacks;
    }

    public void registerObserver(Observer observer) {
        duck.registerObserver(observer);
    }

    public void notifyObservers() {
        duck.notifyObservers();
    }
}
```

* Counts total quacks.
* Forwards observer logic to wrapped duck.

---

### 🪿 Adapter: `GooseAdapter`

Adapts a `Goose` to the `Quackable` interface:

```java
public class GooseAdapter implements Quackable {
    Goose goose;
    Observable observable;

    public GooseAdapter(Goose goose) {
        this.goose = goose;
        observable = new Observable(this);
    }

    public void quack() {
        goose.honk();
        notifyObservers();
    }

    public void registerObserver(Observer observer) {
        observable.registerObserver(observer);
    }

    public void notifyObservers() {
        observable.notifyObservers();
    }
}
```

---

### 🧩 Composite: `Flock`

Groups any `Quackable`s into a unit that itself quacks:

```java
import java.util.ArrayList;
import java.util.Iterator;
import java.util.List;

public class Flock implements Quackable {
    List<Quackable> quackers = new ArrayList<>();

    public void add(Quackable quacker) {
        quackers.add(quacker);
    }

    public void quack() {
        for (Quackable quacker : quackers) {
            quacker.quack();
        }
    }

    public void registerObserver(Observer observer) {
        for (Quackable quacker : quackers) {
            quacker.registerObserver(observer);
        }
    }

    public void notifyObservers() {
        // Composite delegates to individual quackers
    }
}
```

---

### 🏭 Abstract Factory: `DuckFactory` and `CountingDuckFactory`

```java
public abstract class AbstractDuckFactory {
    public abstract Quackable createMallardDuck();
    public abstract Quackable createRedheadDuck();
    public abstract Quackable createDuckCall();
    public abstract Quackable createRubberDuck();
}

public class CountingDuckFactory extends AbstractDuckFactory {
    public Quackable createMallardDuck() {
        return new QuackCounter(new MallardDuck());
    }

    public Quackable createRedheadDuck() {
        return new QuackCounter(new RedheadDuck());
    }

    public Quackable createDuckCall() {
        return new QuackCounter(new DuckCall());
    }

    public Quackable createRubberDuck() {
        return new QuackCounter(new RubberDuck());
    }
}
```

* Allows creating decorated ducks consistently.
* You can swap factories to change duck creation strategy.

---

### 👂 Observer Support

#### `Observer` and `Observable`:

```java
public interface Observer {
    void update(QuackObservable duck);
}

public class Observable implements QuackObservable {
    List<Observer> observers = new ArrayList<>();
    QuackObservable duck;

    public Observable(QuackObservable duck) {
        this.duck = duck;
    }

    public void registerObserver(Observer observer) {
        observers.add(observer);
    }

    public void notifyObservers() {
        for (Observer observer : observers) {
            observer.update(duck);
        }
    }
}
```

#### `Quackologist`:

```java
public class Quackologist implements Observer {
    public void update(QuackObservable duck) {
        System.out.println("Quackologist: " + duck + " just quacked.");
    }
}
```

---

### 🧪 Simulation Code

```java
public class DuckSimulator {
    public void simulate(AbstractDuckFactory duckFactory) {
        Quackable mallardDuck = duckFactory.createMallardDuck();
        Quackable redheadDuck = duckFactory.createRedheadDuck();
        Quackable duckCall = duckFactory.createDuckCall();
        Quackable rubberDuck = duckFactory.createRubberDuck();
        Quackable gooseDuck = new GooseAdapter(new Goose());

        Flock flockOfDucks = new Flock();
        flockOfDucks.add(mallardDuck);
        flockOfDucks.add(redheadDuck);
        flockOfDucks.add(duckCall);
        flockOfDucks.add(rubberDuck);
        flockOfDucks.add(gooseDuck);

        Quackologist quackologist = new Quackologist();
        flockOfDucks.registerObserver(quackologist);

        simulate(flockOfDucks);

        System.out.println("The ducks quacked " + QuackCounter.getQuacks() + " times");
    }

    void simulate(Quackable duck) {
        duck.quack();
    }
}
```

---

## ✅ Benefits of the Compound Pattern

* **High Flexibility**: Each pattern solves a specific need.
* **Reusable**: Components (e.g., `QuackCounter`) are reusable and composable.
* **Decoupled Design**: You can change or add new duck types easily.
* **Powerful Integration**: Observer + Decorator + Composite leads to rich behavior.

---

## ⚠️ Trade-offs

* **Complexity**: Takes effort to coordinate multiple patterns.
* **More Classes**: Adds many layers and indirection.

---

## 🏁 Final Thoughts

The **Compound Pattern** shows the real strength of design patterns: **combining them**. Each pattern brings its own power, and together, they help you build systems that are:

* **Flexible**
* **Extensible**
* **Robust**
* **Fun to simulate 🦆**

> *“Design Patterns are meant to be used together — just like ducks in a flock.”*

