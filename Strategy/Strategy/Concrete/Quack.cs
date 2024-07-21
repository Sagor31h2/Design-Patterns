using Strategy.Abstract;

namespace Strategy.Concrete
{
    internal class Quack : IQuackBehavior
    {
        void IQuackBehavior.Quack()
        {
            Console.WriteLine("quack");
        }
    }
}
