using Strategy.Abstract;

namespace Strategy.Concrete
{
    internal class FlyNoWay : IFlyBehavior
    {
        public void Fly()
        {
            Console.WriteLine("I can't fly!!");
        }
    }
}
