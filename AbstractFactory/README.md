### **Factory Method Example: Pizza Store**

**Scenario:**
Imagine you’re tasked with designing a system for a pizza store that has different branches (e.g., New York, Chicago). Each branch has its own style of making pizzas, but the overall process of ordering a pizza is the same.

#### **Key Components:**

1. **`Pizza` Class:**
   This is an abstract class that represents a general pizza. It has methods like `prepare()`, `bake()`, `cut()`, and `box()` which all pizzas need to implement.

   ```java
   public abstract class Pizza {
       String name;
       String dough;
       String sauce;

       void prepare() {
           System.out.println("Preparing " + name);
       }

       void bake() {
           System.out.println("Baking " + name);
       }

       void cut() {
           System.out.println("Cutting " + name);
       }

       void box() {
           System.out.println("Boxing " + name);
       }

       public String getName() {
           return name;
       }
   }
   ```

2. **Concrete `Pizza` Subclasses:**
   These classes represent specific types of pizzas. For example, `NYStyleCheesePizza` and `ChicagoStyleCheesePizza`.

   ```java
   public class NYStyleCheesePizza extends Pizza {
       public NYStyleCheesePizza() {
           name = "NY Style Sauce and Cheese Pizza";
           dough = "Thin Crust Dough";
           sauce = "Marinara Sauce";
       }
   }

   public class ChicagoStyleCheesePizza extends Pizza {
       public ChicagoStyleCheesePizza() {
           name = "Chicago Style Deep Dish Cheese Pizza";
           dough = "Extra Thick Crust Dough";
           sauce = "Plum Tomato Sauce";
       }

       void cut() {
           System.out.println("Cutting the pizza into square slices");
       }
   }
   ```

3. **`PizzaStore` Class:**
   This is an abstract class that defines the `orderPizza()` method. The actual creation of pizzas is delegated to the `createPizza()` method, which is a factory method.

   ```java
   public abstract class PizzaStore {

       public Pizza orderPizza(String type) {
           Pizza pizza = createPizza(type);

           pizza.prepare();
           pizza.bake();
           pizza.cut();
           pizza.box();

           return pizza;
       }

       protected abstract Pizza createPizza(String type);
   }
   ```

4. **Concrete `PizzaStore` Subclasses:**
   These subclasses implement the `createPizza()` method to create pizzas specific to each style (e.g., New York or Chicago).

   ```java
   public class NYPizzaStore extends PizzaStore {

       protected Pizza createPizza(String item) {
           if (item.equals("cheese")) {
               return new NYStyleCheesePizza();
           } else if (item.equals("veggie")) {
               return new NYStyleVeggiePizza();
           } else if (item.equals("clam")) {
               return new NYStyleClamPizza();
           } else if (item.equals("pepperoni")) {
               return new NYStylePepperoniPizza();
           } else return null;
       }
   }

   public class ChicagoPizzaStore extends PizzaStore {

       protected Pizza createPizza(String item) {
           if (item.equals("cheese")) {
               return new ChicagoStyleCheesePizza();
           } else if (item.equals("veggie")) {
               return new ChicagoStyleVeggiePizza();
           } else if (item.equals("clam")) {
               return new ChicagoStyleClamPizza();
           } else if (item.equals("pepperoni")) {
               return new ChicagoStylePepperoniPizza();
           } else return null;
       }
   }
   ```

5. **Using the Factory Method:**
   The client code creates instances of `PizzaStore` and orders pizzas. The concrete subclass determines the type of pizza to create.

   ```java
   public class PizzaTestDrive {
       public static void main(String[] args) {
           PizzaStore nyStore = new NYPizzaStore();
           PizzaStore chicagoStore = new ChicagoPizzaStore();

           Pizza pizza = nyStore.orderPizza("cheese");
           System.out.println("Ethan ordered a " + pizza.getName() + "\n");

           pizza = chicagoStore.orderPizza("cheese");
           System.out.println("Joel ordered a " + pizza.getName() + "\n");
       }
   }
   ```

**Summary:**
The Factory Method pattern lets you define an interface for creating an object, but allows subclasses to alter the type of objects that will be created. It encapsulates the instantiation of concrete types within subclasses, adhering to the Open/Closed Principle.

---

### **Abstract Factory Example: Pizza Ingredients**

