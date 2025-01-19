using System;
using System.Collections.Generic;

namespace CompositePatternExample
{
    // Component
    public abstract class MenuComponent
    {
        public virtual void Add(MenuComponent menuComponent)
        {
            throw new NotImplementedException();
        }

        public virtual void Remove(MenuComponent menuComponent)
        {
            throw new NotImplementedException();
        }

        public virtual MenuComponent GetChild(int index)
        {
            throw new NotImplementedException();
        }

        public virtual string GetName()
        {
            throw new NotImplementedException();
        }

        public virtual string GetDescription()
        {
            throw new NotImplementedException();
        }

        public virtual double GetPrice()
        {
            throw new NotImplementedException();
        }

        public virtual bool IsVegetarian()
        {
            throw new NotImplementedException();
        }

        public virtual void Print()
        {
            throw new NotImplementedException();
        }
    }

    // Leaf
    public class MenuItem : MenuComponent
    {
        private readonly string _name;
        private readonly string _description;
        private readonly bool _isVegetarian;
        private readonly double _price;

        public MenuItem(string name, string description, bool isVegetarian, double price)
        {
            _name = name;
            _description = description;
            _isVegetarian = isVegetarian;
            _price = price;
        }

        public override string GetName() => _name;
        public override string GetDescription() => _description;
        public override double GetPrice() => _price;
        public override bool IsVegetarian() => _isVegetarian;

        public override void Print()
        {
            Console.Write($"  {_name}");
            if (IsVegetarian()) Console.Write(" (v)");
            Console.WriteLine($", {_price:C} -- {_description}");
        }
    }

    // Composite
    public class Menu : MenuComponent
    {
        private readonly List<MenuComponent> _menuComponents = new();
        private readonly string _name;
        private readonly string _description;

        public Menu(string name, string description)
        {
            _name = name;
            _description = description;
        }

        public override void Add(MenuComponent menuComponent)
        {
            _menuComponents.Add(menuComponent);
        }

        public override void Remove(MenuComponent menuComponent)
        {
            _menuComponents.Remove(menuComponent);
        }

        public override MenuComponent GetChild(int index)
        {
            return _menuComponents[index];
        }

        public override void Print()
        {
            Console.WriteLine($"\n{_name}, {_description}\n---------------------");
            foreach (var menuComponent in _menuComponents)
            {
                menuComponent.Print();
            }
        }
    }

    // Client
    public class Waitress
    {
        private readonly MenuComponent _allMenus;

        public Waitress(MenuComponent allMenus)
        {
            _allMenus = allMenus;
        }

        public void PrintMenu()
        {
            _allMenus.Print();
        }
    }

    // Program Entry Point
    class CompositePattern
    {
        public void Test()
        {
            // Create menu items
            MenuComponent pancakeHouseMenu = new Menu("Pancake House Menu", "Breakfast");
            MenuComponent dinerMenu = new Menu("Diner Menu", "Lunch");
            MenuComponent dessertMenu = new Menu("Dessert Menu", "Dessert of course!");

            MenuComponent allMenus = new Menu("ALL MENUS", "All menus combined");

            // Build menu structure
            allMenus.Add(pancakeHouseMenu);
            allMenus.Add(dinerMenu);

            pancakeHouseMenu.Add(new MenuItem("Pancakes", "Delicious pancakes with syrup", true, 2.99));
            pancakeHouseMenu.Add(new MenuItem("Waffles", "Waffles with your choice of toppings", true, 3.59));

            dinerMenu.Add(new MenuItem("Vegetarian BLT", "Fake bacon with lettuce & tomato", true, 2.99));
            dinerMenu.Add(new MenuItem("BLT", "Bacon with lettuce & tomato", false, 2.99));
            dinerMenu.Add(dessertMenu);

            dessertMenu.Add(new MenuItem("Apple Pie", "Apple pie with a flaky crust", true, 1.59));

            // Print menu
            Waitress waitress = new Waitress(allMenus);
            waitress.PrintMenu();
        }
    }
}
