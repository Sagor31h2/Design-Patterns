using Decorator.Abstract;

namespace Decorator.Concrete
{
    internal class Soy : CondimentDecorator
    {
        public Soy(Beverage beverage)
        {
            this.beverage = beverage;
        }
        public override double Cost()
        {
            return beverage.Cost() + 0.20;
        }

        public override string GetDescription()
        {
            return beverage.GetDescription() + "Soy";
        }
    }
}
