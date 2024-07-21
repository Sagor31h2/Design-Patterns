using Decorator.Abstract;

namespace Decorator.Concrete
{
    internal class HouseBlend : Beverage
    {
        public override double Cost()
        {
            return 0.89;
        }

        public override string GetDescription()
        {
            return "HouseBlend!";
        }
    }
}
