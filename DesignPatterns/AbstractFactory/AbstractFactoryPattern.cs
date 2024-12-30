namespace AbstractFactory
{
    // Abstract Factory Interface
    public interface IPizzaIngredientFactory
    {
        string CreateDough();
        string CreateSauce();
        string CreateCheese();
    }

    // Concrete Factory for New York Ingredients
    public class NYPizzaIngredientFactory : IPizzaIngredientFactory
    {
        public string CreateDough() => "Thin Crust Dough";
        public string CreateSauce() => "Marinara Sauce";
        public string CreateCheese() => "Reggiano Cheese";
    }

    // Concrete Factory for Chicago Ingredients
    public class ChicagoPizzaIngredientFactory : IPizzaIngredientFactory
    {
        public string CreateDough() => "Thick Crust Dough";
        public string CreateSauce() => "Plum Tomato Sauce";
        public string CreateCheese() => "Mozzarella Cheese";
    }

    // Abstract Pizza Class
    public abstract class Pizza
    {
        protected string Name;
        protected string Dough;
        protected string Sauce;
        protected string Cheese;

        public abstract void Prepare();

        public void Bake() => Console.WriteLine("Baking for 25 minutes at 350...");
        public void Cut() => Console.WriteLine("Cutting the pizza into diagonal slices...");
        public void Box() => Console.WriteLine("Placing pizza in official box...");

        public void SetName(string name) => Name = name;
        public string GetName() => Name;
    }

    // Concrete Pizza Class for Cheese Pizza
    public class CheesePizza : Pizza
    {
        private readonly IPizzaIngredientFactory _ingredientFactory;

        public CheesePizza(IPizzaIngredientFactory ingredientFactory)
        {
            _ingredientFactory = ingredientFactory;
        }

        public override void Prepare()
        {
            Console.WriteLine($"Preparing {Name}");
            Dough = _ingredientFactory.CreateDough();
            Sauce = _ingredientFactory.CreateSauce();
            Cheese = _ingredientFactory.CreateCheese();
            Console.WriteLine($"Dough: {Dough}, Sauce: {Sauce}, Cheese: {Cheese}");
        }
    }

    // Abstract Pizza Store
    public abstract class PizzaStore
    {
        public Pizza OrderPizza(string type)
        {
            Pizza pizza = CreatePizza(type);
            pizza.Prepare();
            pizza.Bake();
            pizza.Cut();
            pizza.Box();
            return pizza;
        }

        protected abstract Pizza CreatePizza(string type);
    }

    // Concrete Pizza Store for New York
    public class NYPizzaStore : PizzaStore
    {
        protected override Pizza CreatePizza(string type)
        {
            Pizza pizza = null;
            IPizzaIngredientFactory ingredientFactory = new NYPizzaIngredientFactory();

            if (type == "cheese")
            {
                pizza = new CheesePizza(ingredientFactory);
                pizza.SetName("New York Style Cheese Pizza");
            }
            return pizza;
        }
    }

    // Concrete Pizza Store for Chicago
    public class ChicagoPizzaStore : PizzaStore
    {
        protected override Pizza CreatePizza(string type)
        {
            Pizza pizza = null;
            IPizzaIngredientFactory ingredientFactory = new ChicagoPizzaIngredientFactory();

            if (type == "cheese")
            {
                pizza = new CheesePizza(ingredientFactory);
                pizza.SetName("Chicago Style Cheese Pizza");
            }
            return pizza;
        }
    }

    // Main Program


    public class AbstractFactoryTest
    {
        public void Test()
        {
            PizzaStore nyStore = new NYPizzaStore();
            PizzaStore chicagoStore = new ChicagoPizzaStore();

            Pizza pizza = nyStore.OrderPizza("cheese");
            Console.WriteLine($"Ordered a {pizza.GetName()}\n");

            pizza = chicagoStore.OrderPizza("cheese");
            Console.WriteLine($"Ordered a {pizza.GetName()}\n");
        }
    }
}

