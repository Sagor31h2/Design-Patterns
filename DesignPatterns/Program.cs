﻿using AbstractFactory;
using DesignPatterns.CommandPattern;
using DesignPatterns.Decorator;
using DesignPatterns.Factory;
using Observer;
using Strategy;

namespace DesignPatterns
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Welcome to Head First Design Playground\n");

            while (true)
            {
                Console.WriteLine("Please choose design pattern to test:\n");
                Console.WriteLine("1. Observer Pattern");
                Console.WriteLine("2. Strategy Pattern");
                Console.WriteLine("3. Decorator Pattern");
                Console.WriteLine("4. Factory Pattern");
                Console.WriteLine("5. Abstract Factory Pattern");

                var input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("You didn't provide any input\n");
                    continue;
                }

                var number = Convert.ToInt32(input.Trim());
                switch (number)
                {
                    case 1:
                        var ob = new ObserverTestingConsole();
                        ob.Test();
                        break;
                    case 2:
                        var st = new StrategyTesingConsole();
                        st.Test();
                        break;
                    case 3:
                        new DecoratorPatternConsole().Test();
                        break;
                    case 4:
                        new FactoryPatternConsole().Test();
                        break;
                    case 5:
                        new AbstractFactoryTest().Test();
                        break;
                    case 6:
                        new CommandPatternConsole().Test();
                        break;
                    default:
                        Console.WriteLine("You provided wrong input\n");
                        break;
                }
            }
        }
    }
}
