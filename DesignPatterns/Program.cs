using Strategy;

namespace DesignPatterns
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            Console.WriteLine("Hello, World!");

            //var ob =new ObserverTestingConsole();
            //ob.Test();

            var st = new StrategyTesingConsole();
            st.Test();
        }
    }
}
