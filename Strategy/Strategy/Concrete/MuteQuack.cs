using Strategy.Abstract;

namespace Strategy.Concrete
{
    internal class MuteQuack : IQuackBehavior
    {
        public void Quack()
        {
            Console.WriteLine("Slience!");
        }
    }
}
