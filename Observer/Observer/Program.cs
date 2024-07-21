using Observer.Concrete;

namespace Observer
{
    internal class Program
    {
        private static void Main(string[] args)
        {
            var weatherData = new WeatherData();

            var currentConditionDisplay = new CurrentCoditionDisplay(weatherData);
            var currentConditionDisplay2 = new CurrentCoditionDisplay(weatherData);
            //weatherData.RemoveService(currentConditionDisplay);

            weatherData.SetMesurements(30, 40, 55);
        }
    }
}
