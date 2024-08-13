using Factory.Abstract;

namespace Factory.Concrete
{
    internal class VeggiePizza : Pizza
    {
        public override void Prepare()
        {
            Console.WriteLine("Preparing Veggie Pizza");
        }

        public override void Bake()
        {
            Console.WriteLine("Baking Veggie Pizza");
        }

        public override void Cut()
        {
            Console.WriteLine("Cutting Veggie Pizza");
        }

        public override void Box()
        {
            Console.WriteLine("Boxing Veggie Pizza");
        }
    }
}
