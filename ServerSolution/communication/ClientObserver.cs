using Domain.GameCenterModule;
using Domain.GameModule;
using Domain.ObserverFramework;

namespace communication
{
    public class ClientObserver : Observer
    {
        private IGame game;

        public ClientObserver(string username, int gameID)
        {
            Username = username;
            game = GameCenter.GetInstance.GetGameById(gameID);
            game.Subject.Attach(this);
        }

        public override void Update()
        {
            ServerHub.sendMessageToUser(Username, game.Logger.LatestAction);
        }


        public void Unsubscribe()
        {
            game.Subject.Detach(this);
        }
    }
}