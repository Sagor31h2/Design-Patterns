using Decorator.Abstract;

namespace Decorator.Concrete
{
    internal class Espresso : Beverage
    {

        public override double Cost()
        {
            return 1.99;
        }

        public override string GetDescription()
        {
            return "Espresso";
        }
    }
}
