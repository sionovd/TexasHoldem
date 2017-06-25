using System;
using System.Collections.Generic;
using Domain.DomainLayerExceptions;
using System.Linq;
using System.Web.Script.Serialization;

namespace Domain.UserModule
{
    public class UserController
    {
        private static UserController userController;
        private Dictionary<string, User> registerUsers;
        private Dictionary<string, User> loginUsers;
        private Dictionary<string, User> loginWebUsers;
        private DbManager dbManager;
        private Object lockThis = new Object();

        private UserController()
        {
            loginUsers = new Dictionary<string, User>();
            loginWebUsers = new Dictionary<string, User>();
            dbManager = DbManager.GetInstance;
            registerUsers = dbManager.GetRegisteredUsers();
        }

        public static UserController GetInstance
        {
            get
            {
                if (userController == null)
                    userController = new UserController();
                return userController;
            }
        }

        public User GetUserByName(string name)
        {
            return registerUsers[name];
        }

        public List<string> GetAllUsernames()
        {
            List<string> usernames = new List<string>(registerUsers.Keys);
            return usernames;
        }

        public List<string> Get20TopByCategory(string comperator)
        {
            List<User> users = new List<User>(registerUsers.Values);
            List<User> sortedUsers;
            if (comperator.Equals("Amout of games"))
                sortedUsers = (users.OrderBy(o => o.Stats.NumOfGames).ToList());
            else if (comperator.Equals("Higest cash in game"))
                sortedUsers = (users.OrderBy(o => o.Stats.HighestCashGain).ToList());
            else if (comperator.Equals("Total gross profit"))
                sortedUsers = (users.OrderBy(o => o.Stats.TotalGrossProfit).ToList());
            else
                sortedUsers = new List<User>();
            if (sortedUsers.Count() > 20)
                sortedUsers =(List<User>)sortedUsers.Take(20);
            List<string> playerLeaderList = new List<string>();
            JavaScriptSerializer serializer = new JavaScriptSerializer();
            foreach (User u in sortedUsers)
            {
                playerLeaderList.Add(serializer.Serialize(new PlayerLeader(u.Username, u.Stats.NumOfGames)));
            }
            return playerLeaderList;
        }
        
        public Statistics GetUserStats(string username)
        {
            User user = GetUserByName(username);
            return user.Stats;
        }
        public User Register(string username, string password, string email)
        {
            lock (lockThis)
            {
                if(username.Length == 0)
                    throw new DomainException("invalid details - username was empty");
                if(username.Length > 16)
                    throw new DomainException("invalid details - username was too long");
                if (username.Contains(";") || username.Contains(" ") || username.Contains(":") ||
                    username.Contains("_") || username.Contains(","))
                    throw new DomainException("invalid details - illegal characters in username");
                User user = new User(username, password, email);
                if (registerUsers.ContainsKey(username))
                    throw new AlreadyHasNameException(user.Username);
                dbManager.AddUser(user);
                registerUsers.Add(username, user);
                return user;
            }
        }

        public bool EditProfile(string username, string password, string email)
        {
            lock (lockThis)
            {
                if (!registerUsers.ContainsKey(username))
                    throw new NoUserNameException(username);
                User originalUser = registerUsers[username];
                User newUser = new User(username, password, email, originalUser.MoneyBalance);
                newUser.Stats = originalUser.Stats;
                registerUsers[username] = newUser;
                dbManager.EditUser(newUser);
                return true;
            }
        }

        public bool Login(string username, string password)
        {
            lock (lockThis)
            {
                if (!registerUsers.ContainsKey(username))
                    throw new NoUserNameException(username);
                if (!registerUsers[username].CheckPassword(password))
                    throw new NotAPasswordException(password);
                if(loginUsers.ContainsKey(username))
                    throw new AlreadyParticipatingException("you are already logged in");
                loginUsers[username] = registerUsers[username];
                return true;
            }
        }

        public bool Logout(string username)
        {
            lock (lockThis)
            {
                if (!registerUsers.ContainsKey(username) || !loginUsers.ContainsKey(username))
                    throw new NoUserNameException(username);
                loginUsers.Remove(username);
                return true;
            }
        }

        public bool LoginWebClient(string username, string password)
        {
            lock (lockThis)
            {
                if (!registerUsers.ContainsKey(username))
                    throw new NoUserNameException(username);
                if (!registerUsers[username].CheckPassword(password))
                    throw new NotAPasswordException(password);
                loginWebUsers[username] = registerUsers[username];
                return true;
            }
        }

        public bool LogoutWebClient(string username)
        {
            lock (lockThis)
            {
                if (!registerUsers.ContainsKey(username) || !loginWebUsers.ContainsKey(username))
                    throw new NoUserNameException(username);
                loginWebUsers.Remove(username);
                return true;
            }
        }

        public void DeleteUser(string username)
        {
            if (loginUsers.ContainsKey(username))
                loginUsers.Remove(username);
            if (loginWebUsers.ContainsKey(username))
                loginWebUsers.Remove(username);
            User user = registerUsers[username]; 
            registerUsers.Remove(username);
            dbManager.DeleteUser(user);
        }
    }
}