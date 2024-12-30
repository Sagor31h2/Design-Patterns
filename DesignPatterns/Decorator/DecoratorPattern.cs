using System;

namespace DesignPatterns.Decorator;

// Component Interface
public interface IBeverage
{
    string GetDescription();
    double GetCost();
}

// Concrete Component - Espresso
public class Espresso : IBeverage
{
    public string GetDescription() => "Espresso";
    public double GetCost() => 1.99;
}

// Concrete Component - House Blend
public class HouseBlend : IBeverage
{
    public string GetDescription() => "House Blend Coffee";
    public double GetCost() => 0.89;
}

// Abstract Decorator
public abstract class CondimentDecorator : IBeverage
{
    protected IBeverage _beverage;

    public CondimentDecorator(IBeverage beverage) => _beverage = beverage;

    public abstract string GetDescription();
    public abstract double GetCost();
}

// Concrete Decorator - Milk
public class Milk : CondimentDecorator
{
    public Milk(IBeverage beverage) : base(beverage) { }

    public override string GetDescription() => _beverage.GetDescription() + ", Milk";
    public override double GetCost() => _beverage.GetCost() + 0.10;
}

// Concrete Decorator - Mocha
public class Mocha : CondimentDecorator
{
    public Mocha(IBeverage beverage) : base(beverage) { }

    public override string GetDescription() => _beverage.GetDescription() + ", Mocha";
    public override double GetCost() => _beverage.GetCost() + 0.20;
}

// Concrete Decorator - Whip
public class Whip : CondimentDecorator
{
    public Whip(IBeverage beverage) : base(beverage) { }

    public override string GetDescription() => _beverage.GetDescription() + ", Whip";
    public override double GetCost() => _beverage.GetCost() + 0.30;
}

// Client
public class DecoratorPatternConsole
{
    public void Test()
    {
        // Order an Espresso with Milk and Mocha
        IBeverage beverage = new Espresso();
        Console.WriteLine($"{beverage.GetDescription()} ${beverage.GetCost():0.00}");

        beverage = new Milk(beverage);
        Console.WriteLine($"{beverage.GetDescription()} ${beverage.GetCost():0.00}");

        beverage = new Mocha(beverage);
        Console.WriteLine($"{beverage.GetDescription()} ${beverage.GetCost():0.00}");

        // Order a House Blend with Mocha and Whip
        IBeverage houseBlend = new HouseBlend();
        Console.WriteLine($"{houseBlend.GetDescription()} ${houseBlend.GetCost():0.00}");

        houseBlend = new Mocha(houseBlend);
        Console.WriteLine($"{houseBlend.GetDescription()} ${houseBlend.GetCost():0.00}");

        houseBlend = new Whip(houseBlend);
        Console.WriteLine($"{houseBlend.GetDescription()} ${houseBlend.GetCost():0.00}");
    }
}

