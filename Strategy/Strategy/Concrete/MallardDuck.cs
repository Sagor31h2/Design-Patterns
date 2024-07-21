using Strategy.Abstract;

namespace Strategy.Concrete
{
    internal class MallardDuck : Duck
    {
        public MallardDuck()
        {
            quackBehavior = new Quack();
            flyBehavior = new FlyWithWings();
        }
        public override void Display()
        {
            Console.WriteLine("I'm real mallard Duck!");
        }
    }
}
