namespace Singleton
{
    internal class BasicSingleton
    {
        private static BasicSingleton instance;

        // Private constructor prevents instantiation from outside the class
        private BasicSingleton() { }

        // Public method to provide a global access point
        public static BasicSingleton GetInstance()
        {
            if (instance == null)
            {
                instance = new BasicSingleton();
            }
            return instance;
        }
    }
}
