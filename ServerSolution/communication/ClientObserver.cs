using Domain.GameCenterModule;
using Domain.GameModule;
using Domain.ObserverFramework;

namespace communication
{
    public class ClientObserver : Observer
    {
        private IGame game;
        private bool isSpectator;

        public ClientObserver(string username, int gameID)
        {
            Username = username;
            game = GameCenter.GetInstance.GetGameById(gameID);
            isSpectator = game.IsSpectatorExist(username);
            game.Subject.Attach(this);
        }

        public override void UpdateMessage(string sender, string message)
        {
            ServerHub.sendMessageToUser(sender, Username, message, game.Id);
        }

        public override void UpdateWhisper(string sender, string whisper)
        {
            ServerHub.sendWhisperToUser(sender, Username, whisper, game.Id);
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
            ServerHub.sendEndGameToUser(Username, game.Logger.LatestAction);
        }

        public override void UpdateSpectatorMessage(string sender, string message)
        {
            if(isSpectator)
                ServerHub.sendMessageToUser(sender, Username, message, game.Id);
        }

        public override void UpdateSpectatorWhisper(string sender, string whisper)
        {
            if(isSpectator)
                ServerHub.sendWhisperToUser(sender, Username, whisper, game.Id);
        }

        public void Unsubscribe()
        {
            game.Subject.Detach(this);
        }
    }
}