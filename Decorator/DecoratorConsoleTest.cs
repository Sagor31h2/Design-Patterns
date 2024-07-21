using Decorator.Abstract;
using Decorator.Concrete;

namespace Decorator
{
    public class DecoratorConsoleTest
    {
        public void Test()
        {
            Beverage beverage = new Espresso();
            Console.WriteLine($"Name {beverage.GetDescription()} and Cost {beverage.Cost()}");

            //new order 
            Beverage beverage2 = new DarkRoast();
            Console.WriteLine($"Name {beverage2.GetDescription()} and Cost {beverage2.Cost()}");

            beverage2 = new Mocha(beverage2);
            beverage2 = new Mocha(beverage2);
            beverage2 = new Whip(beverage2);

            Console.WriteLine($"Name {beverage2.GetDescription()} and Cost {beverage2.Cost()}");


        }
    }
}
