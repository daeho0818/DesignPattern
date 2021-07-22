using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace Observer_1
{
    class Subject
    {
        private List<IObserver> observers = new List<IObserver>();

        public void AddObserver(IObserver observer)
        {
            observers.Add(observer);
        }

        public void NotifyObservers()
        {
            foreach (IObserver observer in observers)
            {
                observer.Update();
            }
        }
    }
    interface IObserver
    {
        void Update();
    }

    class ObserverA : IObserver
    {
        public void Update()
        {
            // update ObserverA Object
        }
    }

    class ObserverB : IObserver
    {
        public void Update()
        {
            // update ObserverB Object
        }
    }
}
