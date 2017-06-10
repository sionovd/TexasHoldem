using System.Collections.Generic;

namespace Domain.ObserverFramework
{
    public class Subject
    {
        private List<Observer> observers;

        public Subject()
        {
            observers = new List<Observer>();
        }

        public void Attach(Observer observer)
        {
            observers.Add(observer);
        }

        public void Detach(Observer observer)
        {
            foreach (var o in observers)
            {
                if (o.Username == observer.Username)
                    observers.Remove(o);
            }
        }

        public void NotifyAll()
        {
            foreach (var o in observers)
            {
                o.Update();
            }     
        }

        public void Notify(string username)
        {
            foreach (var o in observers)
            {
                if(o.Username == username)
                    o.Update();
            }
        }
    }
}
