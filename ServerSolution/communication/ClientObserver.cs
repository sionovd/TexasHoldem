using System;
using System.Collections.Generic;
using System.Linq;
using System.Web;
using Domain.GameCenterModule;
using Domain.GameModule;
using Domain.ObserverFramework;

namespace communication
{
    public class ClientObserver : Observer
    {
        private IGame game;
       // private GameState State;
        private ServerHub Hub;

        public string Username { get; }

        public ClientObserver(string username, int gameID)
        {
         //   Hub = ServerHub.GetInstance;
            Username = username;
            game = GameCenter.GetInstance.GetGameById(gameID);
            game.Subject.Attach(this);
        }

        public override void Update()
        {
          //  Hub.sendMessageToUser(Username, game.Logger.LatestAction);
        }

        public void Unsubscribe()
        {
            game.Subject.Detach(this);
        }
    }
}