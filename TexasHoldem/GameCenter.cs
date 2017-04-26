using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TexasHoldem
{
    class GameCenter
    {
    public List<Game> GetActiveGames(User user,string filter)
        {
        //TODO
            return null;
        }
    public List<Game> GetSpectatableGame()
    {
        //TODO
        return null;
    }
        public bool ShowGame(User user, Game game)
    {
        //TODO
        return true;
    }
        public Game CreateGame(int gameTypePolicy,int buylnPolicy,int chipPolicy,int minBet,int minPlayerCount, int maxPlayerCount, bool isSectatable)
        {
            //TODO
            return null;
        }
        public bool SetDefaultLeague(League league)
        {
            //TODO
            return true; ;
        }
        public bool AddLeague(League league, int criteria)
        {
            //TODO
            return true; ;
        }
        public bool MoveUserToLeague(User user,League league)
        {
              //TODO
        return true; ;
        }
    }
}
