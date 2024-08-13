namespace Factory.Abstract
{
    internal abstract class PizzaFactory
    {
        public abstract Pizza CreatePizza(string type);
    }
}
