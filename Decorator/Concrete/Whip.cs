using Decorator.Abstract;

namespace Decorator.Concrete
{
    internal class Whip : CondimentDecorator
    {
        public Whip(Beverage beverage)
        {
            this.beverage = beverage;
        }
        public override double Cost()
        {
            return beverage.Cost() + 0.29;
        }

        public override string GetDescription()
        {

            return $"{beverage.GetDescription()}, Whip";
        }
    }
}
