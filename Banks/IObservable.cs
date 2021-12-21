namespace Banks
{
    public interface IObservable
    {
        void AddObserverCurrentDate(IObserver observer);
        void NotifyObserverCurrentDate();
    }
}