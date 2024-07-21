using Strategy.Abstract;

namespace Strategy.Concrete
{
    internal class ModelDuck : Duck
    {
        public ModelDuck()
        {
            flyBehavior = new FlyNoWay();
            quackBehavior = new Quack();
        }
        public override void Display()
        {
            Console.WriteLine("I'm Model Duck");
        }
    }
}
