using System;
using System.Collections.Generic;
using System.Linq;
using System.Text;
using System.Threading.Tasks;

namespace TexasHoldem
{
    public class User
    {
        private bool isAdmin;
        private string username;
        private string password;
        private string email;
        private int moneyBalance;// at start?

        public User(string username)
        {
            // this = database.getUser(username);
        }

        public User(string username, string password, string email, bool isAdmin, int money)
        {
            this.username = username;
            if (password.Equals(""))
                throw new NotAPasswordException(password);
            this.password = password;
            this.email = email;
            this.isAdmin = isAdmin;
            this.moneyBalance = money;
        }

        public User (string username, string password, string email, bool isAdmin)
        {
            this.username = username;
            if (password.Equals(""))
                throw new NotAPasswordException(password);
            this.password = password;
            this.email = email;
            this.isAdmin = isAdmin;
        }
        public bool getAdmin()
        {
            return isAdmin;
        }
        public string getUsername()
        {
            return username;
        }
        public string getEmail()
        {
            return email;
        }
        public void setAdmin()
        {
            isAdmin = true;
        }
        public double getmoneyBalance()
        {
            return moneyBalance;
        }
        public void setmoneyBalance(int moneyBalance)
        {
            this.moneyBalance = moneyBalance;
        }
        public int decreaseMoney(int money)
        {
            this.moneyBalance = this.moneyBalance - money;
            return moneyBalance;
        }
        public bool chackPassword(string password)
        {
            return this.password.Equals(password);
        }
    }
}