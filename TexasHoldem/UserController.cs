﻿using System;
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
                    throw new allreadyHasNameException(user.getUsername());
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
                registerUsers.Add(username, new User(username, password, email, admin));
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