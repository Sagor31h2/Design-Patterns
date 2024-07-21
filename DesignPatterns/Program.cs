using Observer;

namespace DesignPatterns
{
    internal class Program
    {
        static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            var ob =new ObserverTestingConsole();
            ob.Test();
        }
    }
}
