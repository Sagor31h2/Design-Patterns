using System;
using System.Collections.Generic;
namespace DesignPatterns.CommandPattern;

// ----------- Observer Interfaces -----------

public interface IObserver
{
    void Update(IQuackObservable duck);
}

public interface IQuackObservable
{
    void RegisterObserver(IObserver observer);
    void NotifyObservers();
}

// ----------- Component Interface -----------

public interface IQuackable : IQuackObservable
{
    void Quack();
}

// ----------- Observable Helper Class -----------

public class Observable : IQuackObservable
{
    private readonly List<IObserver> _observers = new();
    private readonly IQuackObservable _duck;

    public Observable(IQuackObservable duck)
    {
        _duck = duck;
    }

    public void RegisterObserver(IObserver observer)
    {
        _observers.Add(observer);
    }

    public void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.Update(_duck);
        }
    }
}

// ----------- Concrete Ducks -----------

public class MallardDuck : IQuackable
{
    private readonly Observable _observable;

    public MallardDuck()
    {
        _observable = new Observable(this);
    }

    public void Quack()
    {
        Console.WriteLine("Mallard Duck: Quack");
        NotifyObservers();
    }

    public void RegisterObserver(IObserver observer) => _observable.RegisterObserver(observer);
    public void NotifyObservers() => _observable.NotifyObservers();
    public override string ToString() => "Mallard Duck";
}

public class RedheadDuck : IQuackable
{
    private readonly Observable _observable;

    public RedheadDuck()
    {
        _observable = new Observable(this);
    }

    public void Quack()
    {
        Console.WriteLine("Redhead Duck: Quack");
        NotifyObservers();
    }

    public void RegisterObserver(IObserver observer) => _observable.RegisterObserver(observer);
    public void NotifyObservers() => _observable.NotifyObservers();
    public override string ToString() => "Redhead Duck";
}

public class RubberDuck : IQuackable
{
    private readonly Observable _observable;

    public RubberDuck()
    {
        _observable = new Observable(this);
    }

    public void Quack()
    {
        Console.WriteLine("Rubber Duck: Squeak");
        NotifyObservers();
    }

    public void RegisterObserver(IObserver observer) => _observable.RegisterObserver(observer);
    public void NotifyObservers() => _observable.NotifyObservers();
    public override string ToString() => "Rubber Duck";
}

// ----------- Goose and Adapter -----------

public class Goose
{
    public void Honk()
    {
        Console.WriteLine("Goose: Honk");
    }
}

public class GooseAdapter : IQuackable
{
    private readonly Goose _goose;
    private readonly Observable _observable;

    public GooseAdapter(Goose goose)
    {
        _goose = goose;
        _observable = new Observable(this);
    }

    public void Quack()
    {
        _goose.Honk(); // Adapting goose behavior to duck's Quack
        NotifyObservers();
    }

    public void RegisterObserver(IObserver observer) => _observable.RegisterObserver(observer);
    public void NotifyObservers() => _observable.NotifyObservers();
    public override string ToString() => "Goose pretending to be a Duck";
}

// ----------- Decorator: QuackCounter -----------

public class QuackCounter : IQuackable
{
    private readonly IQuackable _duck;
    private static int _numberOfQuacks = 0;

    public QuackCounter(IQuackable duck)
    {
        _duck = duck;
    }

    public void Quack()
    {
        _duck.Quack();
        _numberOfQuacks++;
    }

    public static int GetQuacks() => _numberOfQuacks;

    public void RegisterObserver(IObserver observer) => _duck.RegisterObserver(observer);
    public void NotifyObservers() => _duck.NotifyObservers();
    public override string ToString() => _duck.ToString();
}

// ----------- Composite: Flock -----------

public class Flock : IQuackable
{
    private readonly List<IQuackable> _quackers = new();

    public void Add(IQuackable quacker)
    {
        _quackers.Add(quacker);
    }

    public void Quack()
    {
        foreach (var quacker in _quackers)
        {
            quacker.Quack(); // Each duck in the flock quacks
        }
    }

    public void RegisterObserver(IObserver observer)
    {
        foreach (var quacker in _quackers)
        {
            quacker.RegisterObserver(observer);
        }
    }

    public void NotifyObservers() { /* Not used directly in composite */ }

    public override string ToString() => "Flock of Ducks";
}

// ----------- Abstract Factory -----------

public abstract class AbstractDuckFactory
{
    public abstract IQuackable CreateMallardDuck();
    public abstract IQuackable CreateRedheadDuck();
    public abstract IQuackable CreateRubberDuck();
}

public class CountingDuckFactory : AbstractDuckFactory
{
    public override IQuackable CreateMallardDuck() => new QuackCounter(new MallardDuck());
    public override IQuackable CreateRedheadDuck() => new QuackCounter(new RedheadDuck());
    public override IQuackable CreateRubberDuck() => new QuackCounter(new RubberDuck());
}

// ----------- Observer: Quackologist -----------

public class Quackologist : IObserver
{
    public void Update(IQuackObservable duck)
    {
        Console.WriteLine("Quackologist: " + duck + " just quacked.");
    }
}

// ----------- Simulation Entry Point -----------

public class DuckSimulator
{
    public void Test()
    {
        DuckSimulator simulator = new();
        AbstractDuckFactory duckFactory = new CountingDuckFactory();

        simulator.Simulate(duckFactory);
    }

    private void Simulate(AbstractDuckFactory duckFactory)
    {
        // Create individual ducks
        IQuackable mallardDuck = duckFactory.CreateMallardDuck();
        IQuackable redheadDuck = duckFactory.CreateRedheadDuck();
        IQuackable rubberDuck = duckFactory.CreateRubberDuck();
        IQuackable gooseDuck = new GooseAdapter(new Goose());

        // Create main flock
        Flock flockOfDucks = new();
        flockOfDucks.Add(mallardDuck);
        flockOfDucks.Add(redheadDuck);
        flockOfDucks.Add(rubberDuck);
        flockOfDucks.Add(gooseDuck);

        // Create a subflock of mallards
        Flock flockOfMallards = new();
        for (int i = 0; i < 4; i++)
        {
            flockOfMallards.Add(duckFactory.CreateMallardDuck());
        }

        flockOfDucks.Add(flockOfMallards);

        // Add observer
        Quackologist quackologist = new();
        flockOfDucks.RegisterObserver(quackologist);

        Console.WriteLine("\nDuck Simulator: With Observer & Flocks");
        Simulate(flockOfDucks);

        Console.WriteLine($"\nThe ducks quacked {QuackCounter.GetQuacks()} times.");
    }

    private void Simulate(IQuackable duck)
    {
        duck.Quack();
    }
}
