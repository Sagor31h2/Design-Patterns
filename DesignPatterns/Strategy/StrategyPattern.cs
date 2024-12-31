using System;

namespace DesignPatterns.Strategy;
// Strategy Interface
public interface IQuackBehavior
{
    void Quack();
}

// Concrete Strategies
public class NormalQuack : IQuackBehavior
{
    public void Quack() => Console.WriteLine("Quack! Quack!");
}

public class Squeak : IQuackBehavior
{
    public void Quack() => Console.WriteLine("Squeak!");
}

public class Silent : IQuackBehavior
{
    public void Quack() => Console.WriteLine("<< Silence >>");
}

// Strategy Interface
public interface IFlyBehavior
{
    void Fly();
}

// Concrete Strategies
public class FlyWithWings : IFlyBehavior
{
    public void Fly() => Console.WriteLine("I'm flying with wings!");
}

public class FlyNoWay : IFlyBehavior
{
    public void Fly() => Console.WriteLine("I can't fly!");
}

public class FlyRocketPowered : IFlyBehavior
{
    public void Fly() => Console.WriteLine("I'm flying with a rocket!");
}

// Context Class - Duck
public abstract class Duck
{
    protected IQuackBehavior _quackBehavior;
    protected IFlyBehavior _flyBehavior;

    public void SetQuackBehavior(IQuackBehavior quackBehavior) => _quackBehavior = quackBehavior;
    public void SetFlyBehavior(IFlyBehavior flyBehavior) => _flyBehavior = flyBehavior;

    public void PerformQuack() => _quackBehavior.Quack();
    public void PerformFly() => _flyBehavior.Fly();

    public abstract void Display();

    public void Swim() => Console.WriteLine("All ducks float, even decoys!");
}

// Concrete Ducks
public class MallardDuck : Duck
{
    public MallardDuck()
    {
        _quackBehavior = new NormalQuack();
        _flyBehavior = new FlyWithWings();
    }

    public override void Display() => Console.WriteLine("I'm a real Mallard duck!");
}

public class RubberDuck : Duck
{
    public RubberDuck()
    {
        _quackBehavior = new Squeak();
        _flyBehavior = new FlyNoWay();
    }

    public override void Display() => Console.WriteLine("I'm a rubber duck!");
}

public class DecoyDuck : Duck
{
    public DecoyDuck()
    {
        _quackBehavior = new Silent();
        _flyBehavior = new FlyNoWay();
    }

    public override void Display() => Console.WriteLine("I'm a decoy duck!");
}

// Client
public class StrategyPatternConsole
{
    public void Test()
    {
        Duck mallard = new MallardDuck();
        mallard.Display();
        mallard.PerformQuack();
        mallard.PerformFly();

        Console.WriteLine();

        Duck rubberDuck = new RubberDuck();
        rubberDuck.Display();
        rubberDuck.PerformQuack();
        rubberDuck.PerformFly();

        Console.WriteLine();

        Duck decoy = new DecoyDuck();
        decoy.Display();
        decoy.PerformQuack();
        decoy.PerformFly();

        Console.WriteLine("Now let's make the rubber duck fly like a rocket!");
        rubberDuck.SetFlyBehavior(new FlyRocketPowered());
        rubberDuck.PerformFly();
    }
}
