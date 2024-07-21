using Decorator.Abstract;

namespace Decorator.Concrete
{
    internal class DarkRoast : Beverage
    {
        public override double Cost()
        {
            return 0.76;
        }

        public override string GetDescription()
        {
            return "DarkRoast";
        }
    }
}
