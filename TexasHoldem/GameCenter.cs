using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;



namespace TexasHoldem
{
    class GameCenter
    {
        private Dictionary<int, Game> games;   // int-Game id
        private DataBase db;

        GameCenter()
        {
            List <Game> tmp= db.getAllGames();
            if(tmp!=null)
                games = tmp.ToDictionary(g => g.Id);
            else
                games = new Dictionary<int, Game>();
        }

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
        public Game CreateGame(User user, int gameType, int buyIn, int chipPolicy, int minBet, int maxPlayers, int minPlayers, bool spectateGame)
        {
            if (gameType < 0 || gameType > 2)
                throw new illegalGameTypeException(gameType.ToString());
            if(buyIn<0)                                 //real money and has to be equal or greater than zero
                throw new illegalbuyInException(buyIn.ToString());
            if(chipPolicy < 0)
                throw new illegalChipPolicyException(chipPolicy.ToString());
            if (minBet <= 0)
                throw new illegalMinBetException(minBet.ToString());
            if(minPlayers < 2)
                throw new illegalMinPlayersException(minPlayers.ToString());
            if (minPlayers > maxPlayers)
                throw new illegalGapPlayersException(minPlayers.ToString(), maxPlayers.ToString());
            if(maxPlayers>9)
                throw new illegalMaxPlayersException(maxPlayers.ToString());
            if (buyIn > 0 && user.getMoney < buyIn)
                throw new notEnoughMoneyException(user.getMoney,buyIn);
            GamePreferences pref = new GamePreferences(gameType, buyIn, chipPolicy, minBet, maxPlayers, minPlayers, spectateGame);
            Game game = new Game(pref);
            game.addPlayer(user);
            games.Add(game.Id, game);
            db.AddGame(game);
            return game;
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
