using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;
using TexasHoldem.Backend;
using TexasHoldem.DataLayer;

namespace TexasHoldem.BusinessLayer
{
    class GameCenter
    {
        private GameCenterDB db;
        private bool adminFlag;
        public User Register(string username, string password, string email)
        {
            if (db.IsNameExists(username))
                return null;
            User tmp = db.CreateNewUser(username, password, email, adminFlag);
            adminFlag = false;
            return tmp;
        }
        public bool EditProfile(string username, string password, string email)
        {
            if (!db.IsNameExists(username))
                return false;
            db.DeleteUser(username);
            Register(username, password, email);
            return true;
        }
    }
}
