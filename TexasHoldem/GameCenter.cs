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
        private IDataBase db = new DataBase();
        private System.Object lockThis = new System.Object();

        GameCenter()
        {
            List <Game> tmp= db.getAllGames();
            if(tmp!=null)
                games = tmp.ToDictionary(g => g.Id);
            else
                games = new Dictionary<int, Game>();
        }

        public Game GetGameById(int id)
        {
            return games[id];
        }

        public List<Game> GetActiveGamesByPreferences(int gameType, int buyIn, int chipPolicy, int minBet, int maxPlayers, int minPlayers, int spectateGame)
        {
            var filteredGames = games.Values.AsEnumerable<Game>();
            if (gameType >= 0)
                filteredGames = filteredGames.Where(g=>g.Pref.GameType==gameType);
            if (buyIn >= 0)
                filteredGames = filteredGames.Where(g => g.Pref.BuyIn == buyIn);
            if (chipPolicy >= 0)
                filteredGames = filteredGames.Where(g => g.Pref.ChipPolicy == chipPolicy);
            if (minBet >= 0)
                filteredGames = filteredGames.Where(g => g.Pref.MinBet == minBet);
            if (maxPlayers >= 2)
                filteredGames = filteredGames.Where(g => g.Pref.MaxPlayers == maxPlayers);
            if (minPlayers >= 2)
                filteredGames = filteredGames.Where(g => g.Pref.MinPlayers == minPlayers);
            if (spectateGame == 0)
                filteredGames = filteredGames.Where(g => g.Pref.SpectateGame == false);
            if (spectateGame == 1)
                filteredGames = filteredGames.Where(g => g.Pref.SpectateGame == true);
            return filteredGames.ToList<Game>();
        }

        public List<Game> GetActiveGamesByPot(int pot)
        {
            return this.games.Values.ToList<Game>().Where(p => p.Pot == pot).ToList<Game>();
        }

        public List<Game> GetActiveGamesByPlayerName(string name)
        {
            return games.Values.ToList().Where(p => p.IsPlayerExist(name)==true).ToList();
        }

        public List<Game> GetSpectatableGame()
        {
            return games.Values.ToList().Where(p => p.Pref.SpectateGame == true).ToList();
        }
            public bool ShowGame(User user, Game game)
        {
            //TODO
            return true;
        }

        public Game CreateGame(User user, int gameType, int buyIn, int chipPolicy, int minBet, int maxPlayers, int minPlayers, bool spectateGame) 
        {
            lock (lockThis)
            {
                if (gameType < 0 || gameType > 2)
                    throw new illegalGameTypeException(gameType.ToString());
                if (buyIn < 0)                                 //real money and has to be equal or greater than zero
                    throw new illegalbuyInException(buyIn.ToString());
                if (chipPolicy < 0)
                    throw new illegalChipPolicyException(chipPolicy.ToString());
                if (minBet <= 0)
                    throw new illegalMinBetException(minBet.ToString());
                if (minPlayers < 2)
                    throw new illegalMinPlayersException(minPlayers.ToString());
                if (minPlayers > maxPlayers)
                    throw new illegalGapPlayersException(minPlayers.ToString(), maxPlayers.ToString());
                if (maxPlayers > 9)
                    throw new illegalMaxPlayersException(maxPlayers.ToString());
                if (user.getmoneyBalance() < buyIn)
                    throw new notEnoughMoneyException(user.getmoneyBalance().ToString(), buyIn.ToString());
                GamePreferences pref = new GamePreferences(gameType, buyIn, chipPolicy, minBet, maxPlayers, minPlayers, spectateGame);
                Game game = new Game(pref);
                game.AddPlayer(user);
                games.Add(game.Id, game);
                db.AddGame(game);
                return game;
            }
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