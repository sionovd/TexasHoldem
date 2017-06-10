namespace Domain.ObserverFramework
{
    public abstract class Observer
    {
        public string Username { get; set; }
        public abstract void UpdateCards();
        public abstract void UpdateGameState();
        public abstract void UpdateEndGame();
    }
}
