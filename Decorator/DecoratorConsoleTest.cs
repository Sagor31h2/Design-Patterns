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
            // DarkRoast+ double Moucha+ Whip
            Beverage beverage2 = new DarkRoast();
            beverage2 = new Mocha(beverage2);
            beverage2 = new Mocha(beverage2);
            beverage2 = new Whip(beverage2);
            Console.WriteLine($"Name {beverage2.GetDescription()} and Cost {beverage2.Cost()}");


            /*
             * new order, HouseBlend+ soy, whip, moucha
             */
            var houseBlend = new HouseBlend();
            var moucha = new Mocha(houseBlend);
            var soy = new Soy(moucha);
            var whip = new Whip(soy);
            Console.WriteLine($"Name {whip.GetDescription()} and Cost {whip.Cost()}");


        }
    }
}
