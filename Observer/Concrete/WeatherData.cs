using Observer.Abstract;

namespace Observer.Concrete
{
    internal class WeatherData : ISubject
    {
        private readonly List<IObserver> observers;
        private float temp;
        private float humidity;
        private float pressure;

        public WeatherData()
        {
            observers = new List<IObserver>();
        }

        public void RegisterService(IObserver o)
        {
            observers.Add(o);
        }

        public void RemoveService(IObserver o)
        {
            observers.Remove(o);
        }

        public void NotifyObservers()
        {
            foreach (var o in observers)
            {
                o.Update(this.temp, this.humidity, this.pressure);
            }
        }

        private void MeasurementChanged()
        {
            NotifyObservers();
        }

        public void SetMesurements(float temp, float humidity, float pressure)
        {
            this.temp = temp;
            this.humidity = humidity;
            this.pressure = pressure;
            MeasurementChanged();
        }
    }
}
