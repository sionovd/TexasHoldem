namespace Domain.ObserverFramework
{
    public abstract class Observer
    {
        public string Username { get; set; }
        public abstract void Update();
    }
}
