namespace Observer.Abstract
{
    internal interface ISubject
    {
        void RegisterService(IObserver o);
        void RemoveService(IObserver o);
        void NotifyObservers();
    }
}
