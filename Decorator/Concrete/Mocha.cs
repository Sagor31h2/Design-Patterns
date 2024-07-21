using Decorator.Abstract;

namespace Decorator.Concrete
{
    internal class Mocha : CondimentDecorator
    {
        public Mocha(Beverage beverage)
        {
            this.beverage = beverage;
        }
        public override double Cost()
        {
            return beverage.Cost() + 0.20;
        }

        public override string GetDescription()
        {
            var contcate = $"{beverage.GetDescription()}, Mocha";
            return contcate;
        }
    }
}
