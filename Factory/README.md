### **Factory Method Pattern**

**Intent**: Define an interface for creating an object, but let subclasses decide which class to instantiate. Factory Method lets a class defer instantiation to subclasses.

#### **Key Concepts**:

1. **Creator Class**: 
   - Defines the factory method, which returns an object of type `Product`. 
   - Often provides a default implementation of the factory method that returns a generic `Product`.
   - Subclasses override the factory method to return specific `Product` instances.

2. **Concrete Creators**:
   - Subclasses of the `Creator` class.
   - Implement the factory method to instantiate and return specific `Product` objects.

3. **Product**:
   - Defines the interface for objects the factory method creates.

4. **Concrete Products**:
   - Implement the `Product` interface.
   - Are the actual objects returned by the factory method in `ConcreteCreator` classes.

#### **Example: Pizza Creation**

#### **Step 1: Define the Product Interface or Abstract Class**

First, define an abstract class or an interface that represents the product. In our pizza example, this would be the `Pizza` class.

```java
public abstract class Pizza {
    public abstract void prepare();
    public abstract void bake();
    public abstract void cut();
    public abstract void box();
}
```

#### **Step 2: Create Concrete Products**

Next, create concrete classes that implement or extend the `Pizza` class.

```java
public class CheesePizza extends Pizza {
    @Override
    public void prepare() {
        System.out.println("Preparing Cheese Pizza");
    }

    @Override
    public void bake() {
        System.out.println("Baking Cheese Pizza");
    }

    @Override
    public void cut() {
        System.out.println("Cutting Cheese Pizza");
    }

    @Override
    public void box() {
        System.out.println("Boxing Cheese Pizza");
    }
}

public class VeggiePizza extends Pizza {
    @Override
    public void prepare() {
        System.out.println("Preparing Veggie Pizza");
    }

    @Override
    public void bake() {
        System.out.println("Baking Veggie Pizza");
    }

    @Override
    public void cut() {
        System.out.println("Cutting Veggie Pizza");
    }

    @Override
    public void box() {
        System.out.println("Boxing Veggie Pizza");
    }
}
```

#### **Step 3: Define the Creator Abstract Class**

Now, define an abstract class that declares the factory method. This class may also have some operations that depend on the product created by the factory method.

```java
public abstract class PizzaFactory {
    public abstract Pizza createPizza(String type);
}
```

#### **Step 4: Implement Concrete Creators**

Each concrete creator will implement the factory method to create the appropriate product.

```java
public class SimplePizzaFactory extends PizzaFactory {
    @Override
    public Pizza createPizza(String type) {
        Pizza pizza = null;

        if (type.equals("cheese")) {
            pizza = new CheesePizza();
        } else if (type.equals("veggie")) {
            pizza = new VeggiePizza();
        }

        return pizza;
    }
}
```

#### **Step 5: Client Code**

Finally, the client code interacts with the factory to create objects.

```java
public class PizzaStore {
    public static void main(String[] args) {
        PizzaFactory factory = new SimplePizzaFactory();

        Pizza cheesePizza = factory.createPizza("cheese");
        cheesePizza.prepare();
        cheesePizza.bake();
        cheesePizza.cut();
        cheesePizza.box();

        Pizza veggiePizza = factory.createPizza("veggie");
        veggiePizza.prepare();
        veggiePizza.bake();
        veggiePizza.cut();
        veggiePizza.box();
    }
}
```

### **Explanation:**

1. **`Pizza` Class**: An abstract class that defines the operations that all pizzas should have.
  
2. **Concrete Pizza Classes**: `CheesePizza` and `VeggiePizza` are concrete implementations of `Pizza`.

3. **`PizzaFactory` Abstract Class**: Declares the factory method `createPizza`, which must be implemented by subclasses.

4. **`SimplePizzaFactory` Concrete Class**: Implements the `createPizza` method to create specific types of pizzas.

5. **Client Code**: Uses the `PizzaFactory` to create pizzas without worrying about the exact class to instantiate.

This Java example correctly reflects the Factory Method pattern, where the factory method is responsible for creating product objects.

### **Benefits**:
- **Flexibility**: The client code is decoupled from the concrete products, making the system more flexible and scalable.
- **Single Responsibility Principle**: The code that creates the object is separated from the code that uses the object.

### **Drawbacks**:
- **Code Complexity**: Requires the creation of a subclass for each type of product, which can lead to an increase in the number of classes.
  
### **When to Use**:
- When a class cannot anticipate the class of objects it must create.
- When a class wants its subclasses to specify the objects it creates.
- When the responsibility of object creation needs to be delegated to one of several helper subclasses, and you want to localize the knowledge of which helper subclass is the delegate.
