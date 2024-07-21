using Observer.Concrete;

namespace Observer
{
    public class ObserverTestingConsole
    {
        public ObserverTestingConsole()
        {

        }

        public void Test()
        {
            Console.WriteLine("From Observer");


            var weatherData = new WeatherData();

            var currentConditionDisplay = new CurrentCoditionDisplay(weatherData);
            var currentConditionDisplay2 = new CurrentCoditionDisplay(weatherData);
            //weatherData.RemoveService(currentConditionDisplay);

            weatherData.SetMesurements(30, 40, 55);
        }
    }
}
