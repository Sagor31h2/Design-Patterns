using Decorator;
using Factory;
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
                Console.WriteLine("Please Choose Enter a number in range:\n");

                var input = Console.ReadLine();

                if (string.IsNullOrWhiteSpace(input))
                {
                    Console.WriteLine("You didn't provide any input\n");
                    continue;

                }

                var number = Convert.ToInt32(input.Trim());
                if (number == 1)
                {
                    var ob = new ObserverTestingConsole();
                    ob.Test();
                }
                else if (number == 2)
                {
                    var st = new StrategyTesingConsole();
                    st.Test();
                }
                else if (number == 3)
                {
                    new DecoratorConsoleTest().Test();

                }
                else if (number == 4)
                {
                    new FactoryTest().Test();
                }
            }
        }
    }
}
