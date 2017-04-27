using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexasHoldem
{
    class Game
    {
        public Game(int gameID)
        {
            //this = gameCenter.getGame(gameID);
        }

        public User AddPlayer(User user)
        {
            //TODO
            return null;
        }
        public void RemovePlayer(Player player)
        {
            //TODO 
        }
        public bool Bet(Player player,int amount)
        {
            //TODO
            return true;
        }
        public bool Call(Player player)
        {
            //TODO
            return true;
        }
        public bool Check(Player player)
        {
            //TODO
            return true;
        }
        public bool Fold(Player player)
        {
            //TODO
            return true;
        }
    }
}
