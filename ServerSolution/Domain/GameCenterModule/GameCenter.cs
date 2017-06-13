﻿using System.Collections.Generic;
using System.Linq;
using System.Runtime.InteropServices;
using Domain.DomainLayerExceptions;
using Domain.GameModule;
using Domain.UserModule;

namespace Domain.GameCenterModule
{
    public class GameCenter
    {
        private static GameCenter gameCenter;
        private Dictionary<int, IGame> games;   // int-Game id
        private UserController userController;
        
        private GameCenter()
        {
            userController = UserController.GetInstance;
            games = new Dictionary<int, IGame>();
        }

        public static GameCenter GetInstance
        {
            get
            {
                if(gameCenter == null)
                    gameCenter = new GameCenter();
                return gameCenter;
            }
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
            List<IGame> gamesList = games.Values.ToList<IGame>().Where(p => p.State.Pot == pot).ToList<IGame>();
            return getGameIDs(gamesList);
        }

        public List<int> GetActiveGamesByPlayerName(string name)
        {
            List<IGame> gamesList = games.Values.ToList().Where(g => g.IsPlayerExist(name) == true).ToList();
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

        public int CreateGame(string username, List<KeyValuePair<string, int>> preferenceList)
        {
            User user = userController.GetUserByName(username);
            GamePreferences pref = new GamePreferences();
            IGame game = new Game(pref);
            
            foreach (var pair in preferenceList)
            {
                if (pair.Key == "buyIn")
                {
                    if (pair.Value < 0)  //real money and has to be equal or greater than zero
                        throw new illegalbuyInException(pair.Value.ToString());
                    game = new BuyInDecorator(game, pair.Value);
                }
                if (pair.Key == "minBet")
                {
                    if (pair.Value <= 0)
                        throw new illegalMinBetException(pair.Value.ToString());
                    game = new MinBetDecorator(game, pair.Value);
                }
                if (pair.Key == "minPlayers")
                {
                    if (pair.Value > game.Pref.MaxPlayers)
                        throw new illegalGapPlayersException(pair.Value.ToString(), game.Pref.MaxPlayers.ToString());
                    if(pair.Value < 2)
                        throw new illegalMinPlayersException(pair.Value.ToString());
                    game = new MinPlayersDecorator(game, pair.Value);
                }
                if (pair.Key == "maxPlayers")
                {
                    if (pair.Value > 9)
                        throw new illegalMaxPlayersException(pair.Value.ToString());
                    if(pair.Value < game.Pref.MinPlayers)
                        throw new illegalGapPlayersException(game.Pref.MinPlayers.ToString(), pair.Value.ToString());
                    game = new MaxPlayersDecorator(game, pair.Value);
                }
                if (pair.Key == "chipPolicy")
                {
                    if (pair.Value < 0)
                        throw new illegalChipPolicyException(pair.Value.ToString());
                    game = new ChipPolicyDecorator(game, pair.Value);
                }
                if (pair.Key == "spectateGame")
                {
                    bool spectateGame = pair.Value == 1;
                    game = new SpectateGameDecorator(game, spectateGame);
                }
                if (pair.Key == "gameType" && pair.Value == 0)
                {
                    game = new LimitHoldemDecorator(game);
                }
                if (pair.Key == "gameType" && pair.Value == 2)
                {
                    game = new PotLimitHoldemDecorator(game);
                }
                if (pair.Key == "gameType" && (pair.Value < 0 || pair.Value > 2))
                {
                    throw new illegalGameTypeException(pair.Value.ToString());
                }

                // can be extended....
            }
            if (user.MoneyBalance < game.Pref.BuyIn)
                throw new notEnoughMoneyException(user.MoneyBalance.ToString(), game.Pref.BuyIn.ToString());
            game.AddPlayer(user);
            game.League = user.League;
            games.Add(game.Id, game);
            return game.Id;

        }

        public bool Register(string username, string password, string email)
        {
            if (password == null)
                throw new NotAPasswordException("hello");
            User user = userController.Register(username, password, email);
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
            if (game.IsSpectatorExist(username))
                throw new AlreadyParticipatingException("The user " + username + " is already spectating game #" + gameID);
            User user = userController.GetUserByName(username);
            Player player = game.AddPlayer(user);
            return player.PlayerId;
        }

        public bool StartGame(string username, int gameID)
        {
            IGame game = GetGameById(gameID);
            Player player = game.GetPlayerByUsername(username);
            player.ReadyToStart = true;
            foreach (var p in game.Seats)
            {
                if (!p.ReadyToStart)
                    return true;
            }
            if (game.Seats.Count >= game.Pref.MinPlayers)
            {
                game.Start();
                
                return true;
            }
            return true;
        }

        public bool EvaluateEndGame(int gameID)
        {
            IGame game = GetGameById(gameID);
            Player winner = game.Winner;
            foreach (var player in game.Seats)
            {
                User user = userController.GetUserByName(player.Username);
                user.Stats.NumOfGames++;
                if (user.Username == winner.Username)
                {
                    user.IncreaseMoney(winner.ChipBalance);
                    user.Stats.Points += 5;
                }
                else
                    user.Stats.Points -= 1;
            }
            games.Remove(gameID);
            return true;
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
            if (game.IsPlayerExist(username))
                throw new AlreadyParticipatingException("The user " + username + " is already playing in game #" + gameID);
            User user = userController.GetUserByName(username);
            Spectator spectator = game.AddSpectatingPlayer(user);
            return spectator.Id;
        }

        public bool Bet(int playerID, int gameID, int amount)
        {
            IGame game = GetGameById(gameID);
            Player player = game.GetPlayerById(playerID);
            game.Bet(player, amount);
            if (game.State.RoundNumber > 4)
                EvaluateEndGame(gameID);
            return true;
        }

        public bool Check(int playerID, int gameID)
        {
            IGame game = GetGameById(gameID);
            Player player = game.GetPlayerById(playerID);
            game.Check(player);
            if (game.State.RoundNumber > 4)
                EvaluateEndGame(gameID);
            return true;
        }

        public bool Fold(int playerID, int gameID)
        {
            IGame game = GetGameById(gameID);
            Player player = game.GetPlayerById(playerID);
            game.Fold(player);
            if (game.State.RoundNumber > 4)
                EvaluateEndGame(gameID);
            return true;
        }

        public bool Call(int playerID, int gameID)
        {
            IGame game = GetGameById(gameID);
            Player player = game.GetPlayerById(playerID);
            game.Call(player);
            if (game.State.RoundNumber > 4)
                EvaluateEndGame(gameID);
            return true;
        }


        public string GetEmail(string username)
        {
            return userController.GetUserByName(username).Email;
        }

        public void DeleteAccount(string username)
        {
            userController.DeleteUser(username);
        }
    }
}