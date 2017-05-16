using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using TexasHoldem.GameModule;
using TexasHoldem.UserModule;

namespace TexasHoldem.GameCenterModule
{
    public class GameCenter
    {
        private Dictionary<int, IGame> games;   // int-Game id
        private IDataBase db = new DataBase();
        private UserController userController;
        private System.Object lockThis = new System.Object();

        public GameCenter()
        {
            userController = new UserController();
            List<IGame> tmp = db.getAllGames();
            if (tmp != null)
                games = tmp.ToDictionary(g => g.Id);
            else
                games = new Dictionary<int, IGame>();
        }

        public IGame GetGameById(int id)
        {
            return games[id];
        }

        public List<int> GetActiveGamesByPreferences(int gameType, int buyIn, int chipPolicy, int minBet, int maxPlayers, int minPlayers, int spectateGame)
        {
            var filteredGames = games.Values.AsEnumerable<IGame>();
            if (gameType >= 0)
                filteredGames = filteredGames.Where(g => g.Pref.GameType == gameType);
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
            List<IGame> gamesList = filteredGames.ToList<IGame>();
            return getGameIDs(gamesList);
        }

        public List<int> GetActiveGamesByPot(int pot)
        {
            List<IGame> gamesList = games.Values.ToList<IGame>().Where(p => p.Pot == pot).ToList<IGame>();
            return getGameIDs(gamesList);
        }

        public List<int> GetActiveGamesByPlayerName(string name)
        {
            List<IGame> gamesList = games.Values.ToList().Where(p => p.IsPlayerExist(name) == true).ToList();
            return getGameIDs(gamesList);
        }

        public List<int> GetSpectatableGames()
        {
            List<IGame> gamesList = games.Values.ToList().Where(p => p.Pref.SpectateGame == true).ToList();
            return getGameIDs(gamesList);
        }

        private List<int> getGameIDs(List<IGame> gamesList)
        {
            List<int> gameIDs = new List<int>();
            foreach (IGame g in gamesList)
                gameIDs.Add(g.Id);
            return gameIDs;
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
            //GamePreferences pref = new GamePreferences(gameType, buyIn, chipPolicy, minBet, maxPlayers, minPlayers, spectateGame);
            GamePreferences pref = new GamePreferences();
            Game game = new Game(pref);
            game.AddPlayer(user);
            games.Add(game.Id, game);
            db.AddGame(game);
            return game;

        }

        public int CreateGame(string username, List<KeyValuePair<string, int>> preferenceList)
        {

            //GamePreferences pref = new GamePreferences(gameType, buyIn, chipPolicy, minBet, maxPlayers, minPlayers, spectateGame);
            User user = userController.GetUserByName(username);
            GamePreferences pref = new GamePreferences();
            IGame game = new Game(pref);
            foreach (var pair in preferenceList)
            {
                if (pair.Key == "buyin")
                {
                    game = new BuyInDecorator(game, pair.Value);
                }
                if (pair.Key == "maxPlayers")
                {
                    game = new MaxPlayersDecorator(game, pair.Value);
                }
                // to be finished later....
            }
            game.AddPlayer(user);
            games.Add(game.Id, game);
            db.AddGame(game);
            return game.Id;

        }

        public bool Register(string username, string password, string email)
        {
            User user = userController.Register(username, password, email);
            return user != null;
        }

        public bool RegisterWithMoney(string username, string password, string email, int money)
        {
            User user = userController.RegisterWithMoney(username, password, email, money);
            return user != null;
        }

        public bool EditProfile(string username, string password, string email)
        {
            return userController.EditProfile(username, password, email);
        }

        public bool Login(string username, string password)
        {
            return userController.Login(username, password);
        }

        public bool Logout(string username)
        {
            return userController.Logout(username);
        }

        public int JoinGame(string username, int gameID)
        {
            IGame game = GetGameById(gameID);
            User user = userController.GetUserByName(username);
            Player player = game.AddPlayer(user);
            return player.PlayerId;
        }

        public bool LeaveGame(string username, int gameID)
        {
            IGame game = GetGameById(gameID);
            Player player = game.GetPlayerByUsername(username);
            return game.RemovePlayer(player);
        }

        public bool LeaveGame(int playerID, int gameID)
        {
            IGame game = GetGameById(gameID);
            Player player = game.GetPlayerById(playerID);
            return game.RemovePlayer(player);
        }

        public int SpectateGame(string username, int gameID)
        {
            IGame game = GetGameById(gameID);
            User user = userController.GetUserByName(username);
            Spectator spectator = game.AddSpectatingPlayer(user);
            return spectator.Id;
        }

        public bool Bet(int playerID, int gameID, int amount)
        {
            IGame game = GetGameById(gameID);
            Player player = game.GetPlayerById(playerID);
            return game.Bet(player, amount);
        }

        public bool Check(int playerID, int gameID)
        {
            IGame game = GetGameById(gameID);
            Player player = game.GetPlayerById(playerID);
            return game.Check(player);
        }

        public bool Fold(int playerID, int gameID)
        {
            IGame game = GetGameById(gameID);
            Player player = game.GetPlayerById(playerID);
            return game.Fold(player);
        }

        public bool Call(int playerID, int gameID)
        {
            IGame game = GetGameById(gameID);
            Player player = game.GetPlayerById(playerID);
            return game.Call(player);
        }


    }
}