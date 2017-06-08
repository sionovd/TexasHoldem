using System.Collections.Generic;

namespace Domain.UserModule
{
    public class UserController
    {
        private static UserController userController;
        private DataBase db = new DataBase();
        private static bool init = true;
        private Dictionary<string, User> registerUsers;
        private Dictionary<string, User> loginUsers;
        private System.Object lockThis = new System.Object();

        private UserController()
        {
            loginUsers = new Dictionary<string, User>();
            registerUsers = new Dictionary<string, User>();
        }

        public User GetUserByUsername(string username)
        {
            return registerUsers[username];
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

        public void Initialized()
        {
            init = false;            
        }
        public User GetUserByName(string name)
        {
            return registerUsers[name];
        }
        public User Register(string username, string password, string email)
        {
            lock (lockThis)
            {
                if (init)
                    Initialized();
                
                User user = new User(username, password, email);
                if (registerUsers.ContainsKey(username))
                    throw new AlreadyHasNameException(user.Username);
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
                registerUsers[username] =  new User(username, password, email);
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

        

    }
}