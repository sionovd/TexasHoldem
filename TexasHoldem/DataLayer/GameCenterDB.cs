using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexasHoldem.Backend;

namespace TexasHoldem.DataLayer
{
    class GameCenterDB
    {
        DataBase db;
        private Dictionary<string, User> userMap;
       public bool IsNameExists(string username)
        {
            return userMap.ContainsKey(username);
        }
       public User CreateNewUser(string username, string password, string email, bool isAdmin)
        {
            User user = new User(username, password, email, isAdmin);
            userMap.Add(username, user);
            return user;
        }
       public void DeleteUser(string username)
        {
            userMap.Remove(username);
        }
   
    }
}
