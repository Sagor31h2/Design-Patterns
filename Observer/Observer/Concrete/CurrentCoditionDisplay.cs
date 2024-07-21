using Observer.Abstract;

namespace Observer.Concrete
{
    internal class CurrentCoditionDisplay : IObserver, IDisplayElement
    {
        private readonly WeatherData weatherData;
        private float temp;
        private float humidity;

        public CurrentCoditionDisplay(WeatherData weatherData)
        {
            this.weatherData = weatherData;
            weatherData.RegisterService(this);
        }
        public void Display()
        {
            Console.WriteLine($"Current Conditions: {temp} F degrees and {humidity}% humidity");
        }

        public void Update(float temp, float humidity, float pressure)
        {
            this.temp = temp;
            this.humidity = humidity;
            Display();
        }
    }
}
