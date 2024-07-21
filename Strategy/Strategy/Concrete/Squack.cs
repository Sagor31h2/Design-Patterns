using Strategy.Abstract;

namespace Strategy.Concrete
{
    internal class Squack : IQuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine("Squack!");
        }
    }
}
