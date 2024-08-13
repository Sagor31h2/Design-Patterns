using Factory.Abstract;

namespace Factory.Concrete
{
    internal class CheesePizza : Pizza
    {
        public override void Prepare()
        {
            Console.WriteLine("Preparing Cheese Pizza");
        }

        public override void Bake()
        {
            Console.WriteLine("Baking Cheese Pizza");
        }

        public override void Cut()
        {
            Console.WriteLine("Cutting Cheese Pizza");
        }

        public override void Box()
        {
            Console.WriteLine("Boxing Cheese Pizza");
        }

    }
}
