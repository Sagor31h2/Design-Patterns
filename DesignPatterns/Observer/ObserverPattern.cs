using System;

namespace DesignPatterns.Observer;

// Subject Interface
public interface ISubject
{
    void RegisterObserver(IObserver observer);
    void RemoveObserver(IObserver observer);
    void NotifyObservers();
}

// Observer Interface
public interface IObserver
{
    void Update(float temperature, float humidity, float pressure);
}

// Display Interface
public interface IDisplayElement
{
    void Display();
}

// Concrete Subject - WeatherData
public class WeatherData : ISubject
{
    private readonly List<IObserver> _observers = new();
    private float _temperature;
    private float _humidity;
    private float _pressure;

    public void RegisterObserver(IObserver observer) => _observers.Add(observer);

    public void RemoveObserver(IObserver observer) => _observers.Remove(observer);

    public void NotifyObservers()
    {
        foreach (var observer in _observers)
        {
            observer.Update(_temperature, _humidity, _pressure);
        }
    }

    public void SetMeasurements(float temperature, float humidity, float pressure)
    {
        _temperature = temperature;
        _humidity = humidity;
        _pressure = pressure;
        NotifyObservers();
    }
}

// Concrete Observer - CurrentConditionsDisplay
public class CurrentConditionsDisplay : IObserver, IDisplayElement
{
    private float _temperature;
    private float _humidity;

    public void Update(float temperature, float humidity, float pressure)
    {
        _temperature = temperature;
        _humidity = humidity;
        Display();
    }

    public void Display() =>
        Console.WriteLine($"Current conditions: {_temperature}°C and {_humidity}% humidity.");
}

// Concrete Observer - StatisticsDisplay
public class StatisticsDisplay : IObserver, IDisplayElement
{
    private readonly List<float> _temperatureReadings = new();

    public void Update(float temperature, float humidity, float pressure)
    {
        _temperatureReadings.Add(temperature);
        Display();
    }

    public void Display()
    {
        float average = _temperatureReadings.Count > 0 ? Sum() / _temperatureReadings.Count : 0;
        Console.WriteLine($"Avg/Max/Min temperature = {average:F1}/{Max()}/{Min()}°C");
    }

    private float Sum() => _temperatureReadings.Sum();
    private float Max() => _temperatureReadings.Max();
    private float Min() => _temperatureReadings.Min();
}

// Concrete Observer - ForecastDisplay
public class ForecastDisplay : IObserver, IDisplayElement
{
    private float _currentPressure = 1013.25f; // default pressure
    private float _lastPressure;

    public void Update(float temperature, float humidity, float pressure)
    {
        _lastPressure = _currentPressure;
        _currentPressure = pressure;
        Display();
    }

    public void Display()
    {
        string forecast;
        if (_currentPressure > _lastPressure)
        {
            forecast = "Improving weather on the way!";
        }
        else if (_currentPressure < _lastPressure)
        {
            forecast = "Watch out for cooler, rainy weather.";
        }
        else
        {
            forecast = "More of the same.";
        }

        Console.WriteLine($"Forecast: {forecast}");
    }
}

// Client
public class ObserverPatternConsole
{
    public void Test()
    {
        WeatherData weatherData = new();

        CurrentConditionsDisplay currentDisplay = new();
        StatisticsDisplay statisticsDisplay = new();
        ForecastDisplay forecastDisplay = new();

        weatherData.RegisterObserver(currentDisplay);
        weatherData.RegisterObserver(statisticsDisplay);
        weatherData.RegisterObserver(forecastDisplay);

        Console.WriteLine("\n--- First Set of Weather Data ---");
        weatherData.SetMeasurements(25.0f, 65.0f, 1015.0f);

        Console.WriteLine("\n--- Second Set of Weather Data ---");
        weatherData.SetMeasurements(22.0f, 70.0f, 1012.0f);

        Console.WriteLine("\n--- Third Set of Weather Data ---");
        weatherData.SetMeasurements(27.0f, 60.0f, 1013.0f);

        Console.WriteLine("\n--- Removing Forecast Display and Updating Data ---");
        weatherData.RemoveObserver(forecastDisplay);
        weatherData.SetMeasurements(26.0f, 68.0f, 1011.0f);
    }
}
