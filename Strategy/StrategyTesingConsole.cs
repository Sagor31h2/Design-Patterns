﻿using Strategy.Concrete;

namespace Strategy
{
    public class StrategyTesingConsole
    {
        public void Test()
        {
            Console.WriteLine("Strategy Pattern Test...\n \n");

            var mallardDuck = new MallardDuck();
            mallardDuck.Display();
            mallardDuck.PerfromQuack();
            mallardDuck.PerfromFly();

            Console.WriteLine("\n\n");
            //model duck
            var modelDuck = new ModelDuck();
            modelDuck.Display();
            modelDuck.PerfromQuack();
            modelDuck.PerfromFly();

            Console.WriteLine("\nSetting Rocket to model duck");
            //setting Rocket
            modelDuck.SetFlyBehavior(new FlyWithRocket());
            modelDuck.PerfromFly();
        }

    }
}
