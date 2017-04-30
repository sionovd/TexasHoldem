﻿using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;


namespace TexasHoldem
{
    public class UserController
    {
        private DataBase db = new DataBase();
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
                User user = new User(username, password, email, false);
                if (registerUsers == null)
                {
                    user.setAdmin();
                    registerUsers = new Dictionary<string, User>();
                }
                if (registerUsers.ContainsKey(username))
                    throw new AlreadyHasNameException(user.getUsername());
                registerUsers.Add(username, user);
                return user;
            }
        }

        public User RegisterWithMoney(string username, string password, string email, int money)
        {
            lock (lockThis)
            {
                if (init)
                    Initialized();
                User user = new User(username, password, email, false, money);
                if (registerUsers == null)
                {
                    user.setAdmin();
                    registerUsers = new Dictionary<string, User>();
                }
                if (registerUsers.ContainsKey(username))
                    throw new AlreadyHasNameException(user.getUsername());
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
                bool admin = registerUsers[username].getAdmin();
                registerUsers[username] =  new User(username, password, email, admin);
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
                loginUsers[username] = registerUsers[username];
                return true;
            }
        }

        public bool Logout(string username)
        {
            lock (lockThis)
            {
                if (!registerUsers.ContainsKey(username) || loginUsers.ContainsKey(username))
                    throw new NoUserNameException(username);
                loginUsers.Remove(username);
                return true;
            }
        }
    }
}