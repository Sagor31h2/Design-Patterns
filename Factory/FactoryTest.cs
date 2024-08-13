using Factory.Abstract;
using Factory.Concrete;

namespace Factory
{
    public class FactoryTest
    {
        public void Test()
        {
            PizzaFactory factory = new SimplePizzaFactory();

            Pizza cheesePizza = factory.CreatePizza("cheese");
            cheesePizza.Prepare();
            cheesePizza.Bake();
            cheesePizza.Cut();
            cheesePizza.Box();


            Console.WriteLine("Another \n");

            Pizza veggiePizza = factory.CreatePizza("veggie");
            veggiePizza.Prepare();
            veggiePizza.Bake();
            veggiePizza.Cut();
            veggiePizza.Box();
        }
    }
}