**Scenario:**
Now, let’s consider that different regions not only have different styles of pizzas but also use different ingredients (e.g., different types of dough, sauce, cheese). The abstract factory pattern is used to create families of related or dependent objects without specifying their concrete classes.

#### **Key Components:**

1. **`PizzaIngredientFactory` Interface:**
   This is the abstract factory interface for creating the various ingredients needed for a pizza.

   ```java
   public interface PizzaIngredientFactory {
       public Dough createDough();
       public Sauce createSauce();
       public Cheese createCheese();
       public Veggies[] createVeggies();
       public Pepperoni createPepperoni();
       public Clams createClams();
   }
   ```

2. **Concrete Ingredient Factory:**
   These classes implement the `PizzaIngredientFactory` interface and provide the specific ingredients for each region (e.g., New York or Chicago).

   ```java
   public class NYPizzaIngredientFactory implements PizzaIngredientFactory {

       public Dough createDough() {
           return new ThinCrustDough();
       }

       public Sauce createSauce() {
           return new MarinaraSauce();
       }

       public Cheese createCheese() {
           return new ReggianoCheese();
       }

       public Veggies[] createVeggies() {
           Veggies veggies[] = { new Garlic(), new Onion(), new Mushroom(), new RedPepper() };
           return veggies;
       }

       public Pepperoni createPepperoni() {
           return new SlicedPepperoni();
       }

       public Clams createClams() {
           return new FreshClams();
       }
   }

   public class ChicagoPizzaIngredientFactory implements PizzaIngredientFactory {

       public Dough createDough() {
           return new ThickCrustDough();
       }

       public Sauce createSauce() {
           return new PlumTomatoSauce();
       }

       public Cheese createCheese() {
           return new MozzarellaCheese();
       }

       public Veggies[] createVeggies() {
           Veggies veggies[] = { new BlackOlives(), new Spinach(), new Eggplant() };
           return veggies;
       }

       public Pepperoni createPepperoni() {
           return new SlicedPepperoni();
       }

       public Clams createClams() {
           return new FrozenClams();
       }
   }
   ```

3. **Pizza Classes Using the Ingredient Factory:**
   The `Pizza` class now uses the `PizzaIngredientFactory` to get its ingredients, which makes the pizza creation process consistent with the regional styles.

   ```java
   public class CheesePizza extends Pizza {
       PizzaIngredientFactory ingredientFactory;

       public CheesePizza(PizzaIngredientFactory ingredientFactory) {
           this.ingredientFactory = ingredientFactory;
       }

       void prepare() {
           System.out.println("Preparing " + name);
           dough = ingredientFactory.createDough();
           sauce = ingredientFactory.createSauce();
           cheese = ingredientFactory.createCheese();
       }
   }
   ```

4. **Concrete Pizza Stores:**
   Each `PizzaStore` subclass uses the appropriate `PizzaIngredientFactory` to create region-specific ingredients for its pizzas.

   ```java
   public class NYPizzaStore extends PizzaStore {
       protected Pizza createPizza(String item) {
           Pizza pizza = null;
           PizzaIngredientFactory ingredientFactory =
               new NYPizzaIngredientFactory();

           if (item.equals("cheese")) {
               pizza = new CheesePizza(ingredientFactory);
               pizza.setName("New York Style Cheese Pizza");
           } else if (item.equals("veggie")) {
               pizza = new VeggiePizza(ingredientFactory);
               pizza.setName("New York Style Veggie Pizza");
           } // add other pizza types...

           return pizza;
       }
   }

   public class ChicagoPizzaStore extends PizzaStore {
       protected Pizza createPizza(String item) {
           Pizza pizza = null;
           PizzaIngredientFactory ingredientFactory =
               new ChicagoPizzaIngredientFactory();

           if (item.equals("cheese")) {
               pizza = new CheesePizza(ingredientFactory);
               pizza.setName("Chicago Style Cheese Pizza");
           } else if (item.equals("veggie")) {
               pizza = new VeggiePizza(ingredientFactory);
               pizza.setName("Chicago Style Veggie Pizza");
           } // add other pizza types...

           return pizza;
       }
   }
   ```

**Summary:**
The Abstract Factory pattern provides an interface for creating families of related or dependent objects without specifying their concrete classes. It’s useful when a system must be independent of how its objects are created, composed, and represented, and when it needs to work with multiple families of products.

By separating the product creation logic from the code that uses the products, the Abstract Factory pattern promotes flexibility and reusability in your designs.