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

        public override void UpdateCards()
        {
            ServerHub.sendCardsToUser(Username, game.Logger.LatestAction);
        }

        public override void UpdateGameState()
        {
            ServerHub.sendGameInfoToUser(Username, game.Logger.LatestAction);
        }

        public override void UpdateEndGame()
        {
            throw new System.NotImplementedException();
        }


        public void Unsubscribe()
        {
            game.Subject.Detach(this);
        }
    }
}