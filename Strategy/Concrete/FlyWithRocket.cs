using Strategy.Abstract;

namespace Strategy.Concrete
{
    internal class FlyWithRocket : IFlyBehavior
    {
        public void Fly()
        {
            Console.WriteLine("Flying with Rocket");
        }
    }
}
