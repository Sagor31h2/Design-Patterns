using Factory.Abstract;

namespace Factory.Concrete
{
    internal class SimplePizzaFactory : PizzaFactory
    {
        public override Pizza CreatePizza(string type)
        {
            Pizza pizza = new CheesePizza();

            if (type.Equals("cheese"))
            {
                pizza = new CheesePizza();
            }
            else if (type.Equals("veggie"))
            {
                pizza = new VeggiePizza();
            }

            return pizza;
        }
    }
}
