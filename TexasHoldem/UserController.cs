using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexasHoldem
{
    class UserController
    {
        private DataBase db;
        private static bool init = true;
        private Dictionary<string, User> registerUsers;
        private Dictionary<string, User> loginUsers;
        private System.Object lockThis = new System.Object();
        public void Initialized()
        {
            init = false;
            List<User> tmp = db.getRegisterUsers();
            loginUsers = new Dictionary<string, User>();
        }
 
        public User Register(string username, string password, string email)
        {
            User user = new User(username, password, email, false);
            user = updateRegisterList(user);
            return user;
        }

        private User updateRegisterList(User user)
        {
            lock (lockThis)
            {
                if (init)
                    Initialized();
                if (registerUsers == null)
                {
                    user.setAdmin();
                    registerUsers = new Dictionary<string, User>();
                }
                if (registerUsers.ContainsKey(user.getUsername()))
                    throw new allreadyHasNameException(user.getUsername());
                registerUsers.Add(user.getUsername(), user);
                return user;
            }
        }

        public bool EditProfile(string username, string password, string email)
        {
            lock (lockThis)
            {
                if (!registerUsers.ContainsKey(username))
                    return false;
                registerUsers.Add(username, new User(username, password, email, false));
                return true;
            }
        }

        public bool Login(string username, string password)
        {
            lock (lockThis)
            {
                if (!registerUsers.ContainsKey(username))
                    throw new NoUserNameException(username);
                if (!registerUsers[username].chackPassword(password))
                    throw new NotAPasswordException(password);
                loginUsers.Add(username, registerUsers[username]);
                return true;
            }
        }

        public bool Logout(string username)
        {
            lock (lockThis)
            {
                if (!registerUsers.ContainsKey(username))
                    throw new NoUserNameException(username);
                loginUsers.Remove(username);
                return true;
            }
        }
    }
}