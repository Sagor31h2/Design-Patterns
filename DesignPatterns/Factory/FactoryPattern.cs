using System;
namespace DesignPatterns.Factory;

// Product - Pizza
public abstract class Pizza
{
    public string Name { get; set; }
    public void Prepare() => Console.WriteLine($"Preparing {Name}");
    public void Bake() => Console.WriteLine($"Baking {Name}");
    public void Cut() => Console.WriteLine($"Cutting {Name}");
    public void Box() => Console.WriteLine($"Boxing {Name}");
}

// Concrete Products
public class CheesePizza : Pizza
{
    public CheesePizza() => Name = "Cheese Pizza";
}

public class PepperoniPizza : Pizza
{
    public PepperoniPizza() => Name = "Pepperoni Pizza";
}

public class VeggiePizza : Pizza
{
    public VeggiePizza() => Name = "Veggie Pizza";
}

// Creator - Pizza Factory
public abstract class PizzaStore
{
    public Pizza OrderPizza(string type)
    {
        Pizza pizza = CreatePizza(type);
        if (pizza == null)
        {
            Console.WriteLine($"Sorry, we don't make {type} pizza.");
            return null;
        }

        pizza.Prepare();
        pizza.Bake();
        pizza.Cut();
        pizza.Box();
        return pizza;
    }

    // Factory Method
    protected abstract Pizza CreatePizza(string type);
}

// Concrete Creator - NY Pizza Store
public class NYPizzaStore : PizzaStore
{
    protected override Pizza CreatePizza(string type)
    {
        return type.ToLower() switch
        {
            "cheese" => new CheesePizza(),
            "pepperoni" => new PepperoniPizza(),
            "veggie" => new VeggiePizza(),
            _ => null,
        };
    }
}

// Concrete Creator - Chicago Pizza Store
public class ChicagoPizzaStore : PizzaStore
{
    protected override Pizza CreatePizza(string type)
    {
        return type.ToLower() switch
        {
            "cheese" => new CheesePizza() { Name = "Chicago Style Cheese Pizza" },
            "pepperoni" => new PepperoniPizza() { Name = "Chicago Style Pepperoni Pizza" },
            "veggie" => new VeggiePizza() { Name = "Chicago Style Veggie Pizza" },
            _ => null,
        };
    }
}

// Client
public class FactoryPatternConsole
{
    public void Test()
    {
        PizzaStore nyStore = new NYPizzaStore();
        PizzaStore chicagoStore = new ChicagoPizzaStore();

        Console.WriteLine("\n--- Ordering a Cheese Pizza from NY Store ---");
        nyStore.OrderPizza("cheese");

        Console.WriteLine("\n--- Ordering a Pepperoni Pizza from Chicago Store ---");
        chicagoStore.OrderPizza("pepperoni");

        Console.WriteLine("\n--- Ordering a Veggie Pizza from NY Store ---");
        nyStore.OrderPizza("veggie");

        Console.WriteLine("\n--- Attempting to Order an Unknown Pizza ---");
        chicagoStore.OrderPizza("unknown");
    }
}
