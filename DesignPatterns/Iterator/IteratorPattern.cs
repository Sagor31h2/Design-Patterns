using System;

namespace IteratorPatternExample
{
    // Iterator Interface
    public interface IIterator
    {
        bool HasNext();
        object Next();
    }

    // Menu Item Class
    public class MenuItem
    {
        public string Name { get; }
        public string Description { get; }
        public bool IsVegetarian { get; }
        public double Price { get; }

        public MenuItem(string name, string description, bool isVegetarian, double price)
        {
            Name = name;
            Description = description;
            IsVegetarian = isVegetarian;
            Price = price;
        }

        public override string ToString()
        {
            return $"{Name}, {Price:C} -- {Description}";
        }
    }

    // Concrete Iterator
    public class DinerMenuIterator : IIterator
    {
        private readonly MenuItem[] _items;
        private int _position = 0;

        public DinerMenuIterator(MenuItem[] items)
        {
            _items = items;
        }

        public bool HasNext()
        {
            return _position < _items.Length && _items[_position] != null;
        }

        public object Next()
        {
            var menuItem = _items[_position];
            _position++;
            return menuItem;
        }
    }

    // Concrete Aggregate
    public class DinerMenu
    {
        private const int MaxItems = 6;
        private int _numberOfItems = 0;
        private readonly MenuItem[] _menuItems;

        public DinerMenu()
        {
            _menuItems = new MenuItem[MaxItems];
            AddItem("Vegetarian BLT", "Fake bacon with lettuce & tomato on whole wheat", true, 2.99);
            AddItem("BLT", "Bacon with lettuce & tomato on whole wheat", false, 2.99);
            AddItem("Soup of the day", "Soup with a side of potato salad", false, 3.29);
            AddItem("Hotdog", "A hot dog with sauerkraut, relish, onions, and cheese", false, 3.05);
        }

        public void AddItem(string name, string description, bool isVegetarian, double price)
        {
            if (_numberOfItems >= MaxItems)
            {
                Console.WriteLine("Sorry, the menu is full! Can't add item.");
                return;
            }

            _menuItems[_numberOfItems] = new MenuItem(name, description, isVegetarian, price);
            _numberOfItems++;
        }

        public IIterator CreateIterator()
        {
            return new DinerMenuIterator(_menuItems);
        }
    }

    // Client Code
    public class Waitress
    {
        private readonly DinerMenu _dinerMenu;

        public Waitress(DinerMenu dinerMenu)
        {
            _dinerMenu = dinerMenu;
        }

        public void PrintMenu()
        {
            IIterator dinerIterator = _dinerMenu.CreateIterator();
            Console.WriteLine("MENU\n----");
            PrintMenu(dinerIterator);
        }

        private void PrintMenu(IIterator iterator)
        {
            while (iterator.HasNext())
            {
                MenuItem menuItem = (MenuItem)iterator.Next();
                Console.WriteLine(menuItem);
            }
        }
    }

    // Program Entry Point
    public class Iterator()
    {
        public void Test()
        {

            DinerMenu dinerMenu = new DinerMenu();
            Waitress waitress = new Waitress(dinerMenu);

            waitress.PrintMenu();
        }

    }
}
