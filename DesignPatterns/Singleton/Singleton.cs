using System;

namespace DesignPatterns.Singleton;
public sealed class Singleton
{
    // Private static instance - lazy initialization
    private static Singleton _instance;

    // Lock for thread safety
    private static readonly object _lock = new();

    // Private constructor to prevent instantiation
    private Singleton()
    {
        Console.WriteLine("Singleton instance created.");
    }

    // Public static method to get the single instance
    public static Singleton GetInstance()
    {
        if (_instance == null)
        {
            lock (_lock) // Ensure thread safety
            {
                if (_instance == null)
                {
                    _instance = new Singleton();
                }
            }
        }
        return _instance;
    }

    // Example method
    public void DoSomething() => Console.WriteLine("Singleton instance is working.");
}

// Client
public class SingletonPatternConsole
{
    public void Test()
    {
        Singleton instance1 = Singleton.GetInstance();
        Singleton instance2 = Singleton.GetInstance();

        // Both references point to the same instance
        Console.WriteLine(ReferenceEquals(instance1, instance2)); // True

        // Use the instance
        instance1.DoSomething();
    }
}
