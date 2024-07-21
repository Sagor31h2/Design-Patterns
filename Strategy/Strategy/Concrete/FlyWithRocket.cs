using Strategy.Abstract;
using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

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
