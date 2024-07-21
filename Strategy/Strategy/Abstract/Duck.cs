namespace Strategy.Abstract
{
    internal abstract class Duck
    {
        protected IFlyBehavior flyBehavior;
        protected IQuackBehavior quackBehavior;
        public abstract void Display();

        public void PerfromFly()
        {
            flyBehavior.Fly();
        }

        public void PerfromQuack()
        {
            quackBehavior.Quack();
        }

        public void Swim()
        {
            Console.WriteLine("All ducks swim, even decoy!");
        }

        public void SetFlyBehavior(IFlyBehavior fb)
        {
            flyBehavior = fb;
        }

        public void SetQuackBehavior(IQuackBehavior qb)
        {
            quackBehavior = qb;
        }

    }
}
