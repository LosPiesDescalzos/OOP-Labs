using System;

namespace Banks
{
    public interface IObserver
    {
        void Update(DateTime currentDate);
    }
}