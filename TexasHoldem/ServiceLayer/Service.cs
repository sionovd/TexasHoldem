using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexasHoldem.ServiceLayer
{
    public class Service : IService
    {
        private UserController userController;
        private GameCenter gameCenter;

        public Service()
        {
            userController = new UserController();
            gameCenter = new GameCenter();
        }

        public bool Register(string username, string password, string email)
        {
            
            User user = userController.Register(username, password, email);
            return user != null;
        }

        public bool RegisterWithMoney(string username, string password, string email, int money)
        {
            throw new NotImplementedException();
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

        public int ViewMoneyBalanceOfUser(string username)
        {
            throw new NotImplementedException();
        }

        public int JoinGame(string username, int gameID)
        {
            Game game = gameCenter.GetGameById(gameID);
            User user = userController.GetUserByName(username);
            Player player = game.AddPlayer(user);
            return player.PlayerId;
        }

        public bool LeaveGame(string username, int gameID)
        {
            throw new NotImplementedException();
        }

        public bool Bet(int playerID, int gameID, int amount)
        {
            Game game = gameCenter.GetGameById(gameID);
            Player player = game.GetPlayerById(playerID);
            return game.Bet(player, amount);
        }

        public bool Check(int playerID, int gameID)
        {
            Game game = gameCenter.GetGameById(gameID);
            Player player = game.GetPlayerById(playerID);
            return game.Check(player);
        }

        public bool Fold(int playerID, int gameID)
        {
            Game game = gameCenter.GetGameById(gameID);
            Player player = game.GetPlayerById(playerID);
            return game.Fold(player);
        }

        public bool Call(int playerID, int gameID)
        {
            Game game = gameCenter.GetGameById(gameID);
            Player player = game.GetPlayerById(playerID);
            return game.Call(player);
        }

        public int CreateGame(string username, int gameTypePolicy, int buyInPolicy, int chipPolicy, int minBet, int minPlayerCount,
            int maxPlayerCount, bool isSpectatable)
        {
            
            User user = new User(username);
            Game game = gameCenter.CreateGame(user, gameTypePolicy, buyInPolicy, chipPolicy, minBet, maxPlayerCount, minPlayerCount,
                isSpectatable);
            return game.Id;
        }

        public List<int> SearchActiveGamesByPreferences(int gameType, int buyIn, int chipPolicy, int minBet, int maxPlayers, int minPlayers,
            int spectateGame)
        {
            List<Game> games = gameCenter.GetActiveGamesByPreferences(gameType, buyIn, chipPolicy, minBet, maxPlayers, minPlayers,
                spectateGame);
            List<int> gameIDs = new List<int>();
            foreach(Game g in games)
                gameIDs.Add(g.Id);

            return gameIDs;
        }

        public List<int> SearchActiveGamesByPot(int pot)
        {
            List<Game> games = gameCenter.GetActiveGamesByPot(pot);
            List<int> gameIDs = new List<int>();
            foreach (Game g in games)
                gameIDs.Add(g.Id);

            return gameIDs;
        }

        public List<int> SearchActiveGamesByPlayerName(string name)
        {
            List<Game> games = gameCenter.GetActiveGamesByPlayerName(name);
            List<int> gameIDs = new List<int>();
            foreach (Game g in games)
                gameIDs.Add(g.Id);

            return gameIDs;
        }

        public List<int> ViewSpectatableGames()
        {
            List<Game> games = gameCenter.GetSpectatableGame();
            List<int> gameIDs = new List<int>();
            foreach (Game g in games)
                gameIDs.Add(g.Id);

            return gameIDs;
        }

        public bool SetDefaultLeague(int leagueID)
        {
            throw new NotImplementedException();
        }

        public bool SetLeagueCriteria(int leagueID, int points)
        {
            throw new NotImplementedException();
        }

        public bool MoveUserToLeague(string username, int leagueID)
        {
            throw new NotImplementedException();
        }

        public bool ReplayGame(string username, int gameLogID)
        {
            throw new NotImplementedException();
        }

        public bool SaveTurns(string username, int gameID, string turnData)
        {
            throw new NotImplementedException();
        }

        public int SpectateGame(string username, int gameID)
        {
            Game game = gameCenter.GetGameById(gameID);
            User user = userController.GetUserByName(username);
            Player player = game.AddSpectatingPlayer(user);
            return player.PlayerId;
        }
    }
}
