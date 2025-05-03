using System;
namespace VirtualProxyExample
{
    public interface IImage
    {
        void Display();
    }

    public class RealImage : IImage
    {
        private readonly string _filename;

        public RealImage(string filename)
        {
            _filename = filename;
            LoadFromDisk();
        }

        private void LoadFromDisk()
        {
            Console.WriteLine($"Loading {_filename} from disk...");
        }

        public void Display()
        {
            Console.WriteLine($"Displaying {_filename}");
        }
    }

    public class ProxyImage : IImage
    {
        private RealImage _realImage;
        private readonly string _filename;

        public ProxyImage(string filename)
        {
            _filename = filename;
        }

        public void Display()
        {
            if (_realImage == null)
            {
                _realImage = new RealImage(_filename);
            }
            _realImage.Display();
        }
    }

    class VirtualProxyExample
    {
        static void Test()
        {
            IImage image = new ProxyImage("design-pattern.png");

            Console.WriteLine("First time:");
            image.Display(); // Loads and displays

            Console.WriteLine("\nSecond time:");
            image.Display(); // Just displays
        }
    }
}
